﻿
using PENet;
using Protocal;

namespace Server
{
    class ServerStart
    {
        static void Main(string[] args)
        {
            PESocket<ServerSession, NetMsg> server = new PESocket<ServerSession, NetMsg>();
            server.StartAsServer(IPCfg.SvrIP, IPCfg.SvrPort);
            while (true)
            {

            }
        }
    }
}
