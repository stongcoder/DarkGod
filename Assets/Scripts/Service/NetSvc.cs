/****************************************************
    文件：NetSvc.cs
	作者：ryh
    邮箱: 2311790787@qq.com
    日期：2020/3/2 12:14:9
	功能：网络服务
*****************************************************/

using PENet;
using PEProtocol;
using System.Collections.Generic;
using UnityEngine;

public class NetSvc : MonoSingleton<NetSvc>
{
    private static readonly string obj = "lock";
    PENet.PESocket<ClientSession, GameMsg> client = null;
    private Queue<GameMsg> msgQue = new Queue<GameMsg>();
    public void Init()
    {
        client = new PESocket<ClientSession, GameMsg>();        
        client.SetLog(true, (string msg, int lv) =>
         {
             switch (lv)
             {
                 case 0:
                     msg = "Log" + msg;
                     Debug.Log(msg);
                     break;
                 case 1:
                     msg = "Warn" + msg;
                     Debug.LogWarning(msg);
                     break;
                 case 2:
                     msg = "Error" + msg;
                     Debug.LogError(msg);
                     break;
                 case 3:
                     msg = "Info" + msg;
                     Debug.Log(msg);
                     break;
             }
         });
        client.StartAsClient(SrvCfg.SvrIP, SrvCfg.SvrPort);
        PECommon.Log("NetSvc Init");
    }
    private void Update()
    {
        if (msgQue.Count > 0)
        {
            GameMsg msg = msgQue.Dequeue();
            ProcessMsg(msg);
        }
    }
    public void SendMsg(GameMsg msg)
    {
        if (client.session != null)
        {
            client.session.SendMsg(msg);
        }
        else
        {
            //重连服务器
            GameRoot.Instance.AddTips("服务器未连接");
            Init();
        }
    } 
    public void AddNetMsg(GameMsg msg)
    {
        lock (obj)
        {
            msgQue.Enqueue(msg);
        }
    }
    private void ProcessMsg(GameMsg msg)
    {
        if (msg.err != (int)ErrorCode.None)
        {
            switch ((ErrorCode)msg.err)
            {
                case ErrorCode.AcctIsOnLine:
                    GameRoot.Instance.AddTips(Constants.Login_3);
                    break;
                case ErrorCode.WrongPass:
                    GameRoot.Instance.AddTips(Constants.Login_4);
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch ((CMD)msg.cmd)
            {
                case CMD.None:
                    break;
                case CMD.ReqLogin:
                    break;
                case CMD.RspLogin:
                    LoginSys.Instance.AckLogin(msg);
                    break;
                default:
                    break;
            }
        }

    }

}
