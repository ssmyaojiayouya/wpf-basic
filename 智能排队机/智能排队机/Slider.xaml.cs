using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace 智能排队机
{
    /// <summary>
    /// Slider.xaml 的交互逻辑
    /// </summary>
    public partial class Slider : Window
    {
        public Slider()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            new caidan().Show(); //返回到菜单界面
            this.Hide(); //关闭当前的窗口
        }

        //水平角度
        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int a;
            a = (byte)slider1.Value;
            

            //给云平台发送改变的控制信息（a就是拖动的数据）
            var qry = Public_Class.SDK.Cmds(112605, "HorizontalAngleCtrl", a, Public_Class.Token);
            textBox1.Text = a.ToString(); //显示出当前数据
        }

        //垂直角度
        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int b;
            b = (byte)slider2.Value;


            //给云平台发送改变的控制信息（a就是拖动的数据）
            var qry = Public_Class.SDK.Cmds(112605, "VerticalAngleCtrl", b, Public_Class.Token);
            textBox2.Text = b.ToString(); //显示出当前数据
        }


    }
}
