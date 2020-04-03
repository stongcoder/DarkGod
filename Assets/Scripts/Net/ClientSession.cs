/****************************************************
    文件：ClientSession.cs
	作者：ryh
    邮箱: 2311790787@qq.com
    日期：2020/3/2 13:42:45
	功能：客户端网络会话
*****************************************************/

using PENet;
using PEProtocol;
using UnityEngine;

public class ClientSession : PESession<GameMsg>
{
    protected override void OnConnected()
    {  
        PECommon.Log("Server Connect");
    }

    protected override void OnReciveMsg(GameMsg msg)
    {
        PECommon.Log("Receive CMD:"+((CMD)msg.cmd).ToString());
        NetSvc.Instance.AddNetMsg(msg);
    }

    protected override void OnDisConnected()
    {
        PECommon.Log("Server Disconnect");
    }
}
