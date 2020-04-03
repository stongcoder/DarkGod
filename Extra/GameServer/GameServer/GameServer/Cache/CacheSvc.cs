using PEProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CacheSvc
{
    private static CacheSvc instance = null;
    public static CacheSvc Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CacheSvc();
            }
            return instance;
        }
    }
    private Dictionary<string, ServerSession> onLineAcctDict = new Dictionary<string, ServerSession>();
    private Dictionary<ServerSession, PlayerData> onLineSessionDic = new Dictionary<ServerSession, PlayerData>();
    public void Init()
    {
        PECommon.Log("CacheSvc Init");

    }
    public bool IsAccountOnLine(string acct)
    {
        return onLineAcctDict.ContainsKey(acct);
    }
    //根据账号密码返回账号数据，密码错误返回null,账号不存在则创建新账号
    public PlayerData GetPlayerData(string acct, string pass)
    {
        return null;
    }
    //账号上线，缓存数据
    public void AcctOnLine(string acct,ServerSession session,PlayerData playerData)
    {
        onLineAcctDict.Add(acct, session);
        onLineSessionDic.Add(session, playerData);
    }
}