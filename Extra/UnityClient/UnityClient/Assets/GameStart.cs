/****************************************************
    文件：GameStart.cs
	作者：#CreateAuthor#
    邮箱: 2311790787@qq.com
    日期：#CreateTime#
	功能：待填写
*****************************************************/

using Protocal;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    PENet.PESocket<ClientSession, NetMsg> socket = null;
    private void Start()
    {
        socket = new PENet.PESocket<ClientSession, NetMsg>();
        socket.StartAsClient(IPCfg.SvrIP,IPCfg.SvrPort);
        socket.SetLog(true, (string msg, int level) => {
            switch (level)
            {
                case 0:
                    msg = "Log" + msg;
                    Debug.Log(msg);                  
                    break;
                case 1:
                    msg = "Warn:" + msg;
                    Debug.LogWarning(msg);
                    break;
                case 2:
                    msg = "Error:" + msg;
                    Debug.LogError(msg);
                    break;
                case 3:
                    msg = "Info:" + msg;
                    Debug.Log(msg);
                    break;
            }
        });       
       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            socket.session.SendMsg(new NetMsg
            {
                text = "Hello Unity"
            });
        }
    }
}
