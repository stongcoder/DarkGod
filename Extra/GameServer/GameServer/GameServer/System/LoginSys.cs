/****************************************************
	文件：LoginSys.cs
	作者：ryh
	邮箱: 2311790787@qq.com
	日期：2020/02/28 20:28   	
	功能：待填写
*****************************************************/

using PEProtocol;

public class LoginSys
{
    private static LoginSys instance = null;
    public static LoginSys Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LoginSys();
            }
            return instance;
        }
    }

    public void Init()
    {
        PECommon.Log("LoginSys Init Done");
    }
    public void ReqLogin(MsgPack msgPack)
    {
        //判断账号是否已经上线，并作回应
        ReqLogin data = msgPack.msg.reqLogin;
        GameMsg msg = new GameMsg
        {
            cmd = (int)CMD.RspLogin,
            rspLogin = new RspLogin
            {

            }
        };
        //已上线返回错误信息
        if (CacheSvc.Instance.IsAccountOnLine(data.acc))
        {
            msg.err = (int)ErrorCode.AcctIsOnLine;
        }
        else
        {
            //未上线
            PlayerData pd = CacheSvc.Instance.GetPlayerData(data.acc, data.pass);
            if (pd == null)//账号无效
            {
                msg.err = (int)ErrorCode.WrongPass;
            }
            else//账号有效
            {
                msg.rspLogin = new RspLogin
                {
                    playerData = pd
                };
                CacheSvc.Instance.AcctOnLine(data.acc, msgPack.session, pd);
            }
        }
        
        msgPack.session.SendMsg(msg);
    }
}
