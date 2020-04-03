/****************************************************
    文件：LoginWnd.cs
	作者：ryh
    邮箱: 2311790787@qq.com
    日期：2020/2/25 12:2:13
	功能：登陆窗口
*****************************************************/

using PEProtocol;
using UnityEngine;
using UnityEngine.UI;
public class LoginWnd : WindowRoot
{
    public InputField IptAccount;
    public InputField IptPassword;
    protected override void Init()
    {
        base.Init();
        if (PlayerPrefs.HasKey("LoginAccount") && PlayerPrefs.HasKey("LoginPassword"))
        {
            IptAccount.text = PlayerPrefs.GetString("LoginAccount");
            IptPassword.text = PlayerPrefs.GetString("LoginPassword");
        }
        else
        {
            IptAccount.text = "";
            IptPassword.text = "";
        }
    }
    public void OnBtnEnterClick()
    {
        string account = IptAccount.text.Trim();
        string password = IptPassword.text.Trim();
        if (account!= "" && password!= "")
        {
            //LoginSys.Instance.AckLogin();
            PlayerPrefs.SetString("LoginAccount", account);
            PlayerPrefs.SetString("LoginPassword", password);
            GameMsg msg = new GameMsg {
                cmd = (int)CMD.ReqLogin,
                reqLogin=new ReqLogin {
                    acc =account,
                    pass=password
                }
            };
            NetSvc.Instance.SendMsg(msg);
        }
        else
        {
            GameRoot.Instance.AddTips(Constants.Login_2);
        }
    }
}
