/****************************************************
    文件：GameRoot.cs
	作者：ryh
    邮箱: 2311790787@qq.com
    日期：2020/2/24 19:6:57
	功能：游戏启动入口
*****************************************************/
using PEProtocol;
using UnityEngine;

public class GameRoot : MonoSingleton<GameRoot>    
{
    public LoginWnd loginWnd;
    public LoadingWnd loadingWnd;
    public DynamicWnd dynamicWnd;
    public CreateWnd createWnd;
    private PlayerData playerData = null;
    public PlayerData PlayerData
    {
        get => playerData;
        private set => playerData = value;
    }
    private void Start()
    {
        DontDestroyOnLoad(this);      
        Init();
    }
   
    private void Init()
    {
        //加载服务     
        ResSvc.Instance.Init();
        AudioSvc.Instance.Init();
        NetSvc.Instance.Init();
        //加载各系统
        LoginSys.Instance.Init();     
        LoginSys.Instance.Init();     
        //进入登陆场景并加载相关UI
        LoginSys.Instance.EnterLogin();


        //激活dynamicWnd
        dynamicWnd.gameObject.SetActive(true);
       
    }
    public void AddTips(string tips)
    {
        dynamicWnd.AddTips(tips);
    }
    public void SetPlayerData(RspLogin data)
    {
        playerData = data.playerData;
    }
}

