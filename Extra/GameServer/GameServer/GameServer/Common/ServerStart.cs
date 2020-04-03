/****************************************************
	文件：ServerStart.cs
	作者：ryh
	邮箱: 2311790787@qq.com
	日期：2020/02/28 20:24   	
	功能：服务器启动
*****************************************************/
using System;

public class ServerStart
{
    static void Main(string[] args)
    {
        ServerRoot.Instance.Init();
        while (true)
        {
            ServerRoot.Instance.Update();
        }

    }
}
