using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TcpTest:MonoBehaviour
{
	//string editString="Connected!"; //编辑框文字
	GameObject Pi;//这里改成你的那个对象名
    public Text NodeCode;
    public Text LightStrength;
    public Button btn1;
    public Button btn2;

	TcpClientHandler tcpClient;
	// Use this for initialization
	void Start()
	{
		//初始化网络连接
		//tcpClient=new TcpClientHandler(); //因为tcp的类继承了monobehaviour所以不能用new，或者去掉对monobehaviour继承就可以用new
		tcpClient=gameObject.AddComponent<TcpClientHandler>();
		tcpClient.InitSocket();

        //btn1.onClick.AddListener(() =>
        //{
        //    tcpClient.SocketSend("1");
        //    NodeCode.text = "节点编号：" + tcpClient.GetRecvStr();
        //});
        //btn2.onClick.AddListener(() =>
        //{
        //    tcpClient.SocketSend("2");
        //    LightStrength.text = "当前光强：" + tcpClient.GetRecvStr();
        //});
        InvokeRepeating("init", 1, 10);
    }


    private void init()
    {
        //StopAllCoroutines();
        //StartCoroutine("UpdateCoutine");

        
        tcpClient.SocketSend("1");
        string temp = tcpClient.GetRecvStr();
        string[] temps = temp.Split(';');
        NodeCode.text = "节点编号：" + temps[0];
        //GUI.Label(new Rect(10,70,300,20),"节点编号："+tcpClient.GetRecvStr());
        tcpClient.SocketSend("2");
        LightStrength.text = "当前光强：" + temps[1];
        //GUI.Label(new Rect(10,90,300,20),"当前光强："+tcpClient.GetRecvStr());
    }
    IEnumerator UpdateCoutine()
    {
        tcpClient.SocketSend("1");
        yield return new WaitForSeconds(0.1f);
        NodeCode.text = "节点编号：" + tcpClient.GetRecvStr();
        tcpClient.SocketSend("2");
        yield return new WaitForSeconds(0.1f);
        LightStrength.text = "当前光强：" + tcpClient.GetRecvStr();
    }

    void OnGUI()
    {

        tcpClient.SocketSend("1");
        string temp = tcpClient.GetRecvStr();
        string[] temps = temp.Split(';');
        NodeCode.text = "节点编号：" + temps[0];
        //GUI.Label(new Rect(10,70,300,20),"节点编号："+tcpClient.GetRecvStr());
        tcpClient.SocketSend("2");
        LightStrength.text = "当前光强：" + temps[1];
        //GUI.Label(new Rect(10,90,300,20),"当前光强："+tcpClient.GetRecvStr());
    }

	void OnApplicationQuit()
	{
		//退出时关闭连接
		tcpClient.SocketQuit();
	}
}