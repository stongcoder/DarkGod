/****************************************************
	文件：ServerSession.cs
	作者：ryh
	邮箱: 2311790787@qq.com
	日期：2020/03/02 11:38   	
	功能：网络回话（客户端一个，服务端多个）
*****************************************************/
using PENet;
using PEProtocol;

public class ServerSession:PESession<GameMsg>
{
    protected override void OnConnected()
    {
        PECommon.Log("Client Connected"); 
    }

    protected override void OnDisConnected()
    {
        PECommon.Log("Client DisConnected");
     
    }

    protected override void OnReciveMsg(GameMsg msg)
    {
        PECommon.Log("Receive CMD:" + ((CMD)msg.cmd).ToString());
        NetSvc.Instance.AddMsgQue(msg, this);
    }
}
