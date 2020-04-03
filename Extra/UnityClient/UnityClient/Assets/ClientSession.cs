using PENet;
using Protocal;

public class ClientSession : PESession<NetMsg>
{
    protected override void OnConnected()
    {
       
    }

    protected override void OnDisConnected()
    {
        
    }

    protected override void OnReciveMsg(NetMsg msg)
    {
        PETool.LogMsg("Server Response:" + msg.text);
    }
}

