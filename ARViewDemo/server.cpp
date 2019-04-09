#include <QTcpServer>
#include <QTcpSocket>
#include <QAbstractSocket>
#include <QDebug>
#include "widget.h"
#include "ui_widget.h"
 
Widget::Widget(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::Widget)
{
    ui->setupUi(this);
    //初始化server并监听
    tcpServer=new QTcpServer(this); //qt自己内存管理
    if(!tcpServer->listen(QHostAddress::Any,6666)) //监听所有网络地址，端口6666
        qDebug()<<tcpServer->errorString();
    statusText=statusText+"wait for connecting..."+"\n";
    ui->statusLabel->setText(statusText);
    //绑定信号槽，当有连接时作出反应
    connect(tcpServer,SIGNAL(newConnection()),this,SLOT(SocketConnet()));
}
 
void Widget::SocketConnet()
{
    //获得client socket
    clientTcpSocket=tcpServer->nextPendingConnection();
    //绑定信号槽，接收数据，并且当连接关闭是删除连接
    connect(clientTcpSocket,SIGNAL(readyRead()),this,SLOT(SocketReceive()));
    connect(clientTcpSocket,SIGNAL(disconnected()),clientTcpSocket,SLOT(deleteLater()));
    //显示客户端连接信息
    QString clientIp=clientTcpSocket->peerAddress().toString();
    QString clientPort=QString::number(clientTcpSocket->peerPort());
    statusText=statusText+"conneted with "+clientIp+":"+clientPort+"\n";
    ui->statusLabel->setText(statusText);
}
 
void Widget::SocketSend(QString sendStr)
{
    clientTcpSocket->write(sendStr.toStdString().c_str());
}
 
void Widget::SocketReceive()
{
    //接收数据并显示，字节转换成了字符串
    QString recvStr=clientTcpSocket->readAll();
    statusText=statusText+recvStr+"\n";
    ui->statusLabel->setText(statusText);
    //经处理后发送回去
    SocketSend("From server: "+recvStr);
}
 
Widget::~Widget()
{
    delete ui;
}
 
//发送unity物体左旋消息
void Widget::on_leftBtn_clicked()
{
    SocketSend("leftrotate");
}
 
//发送unity物体右旋消息
void Widget::on_rightBtn_clicked()
{
    SocketSend("rightrotate");
}