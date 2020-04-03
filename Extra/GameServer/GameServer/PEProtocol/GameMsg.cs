/****************************************************
	文件：GameMsg.cs
	作者：ryh
	邮箱: 2311790787@qq.com
	日期：2020/03/02 11:24   	
	功能：网络通信协议（客户端服务器通用）
*****************************************************/
using PENet;
using System;

namespace PEProtocol
{
    [Serializable]
    public class GameMsg:PEMsg
    {
        public string text;
        public ReqLogin reqLogin;
        public RspLogin rspLogin;
    }
    public class SrvCfg
    {
        public const string SvrIP = "127.0.0.1";
        public const int SvrPort = 20000;
    }
    [Serializable]
    public class PlayerData
    {
        public int id;
        public string name;
        public int lv;
        public int exp;
    }
    public enum CMD
    {   None=0,
        //登录相关 100
        ReqLogin=101,
        RspLogin=102,
    }
    public enum ErrorCode
    {
        None=0,
        AcctIsOnLine,//账号已上线
        WrongPass,//密码错误
    }


    [Serializable]
    public class ReqLogin
    {
        public string acc;
        public string pass;
    }
    [Serializable]
    public class RspLogin
    {
        public PlayerData playerData;
    }
}
