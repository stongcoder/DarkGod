/****************************************************
	文件：ServerRoot.cs
	作者：ryh
	邮箱: 2311790787@qq.com
	日期：2020/02/28 20:25   	
	功能：管理服务器
*****************************************************/

public class ServerRoot
{
    private static ServerRoot instance = null;
    public static ServerRoot Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ServerRoot();
            }
            return instance;
        }
    }

    public void Init()
    {
        NetSvc.Instance.Init();
        CacheSvc.Instance.Init();

        LoginSys.Instance.Init();
    }
    public void Update()
    {
        NetSvc.Instance.Update();
    }
}
