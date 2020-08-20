using Newtonsoft.Json;
using System;
using System.Windows;


namespace 智能排队机
{
    /// <summary>
    /// Form2.xaml 的交互逻辑
    /// </summary>
    public partial class Form2 : Window
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Json数据的格式处理方式
            JsonSerializerSettings setting = Public_Methods.JsonVert();


            //模糊查询设备最新30条数据
            Public_Methods.Fuzzy_QuerySensorData(100059, "nl_light", "2020-07-15 19:42:08");

            //解析json数据
            String Jsondata = Public_Methods.SerializeToJson(Public_Methods.qry); //序列化
            SensorDataObject.Root datas = JsonConvert.DeserializeObject<SensorDataObject.Root>(Jsondata, setting); //反序列化


            /*   这是把30条查询到的数据放进数据库！！！！！比赛时应该修改
            for(int i = 0;i < 30;i++) //把数据存放进入数据库
            {
                double Value = datas.ResultObj.DataPoints[0].PointDTO[i].Value;
                String RecordTime = datas.ResultObj.DataPoints[0].PointDTO[i].RecordTime;
                mysql.Insert(Value, RecordTime);
            }
            */

            new paging_listshow().Show();

            textBox1.Text = mysql.ReadMax().ToString();
            textBox2.Text = mysql.ReadMin().ToString();
        }


        //点击停止光照检测则关闭表格窗口
        public static Window fm = null;
        private void button2_Click(object sender, EventArgs e)
        {
            if (fm == null)
            {
                paging_listshow p_l = new paging_listshow();
                p_l.Show();
            }
            else
            {
                fm.Hide();
                fm = null;
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            new caidan().Show(); //返回到菜单界面
            this.Hide(); //关闭当前的窗口
        }

    }
}
