/****************************************************
	文件：PECommon.cs
	作者：ryh
	邮箱: 2311790787@qq.com
	日期：2020/03/02 14:21   	
	功能：客户端服务器公用工具类
*****************************************************/

using PENet;

public enum LogType {
    Log,
    Warn,
    Error,
    Info,
}

public class PECommon
{
    public static void Log(string msg = "", LogType tp = LogType.Log)
    {
        LogLevel lv = (LogLevel)tp;
        PETool.LogMsg(msg, lv);
    }
}