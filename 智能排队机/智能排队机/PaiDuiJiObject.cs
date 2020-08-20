using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 智能排队机
{
    class PaiDuiJiObject
    {
        public class Value
        {
        }

        public class DatasItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string ApiTag { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Value { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string RecordTime { get; set; }
        }

        public class ResultObjItem
        {
            /// <summary>
            /// 
            /// </summary>
            public int DeviceID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<DatasItem> Datas { get; set; }
        }

        public class ErrorObj
        {
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public List<ResultObjItem> ResultObj { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int Status { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int StatusCode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public ErrorObj ErrorObj { get; set; }
        }
       
    }
}
