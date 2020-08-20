using NLECloudSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 智能排队机
{
    class Public_Class
    {
        //默认为新大陆物联网云平台API域名，测试环境或私有云请更改为自己的
        public static String API_HOST = "http://api.nlecloud.com";   //域名
        public static String Token;                        //登录后返回的Token
        public static NLECloudAPI SDK = null;              //SDK的封装类

        public static double light_max; //光照最大值
        public static double light_min; //光照最小值


        public static Int32 projectId;               //云平上面的项目ID
        public static String devIds;               //批量查询设备最新数据等接口用到
        public static Int32 deviceId;               //云平上面的项目下的设备ID
        public static String apiTag;     //查询传感器的传感标识名
        public static String actuatorApiTag;    //发送命令的执行器标识名
    }
}
