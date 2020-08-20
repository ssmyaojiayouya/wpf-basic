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
    /// caidan.xaml 的交互逻辑
    /// </summary>
    public partial class caidan : Window
    {
        public caidan()
        {
            InitializeComponent();
        }

        //智能排队机
        private void button_Click(object sender, RoutedEventArgs e)
        {
            new menu().Show(); //返回到菜单界面
            this.Hide(); //关闭当前的窗口
        }

        //光照检测表格
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            new Form2().Show(); //返回到菜单界面
            this.Hide(); //关闭当前的窗口
        }

        //舵机控制
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            new Slider().Show(); //返回到菜单界面
            this.Hide(); //关闭当前的窗口
        }
    }
}
