using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data;
using Newtonsoft.Json;
using System.Collections;
using System.Windows.Threading;

namespace 智能排队机
{
    /// <summary>
    /// menu.xaml 的交互逻辑
    /// </summary>
    public partial class menu : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public menu()
        {
            InitializeComponent();

            timer.Tick += new EventHandler(timer1_Tick);
            timer.Interval = TimeSpan.FromSeconds(5);   //设置刷新的间隔时间
        }

        //开始取号：给机器发送取号命令1，开始允许刷卡取号
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Public_Methods.Cmds(113436, "bool_work",1);
        }

        //暂停取号：发送暂停取号命令0，不再允许刷卡取号
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Public_Methods.Cmds(113436, "bool_work", 0);
        }

        //叫号：发送叫号命令给排队人数执行器-1，排队机对排队人数进行减1操作
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Public_Methods.Cmds(113436, "number_down", 1);
        }

        //发送消息：向排队机发送“文本框”内的文本信息，智能排队机收到后，开始语音播报
        //点击发送按钮后，要判断文本框内容是否为空，并有成功和失败提示
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Trim().Length != 0)
            {
                string content = textBox.Text;
                Public_Methods.qry = Public_Class.SDK.Cmds(113436, "string_play	", content, Public_Class.Token);
                if (Public_Methods.qry.IsSuccess())
                {
                    System.Windows.MessageBox.Show("发送成功！");
                }
                else System.Windows.MessageBox.Show("云平台发送失败！");
            }
            else System.Windows.MessageBox.Show("文本框内容为空，发送失败！");
            
        }

        //绘制折线图部分
        SensorDataObject.Root datas;
        

        //每5s获取一次数据，即可5s更新一次折线图
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Json数据的格式处理方式
            JsonSerializerSettings setting = Public_Methods.JsonVert();


            //模糊查询设备最新10条数据
            Public_Methods.Fuzzy_QuerySensorData(113436, "number_up", "2020-07-30 19:42:08");
            //解析json数据
            String Jsondata = Public_Methods.SerializeToJson(Public_Methods.qry); //序列化
            datas = JsonConvert.DeserializeObject<SensorDataObject.Root>(Jsondata, setting); //反序列化
            this.chart1.Series[0].Points.Clear(); //先清除原先的折线图
            chart_update(); //不断更新图表


            
            Public_Class.deviceId = 113436;
            Public_Class.devIds = Public_Class.deviceId.ToString();
            //批量查询设备的最新数据.
            Public_Methods.Device_NewDataSearch();
            //解析json数据
            String Jsondata1 = Public_Methods.SerializeToJson(Public_Methods.qry); //序列化
            PaiDuiJiObject.Root paiduiji = JsonConvert.DeserializeObject<PaiDuiJiObject.Root>(Jsondata1, setting); //反序列化
            textBox1.Text = paiduiji.ResultObj[0].Datas[0].Value.ToString();
            
        }

        private void chart_update()
        {
            //设置图表的数据源
            DataTable dt = default(DataTable);
            dt = CreateDataTable(); //利用新查询到的数据创建表格
            chart1.DataSource = dt;

            //设置图表Y轴对应项
            chart1.Series[0].YValueMembers = "排队人数";

            //设置图标X轴对应项
            chart1.Series[0].XValueMember = "记录时间";

            //绑定数据
            chart1.DataBind();
        }

        private void chart_set()
        {
            /////////////////////ChartAreal属性设置////////////////////
            ChartArea ChartArea1 = new ChartArea("ChartArea1");
            this.chart1.ChartAreas.Add(ChartArea1);
            //设置坐标轴的名称
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "记录时间";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "排队人数";

            //启用3D显示
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;

            ///////////////Series属性设置/////////////////////////
            chart1.Series.Add("排队人数");
            //设置显示类型-线形
            chart1.Series["排队人数"].ChartType = SeriesChartType.Line;
            //设置坐标轴Value显示类型
            chart1.Series["排队人数"].XValueType = ChartValueType.Time;
            //是否显示标签的数值
            chart1.Series["排队人数"].IsValueShownAsLabel = true;

            //设置标记图案
            chart1.Series["排队人数"].MarkerStyle = MarkerStyle.Square;
            //设置图案的宽度
            chart1.Series["排队人数"].BorderWidth = 3;


            SetChartAutoBar(chart1);
            
        }

        private void SetChartAutoBar(Chart chart)
        {
            //设置游标
            chart.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart.ChartAreas[0].CursorX.AutoScroll = true;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //设置X轴是否可以缩放
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            //将滚动内嵌到坐标轴中
            chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            // 设置滚动条的大小
            chart.ChartAreas[0].AxisX.ScrollBar.Size = 10;
            // 设置滚动条的按钮的风格，下面代码是将所有滚动条上的按钮都显示出来
            chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            // 设置自动放大与缩小的最小量
            chart.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
            chart.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;
        }

        private DataTable CreateDataTable()
        {
            //1.创建一个表格dt
            DataTable dt = new DataTable();
            //2.添加columns
            dt.Columns.Add("记录时间");
            dt.Columns.Add("排队人数");

            DataRow dr;

            //3.给表添加rows
            for (int i = 0; i < 30; i++)
            {
                dr = dt.NewRow();
                dr["记录时间"] = datas.ResultObj.DataPoints[0].PointDTO[i].RecordTime;
                dr["排队人数"] = datas.ResultObj.DataPoints[0].PointDTO[i].Value;
                //dr["记录时间"] = 30+i;
                //dr["排队人数"] = i;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// 历史流量折线图鼠标滚动 滚动条对应滑动 最小及最大数据位置停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chart_HistoryFlow_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            //按住Ctrl，缩放
            if ((System.Windows.Forms.Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (e.Delta < 0)
                    chart1.ChartAreas[0].AxisX.ScaleView.Size += 4;
                else
                    chart1.ChartAreas[0].AxisX.ScaleView.Size -= 4;
            }
            //不按Ctrl，滚动
            else
            {
                if (e.Delta < 0)
                {
                    //当前位置+视图长大于最大数据时停止
                    if (chart1.ChartAreas[0].AxisX.ScaleView.Position + chart1.ChartAreas[0].AxisX.ScaleView.Size < chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum)
                        chart1.ChartAreas[0].AxisX.ScaleView.Position += 4;
                }
                else
                {
                    //当前位置小于最小数据时停止
                    if (chart1.ChartAreas[0].AxisX.ScaleView.Position > chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum)
                        chart1.ChartAreas[0].AxisX.ScaleView.Position -= 4;
                }

            }
        }

        /// <summary>
        /// 鼠标光标移到处，折线图光标显示详细数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chart_HistoryFlow_GetToolTipText(object sender, System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable = CreateDataTable();

            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                this.Cursor = System.Windows.Input.Cursors.Cross;
                int i = e.HitTestResult.PointIndex;
                string time = dataTable.Rows[i]["记录时间"].ToString();
                string value = dataTable.Rows[i]["排队人数"].ToString();
                e.Text = $"时  间：{time}\r\n排队人数：{value}";
            }
            else
            {
                this.Cursor = System.Windows.Input.Cursors.Arrow;
            }
        }


        //导出图表数据：将图表上的数据保存到“桌面”名为“chartData.txt”文件
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("正在导出图表数据！");
            FileStream fs = File.Open("C:\\Users\\Administrator\\Desktop\\Chartdata.txt", FileMode.Create);
            // 创建写入流
            StreamWriter wr = new StreamWriter(fs);
            // 将ArrayList中的每个项逐一写入文件
            for (int i = 0; i < 10; i++)
            {
                wr.WriteLine(datas.ResultObj.DataPoints[0].PointDTO[i].RecordTime);
                wr.WriteLine(datas.ResultObj.DataPoints[0].PointDTO[i].Value);
            }
            // 关闭写入流
            wr.Flush();
            wr.Close();

            // 关闭文件
            fs.Close();
            System.Windows.MessageBox.Show("导出成功！");

        }

        //导入图表数据：打开并修改“chartData.txt”文件中的第一个数据，点击此按钮，能把改动后的数据恢复到图标上
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            
            timer.Stop();
            StreamReader objReader = new StreamReader("C:\\Users\\Administrator\\Desktop\\chartdata.txt");
            string sLine = "";
            ArrayList arrText = new ArrayList();
            ArrayList x1 = new ArrayList();
            ArrayList y1 = new ArrayList();

            x1.Capacity = 10;
            y1.Capacity = 10;
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            objReader.Close();
            for (int i = 0; i < arrText.Count; i++)
            {
                if (i % 2 == 0)
                {
                    x1.Add(arrText[i]);
                }
                else if (i % 2 == 1)
                {
                    y1.Add(arrText[i]);
                }
            }
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.DataBindXY(x1, y1);
            timer.Start();
            
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
                      
            //Json数据的格式处理方式
            JsonSerializerSettings setting = Public_Methods.JsonVert();
            //模糊查询设备最新30条数据
            Public_Methods.Fuzzy_QuerySensorData(113436, "number_up", "2020-07-30 19:42:08");
            //解析json数据
            String Jsondata = Public_Methods.SerializeToJson(Public_Methods.qry); //序列化
            datas = JsonConvert.DeserializeObject<SensorDataObject.Root>(Jsondata, setting); //反序列化          
            chart_set();
            chart_update();


           
            Public_Class.deviceId = 113436;
            Public_Class.devIds = Public_Class.deviceId.ToString();
            //批量查询设备的最新数据.
            Public_Methods.Device_NewDataSearch();
            //解析json数据
            String Jsondata1 = Public_Methods.SerializeToJson(Public_Methods.qry); //序列化
            PaiDuiJiObject.Root paiduiji = JsonConvert.DeserializeObject<PaiDuiJiObject.Root>(Jsondata1, setting); //反序列化
            textBox1.Text = paiduiji.ResultObj[0].Datas[0].Value.ToString();

            timer.Start();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            new caidan().Show(); //返回到菜单界面
            this.Hide(); //关闭当前的窗口
        }
    }
}
