/****************************************************
    文件：LoginSys.cs
	作者：ryh
    邮箱: 2311790787@qq.com
    日期：2020/2/24 19:12:17
	功能：登录系统
*****************************************************/

using PEProtocol;
using System;
using UnityEngine;

public class LoginSys : MonoSingleton<LoginSys>
{    
    public void Init()
    {        
        PECommon.Log("LoginSys初始化");
    }
    public void EnterLogin()
    {
        //异步加载登录界面，加载完成后打开
        ResSvc.Instance.AsyncLoadScene(Constants.SceneLogin,()=>{
            GameRoot.Instance.loginWnd.SetWindowState(true);
            AudioSvc.Instance.PlayBGM(Constants.BGLogin);
        });
    }
    public void AckLogin(GameMsg msg)
    {
        GameRoot.Instance.AddTips(Constants.Login_1);
        GameRoot.Instance.SetPlayerData(msg.rspLogin);
        //判断是否已创建角色
        if (msg.rspLogin.playerData.name == "")
        {
            GameRoot.Instance.createWnd.SetWindowState(true);
        }
        else
        {
            //进入主城
        }
        GameRoot.Instance.loginWnd.SetWindowState(false);
       
    }
}
