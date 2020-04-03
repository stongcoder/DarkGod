/****************************************************
	文件：NetSvc.cs
	作者：ryh
	邮箱: 2311790787@qq.com
	日期：2020/02/28 20:28   	
	功能：待填写
*****************************************************/

using PENet;
using PEProtocol;
using System.Collections.Generic;
public class MsgPack
{
    public GameMsg msg;
    public ServerSession session;
    public MsgPack(GameMsg msg,ServerSession session)
    {
        this.msg = msg;
        this.session = session;
    }
}
public class NetSvc
{
    private static NetSvc instance = null;
    public static NetSvc Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new NetSvc();
            }
            return instance;
        }
    }
    public static readonly string obj = "lock";
    private Queue<MsgPack> MsgPackQueue = new Queue<MsgPack>();

 
    public void Init()
    {
        PESocket<ServerSession, GameMsg> server = new PESocket<ServerSession, GameMsg>();
        server.StartAsServer(SrvCfg.SvrIP, SrvCfg.SvrPort);
        PECommon.Log("NetSvc Init Done");
    }
    public void AddMsgQue(GameMsg msg,ServerSession session)
    {
        lock (obj)
        {
            MsgPackQueue.Enqueue(new MsgPack(msg,session));
        }
    }
    public void Update()
    {
        if (MsgPackQueue.Count > 0)
        {
            PECommon.Log("msgCount:" + MsgPackQueue.Count);
            lock (obj)
            {
                MsgPack msgPack = MsgPackQueue.Dequeue();
                HandoutMsg(msgPack);
            }
        }
    }
    private void HandoutMsg(MsgPack msgPack)
    {
        switch ((CMD)msgPack.msg.cmd)
        {
            case CMD.None:
                break;
            case CMD.ReqLogin:
                LoginSys.Instance.ReqLogin(msgPack);
                break;
            case CMD.RspLogin:
                break;
        }
    }
}
