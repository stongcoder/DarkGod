using PENet;
using System.Net.Sockets;

namespace Protocal
{
    [Serializable]
    public class NetMsg:PEMsg
    {
        public string text;
    }
    public class IPCfg
    {
        public const string SvrIP = "127.0.0.1";
        public const int SvrPort = 20000;
    }
}
