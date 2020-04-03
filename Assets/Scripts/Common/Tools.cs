/****************************************************
	文件：Tools.cs
	作者：ryh
	邮箱: 2311790787@qq.com
	日期：2020/02/27 14:19   	
	功能：工具函数
*****************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tools
{
    public static int RandomInt(int min,int max,System.Random rd = null)
    {
        if (rd==null)
        {
            rd = new System.Random();
        }
        int val = rd.Next(min, max + 1);
        return val;
    }

}
