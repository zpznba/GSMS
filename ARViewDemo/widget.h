#ifndef WIDGET_H
#define WIDGET_H
 
#include <QWidget>
 
class QTcpServer;//前向声明
class QTcpSocket;
 
namespace Ui {
class Widget;
}
 
class Widget : public QWidget
{
    Q_OBJECT
 
public:
    explicit Widget(QWidget *parent = 0);
    ~Widget();
 
private:
    Ui::Widget *ui;
 
private:
    QString statusText; //状态信息
    QTcpServer *tcpServer; //服务器
    QTcpSocket *clientTcpSocket; //客户端socket
    void SocketSend(QString sendStr);
private slots:
    void SocketConnet();
    void SocketReceive();
    void on_leftBtn_clicked();
    void on_rightBtn_clicked();
};
 
#endif // WIDGET_H