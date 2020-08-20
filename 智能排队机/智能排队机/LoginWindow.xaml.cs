using NLECloudSDK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static 智能排队机.Users;

namespace 智能排队机
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static String account;      //云平台登录帐号
        private static String password;          //云平台登录密码

        //就是创建了一个空集合，这个集合中的元素的键是string类型的，值是User类型的
        //User类型里面是存储用户的账号和密码的
        private Dictionary<string, User> dicUserInfo = new Dictionary<string, User>();

        public MainWindow()
        {
            InitializeComponent();
        }


        //登陆
        private void button_Click(object sender, RoutedEventArgs e)
        {
            /*1. 实例化一个SDK*/
            Public_Class.SDK = new NLECloudAPI(Public_Class.API_HOST);

            //获取用户输入的文本框中的账号密码以及是否记住密码 
            account = comboBox_account.Text.Trim();
            password = passwordBox_password.Password;

            /*2. 创建一个userdata文件存放用户账号密码数据，FileMode.OpenOrCreate创建文件*/
            User user = new User();

            // FileStream操作字节的，可以操作任何的文件,
            //而StreamReader类和StreamWriter类:操作字符的，只能操作文本文件。
            FileStream fs = new FileStream("userdata.bin", FileMode.Create);

            //（有时候需要将C#中某一个结构很复杂的类的对象存储起来，
            //或者通过网路传输到远程的客户端程序中去， 这时候用文件方式或者数据库方式存储或者传送就比较麻烦了，
            //这个时候，最好的办法就是使用串行和解串（Serialization & Deserialization).）其中BinaryFormattter最简单
            BinaryFormatter bf = new BinaryFormatter();

            /*3. 判断用户是否选择了记住密码，并且把相应的记录放入users集合中，
             *        并通过BinaryFormatter串行 放入文件中*/
            user.Username = account;

            if (checkBox.IsChecked == true) //如果单击了记住密码的功能
            {  //在文件中保存密码
                user.Password = password;
                user.Usercheck = true;
            }
            else
            {  //不在文件中保存密码
                user.Password = "";
                user.Usercheck = false;
            }

            //判断在集合中是否存在用户名
            if (dicUserInfo.ContainsKey(user.Username))
            { //集合中存在该用户名,则先把它移除
                dicUserInfo.Remove(user.Username);
            }
            dicUserInfo.Add(user.Username, user); //添加到用户集合中
            //串行放入文件中
            bf.Serialize(fs, dicUserInfo);
            fs.Close();

            /*4. 把文本框中获取到的内容 再给dto对象*/
            AccountLoginDTO dto = new AccountLoginDTO()
            {
                Account = account,
                Password = password,
            };

            /*5. 再把该对象传入UserLogin中*/
            dynamic qry = Public_Class.SDK.UserLogin(dto);

            if (this.comboBox_account.Text != "") //账号不为空
            {
                if (this.passwordBox_password.Password != "") //密码不为空
                {
                    //6.验证是否登陆成功，调用API获得访问令牌
                    if (qry.IsSuccess())
                    {
                        Public_Class.Token = qry.ResultObj.AccessToken; //登陆成功，获得一个访问令牌
                        new caidan().Show(); //7.登陆成功，跳转到另一个界面
                        this.Hide(); //关闭当前的登陆窗口
                    }

                    else
                    {
                        MessageBox.Show("账号或密码输入错误，请重新输入!!!!");
                        comboBox_account.Text = "";
                        passwordBox_password.Password = "";
                    }
                }

                else
                {
                    MessageBox.Show("密码为空，请输入密码！");
                }
            }
            else
            {
                MessageBox.Show("账号为空，请输入账号！");
            }
        }


        //注册
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("IExplore", "http://www.nlecloud.com/my/register");
        }

        private void ComBoBox_DropDownClosed1(object sender, EventArgs e)
        {
            //转成ComboBox类型。
            ComboBox mcb = sender as ComboBox;
            //如果
            if (mcb.Text != "")
            {
                if (dicUserInfo.ContainsKey(mcb.Text))                  
                {
                    //得到对象。
                    User rememberInfo = dicUserInfo[mcb.Text];
                    //如果对象有值。
                    if (rememberInfo != null)
                    {
                        //如果属性UserCheck为true，就让CheckBox的IsChecked设置为选中状态。
                        if (rememberInfo.Usercheck)
                        {
                            this.passwordBox_password.Password = rememberInfo.Password;
                            this.checkBox.IsChecked = true;
                        }
                        else
                        {
                            this.passwordBox_password.Password = string.Empty;
                            this.checkBox.IsChecked = false;
                        }
                    }
                }
            }
        }

        private void Login_Loaded(object sender, RoutedEventArgs e)
        {
   
            //此变量用于标志选中第一个用户名。
             bool drag = true;

            //读取配置文件寻找记住的用户名和密码
            FileStream fs = new FileStream("userdata.bin", FileMode.OpenOrCreate);

            //如果长度>0,就把集合中的用户名加过来。
            if (fs.Length > 0) //文件中有数据
            {
                BinaryFormatter bf = new BinaryFormatter(); //把对象转换成为二进制的工具函数
                //在这里要读出userdata.bin里的用户信息
                dicUserInfo = bf.Deserialize(fs) as Dictionary<string, User>;

                //循环添加到zhanghao_comboBox1中，呈现一个下拉列表的效果，可以看到先前登陆过的账号
                foreach (User item in dicUserInfo.Values)
                {
                    //将循环遍历得到的“用户名”加到comboBox_account中。
                    this.comboBox_account.Items.Add(item.Username);
                    //默认设置显示第一个用户名。
                    this.comboBox_account.SelectedIndex = 0;
               

                    if (this.comboBox_account.Text != "") //账号文本框中不为空
                    {
                        //如果当前用户UserCheck属性为True，就显示密码并设置checkBox的IsChecked属性为选中状态。
                        if (drag)
                        {
                            drag = false;
                            if (item.Usercheck) //并且存在与文件中（==dicUserInfo集合中）
                            {
                                this.passwordBox_password.Password = dicUserInfo[this.comboBox_account.Text].Password;
                                this.checkBox.IsChecked = true;
                            }
                        }
                    }

                }
            }
            fs.Close();
            
        }

        private void PsdKeyDown(object sender, KeyEventArgs e)
        {
            //当在密码框中按下回车键时，先判断是否密码输入，再进入登陆按键函数
            if (e.Key == Key.Return)
                button_Click(sender, e);
        }
    }
}
