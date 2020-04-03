
using PENet;
using Protocal;

public class ServerSession : PESession<NetMsg>
{
    protected override void OnConnected()
    {
        PETool.LogMsg("Client Connected");
    }

    protected override void OnDisConnected()
    {
        PETool.LogMsg("Client DisConnected");
    }

    protected override void OnReciveMsg(NetMsg msg)
    {
        PETool.LogMsg("Client Req" + msg.text);
    }
}
