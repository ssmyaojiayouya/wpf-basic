using Newtonsoft.Json;
using NLECloudSDK;
using NLECloudSDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 智能排队机
{
    class Public_Methods
    {
        public static dynamic qry;

        #region -- json处理函数 -- 
        //把获取到的数据转换成json序列化
        public static String SerializeToJson(Object data)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        //Json数据的格式处理方式
        public static JsonSerializerSettings JsonVert()
        {
            //json数据转换函数
            JsonSerializerSettings setting = new JsonSerializerSettings();
            JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
            {
                //日期类型默认格式化处理
                setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                //空值处理
                setting.NullValueHandling = NullValueHandling.Ignore;

                //高级用法九中的Bool类型转换 设置
                //    setting.Converters.Add(new BoolConvert("是,否"));

                return setting;
            });
            return setting;
        }

        #endregion

        #region -- 项目测试 -- 
        //查询单个项目。   修改为自己的项目ID---projectId
        public static void Project_SingleSearch()
        {
            qry = Public_Class.SDK.GetProjectInfo(Public_Class.projectId, Public_Class.Token);
        }

        //模糊查询项目。   修改为自己的查询条件---query
        public static void Project_FuzzySearch(int PageIndex, int PageSize, string StartDate, string EndDate)
        {
            var query = new ProjectFuzzyQryPagingParas()
            {
                /*PageIndex = 1,
                PageSize = 20,
                StartDate = "2009-01-01",
                EndDate = "2018-06-14",
                */
                PageIndex = PageIndex,
                PageSize = PageSize,
                StartDate = StartDate,
                EndDate = EndDate,

            };
            qry = Public_Class.SDK.GetProjects(query, Public_Class.Token);
        }

        //查询项目所有设备的传感器。   请修改为自己的项目ID---projectId
        public static void Project_SearchSensor()
        {           
            qry = Public_Class.SDK.GetProjectSensors(Public_Class.projectId, Public_Class.Token);
        }

        #endregion

        #region -- 设备测试 -- 
        //批量查询设备最新数据。  修改为自己的设备ID串---devIds
        public static void Device_NewDataSearch()
        {
            //String devIds = deviceId.ToString();
            qry = Public_Class.SDK.GetDevicesDatas(Public_Class.devIds, Public_Class.Token);
        }

        //批量查询设备的在线状态。 修改为自己的设备ID串---devIds
        public static void Device_OnlineSearch()
        {
            //String devIds = deviceId.ToString();
            qry = Public_Class.SDK.GetDevicesStatus(Public_Class.devIds, Public_Class.Token);
        }

        //查询单个设备。  输入变量：修改为自己的设备ID---deviceId
        public static void Device_SingleSearch()
        {
            qry = Public_Class.SDK.GetDeviceInfo(Public_Class.deviceId, Public_Class.Token);
        }


        //模糊查询设备。 修改为自己的查询条件---query1
        public static void Device_FuzzySearch(int PageIndex, int PageSize, string StartDate, string EndDate)
        {
            var query1 = new DeviceFuzzyQryPagingParas()
            {
                DeviceIds = Public_Class.deviceId.ToString(),
                /* PageIndex = 1,
                 PageSize = 20,
                 StartDate = "2009-01-01",
                 EndDate = "2018-06-14",
                */
                PageIndex = PageIndex,
                PageSize = PageSize,
                StartDate = StartDate,
                EndDate = EndDate,

            };
            qry = Public_Class.SDK.GetDevices(query1, Public_Class.Token);
        }

        //添加个新设备。  输入变量：无，注意修改添加的新设备信息---device
        public static void Device_AddNew(string Name, string Tag)
        {
            var device = new DeviceAddUpdateDTO()
            {
                Protocol = 1,
                IsTrans = true,
                ProjectIdOrTag = Public_Class.projectId.ToString(),
                //Name = "新添加的设备",
                //Tag = "newDevice2018"
                Name = Name,
                Tag = Tag
            };
            qry = Public_Class.SDK.AddDevice(device, Public_Class.Token);
        }

        //更新某个设备。
        public static void Device_Refresh(string Name, string Tag,Int32 newDeviceId)
        {
            //var newDeviceId = qry.ResultObj;
            var device = new DeviceAddUpdateDTO()
            {
                Protocol = 1,
                IsTrans = true,
                ProjectIdOrTag = Public_Class.projectId.ToString(),
                //Name = "新添加的设备(更新后)",
               //Tag = "newUpdateDevice"
                Name = Name,
                Tag = Tag
            };
            qry = Public_Class.SDK.UpdateDevice(newDeviceId, device, Public_Class.Token);
        }

        //删除某个设备。
        public static void Device_Delete(Int32 newDeviceId)
        {
            qry = Public_Class.SDK.DeleteDevice(newDeviceId, Public_Class.Token);
        }

        #endregion

        #region -- 设备传感器API测试 -- 

        //查询单个传感器。===================请修改为自己的设备ID,传感标识名ApiTag
        public static void Sensor_SingelSearch()
        {
            qry = Public_Class.SDK.GetSensorInfo(Public_Class.deviceId, Public_Class.apiTag, Public_Class.Token);
        }


        //模糊查询传感器。===================请修改为自己的设备ID串
        public static void Sensor_FuzzySearch()
        {
            qry = Public_Class.SDK.GetSensors(Public_Class.deviceId, "", Public_Class.Token);
        }



        //添加一个新的传感器。===================请修改为自己的设备ID,传感标识名ApiTag
        public static void Sensor_AddNew(string newApiTag, byte datatype, string name, string unit)
        {
            //var newApiTag = "newsensor";
            SensorAddUpdate sensor = new SensorAddUpdate()
            {
                /*ApiTag = newApiTag,
                DataType = 1,
                Name = "新的传感器",
                Unit = "C",
                */
                ApiTag = newApiTag,
                DataType = datatype,
                Name = name,
                Unit = unit, //单位
            };
            qry = Public_Class.SDK.AddSensor<SensorAddUpdate>(Public_Class.deviceId, sensor, Public_Class.Token);
        }

        //注意：创建对象是遵循以下类别创建对象
        //传感器：为SensorAddUpdate对象
        //执行器：为ActuatorAddUpdate对象
        //摄像头：为CameraAddUpdate对象
        //这里模拟创建传感SensorAddUpdate对象

        public static void Sensor_Refresh(string name, string newApiTag)
        {
            if (qry.IsSuccess() && qry.ResultObj > 0)
            {
                //更新某个传感器。===================请修改为自己的设备ID,传感标识名ApiTag
                SensorAddUpdate sensor = new SensorAddUpdate()
                {
                    //Name = "新的传感器(更新后)"
                    Name = name
                };
                qry = Public_Class.SDK.UpdateSensor<SensorAddUpdate>(Public_Class.deviceId, newApiTag, sensor, Public_Class.Token);

            }
        }

        //删除某个传感器。===================请修改为自己的设备ID,传感标识名ApiTag
        public static void Sensor_Delete(string newApiTag)
        {
            qry = Public_Class.SDK.DeleteSensor(Public_Class.deviceId, newApiTag, Public_Class.Token);
        }

        #endregion

        #region -- 传感数据API测试 -- 

        //新增传感数据。===================请修改为自己的设备ID,传感标识名ApiTag
        public static void SensorData_AddNew(Int32 deviceId,string apiTag, int value)
        {
            var sensorData1 = new SensorDataAddDTO() { ApiTag = apiTag };
            sensorData1.PointDTO = new List<SensorDataPointDTO>()
            {
                 new SensorDataPointDTO() { Value = value },
                 //new SensorDataPointDTO() { Value = 5500 }
            };

            //var apiTag2 = "apiTagDemo";
            //SensorDataAddDTO sensorData2 = new SensorDataAddDTO() { ApiTag = apiTag2 };
            //sensorData2.PointDTO = new List<SensorDataPointDTO>()
            //{
            //     new SensorDataPointDTO() { Value = "dataDemo" }
            //};

            var data = new SensorDataListAddDTO();
            //data.DatasDTO = new List<SensorDataAddDTO>() { sensorData1, sensorData2 };
            data.DatasDTO = new List<SensorDataAddDTO>() { sensorData1 };

            qry = Public_Class.SDK.AddSensorDatas(deviceId, data, Public_Class.Token);

        }

        //模糊查询传感数据，输入变量：deviceId，apiTag，startDate
        public static void Fuzzy_QuerySensorData(Int32 deviceId,String apiTag, String startDate)
        {
            //模糊查询传感数据。===================请修改为自己的设备ID,传感标识名ApiTag
            var query2 = new SensorDataFuzzyQryPagingParas()
            {
                DeviceID = deviceId,
                Method = 6,
                //TimeAgo = 30,
                //ApiTags = "m_waterPH,m_waterNTU,m_waterConduct",
                ApiTags = apiTag,
                StartDate = startDate,
                Sort = "DESC", //时间排序方式--倒序
                PageSize = 30, //每次查询10个
                PageIndex = 1
            };
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            qry = Public_Class.SDK.GetSensorDatas(query2, Public_Class.Token);
            sw.Stop();
            //var tmp = ((ResultMsg<SensorDataInfoDTO>)qry);
            //if (tmp.IsSuccess() && tmp.ResultObj != null)
            //{
            //    Console.WriteLine("查询传感数据返回JSON:" + Environment.NewLine);
            //    Console.WriteLine(SerializeToJson(qry) + Environment.NewLine);
            //}

        }

        //聚合查询传感器数据。  ===================请修改为自己的设备ID,传感标识名ApiTag
        public static void GroupSensorData_search(Int32 deviceId, String apiTag,string StartDate)
        {
            var query3 = new SensorDataJuHeQryPagingParas()
            {
                DeviceID = deviceId,
                //ApiTags = "nl_temperature,nl_fan",
                ApiTags = apiTag,
                GroupBy = 2,
                Func = "MAX",
                //StartDate = "2018-01-02 12:06:09"
                StartDate = StartDate
            };
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Restart();
            qry = Public_Class.SDK.GroupingSensorDatas(query3, Public_Class.Token);
            sw.Stop();
        }

        #endregion

        #region -- 命令API测试 -- 
        //发送命令。===================请修改为自己的设备ID,标识名ApiTag,控制值
        public static void Cmds(Int32 deviceId, String actuatorApiTag,Int32 cmd)
        {
            //actuatorApiTag;    //发送命令的执行器标识名
            qry = Public_Class.SDK.Cmds(deviceId, actuatorApiTag, cmd, Public_Class.Token);
        }
        
        #endregion



    }
}
