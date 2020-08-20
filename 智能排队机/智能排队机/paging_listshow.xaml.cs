using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;


namespace 智能排队机
{
    /// <summary>
    /// paging_listshow.xaml 的交互逻辑
    /// </summary>
    public partial class paging_listshow : Window
    {
        static int TotalRows;
        //private int CurrentRows = 0;
        private int Pages = 0;

        public paging_listshow()
        {
            InitializeComponent();
        }

        private void ShowData(int i, int j)
        {
            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;database=test01;user=root;password=root;");
            connection.Open();
            try
            {          
                MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand("select * from test01_tb_light", connection);

                MySqlDataAdapter adp = new MySqlDataAdapter(command);
                DataSet ds = new DataSet();               
                adp.Fill(ds, i, j, "光照强度检测记录");
                this.dataGrid.ItemsSource = ds.Tables["光照强度检测记录"].DefaultView;
                connection.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            
        }


        //首页
        private void FirstPagBtn_Click(object sender, EventArgs e)
        {
            ShowData(0, 10);
            LblCurrentPage.Content = "1";
            ;
        }

        //上一页
        private void UpPagBtn_Click(object sender, EventArgs e)
        {
            if (LblCurrentPage.Content.ToString() == "1")
            {
                System.Windows.MessageBox.Show("当前已经为首页!");
            }
            else
            {
                LblCurrentPage.Content = (Convert.ToInt16(LblCurrentPage.Content) - 1).ToString();
                ShowData(((Convert.ToInt16(LblCurrentPage.Content)) - 1) * 10, 10);
            }
        }

        //下一页
        private void NextPagBtn_Click(object sender, EventArgs e)
        {
            if (LblCurrentPage.Content.ToString() == Pages.ToString())
            {
                System.Windows.MessageBox.Show("当前页面已经为最后一页了!");
            }
            else
            {
                LblCurrentPage.Content = (Convert.ToInt16(LblCurrentPage.Content) + 1).ToString();
                ShowData(((Convert.ToInt16(LblCurrentPage.Content)) - 1) * 10, 10);
            }
        }

        //尾页
        private void LastPagBtn_Click(object sender, EventArgs e)
        {
            ShowData((Pages - 1) * 10, 10);
            LblCurrentPage.Content = Pages.ToString();
        }


        private void paging_listshow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2.fm = null;
        }

        private void paging_listshow_Loaded(object sender, RoutedEventArgs e)
        {
            Form2.fm = this;
            string connectStr = "server=127.0.0.1;port=3306;database=test01;user=root;password=root;SslMode=none;";

            using (MySqlConnection connection = new MySqlConnection(connectStr))
            {
                connection.Open();
                string sql = "select * from test01_tb_light";//MySql语句，查询列表内容
                MySqlDataAdapter adp = new MySqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                TotalRows = dt.Rows.Count;  //rows代表“行”
                Pages = TotalRows % 10;
                if (Pages == 0)
                {
                    Pages = TotalRows / 10;  //每页十行，刚好分完
                }
                else
                {
                    Pages = TotalRows / 10 + 1;  //每页十行，还没分完，再加一页
                }

                Console.WriteLine("总共行数=" + TotalRows);
                LblTotalPage.Content = TotalRows.ToString();
                LblCurrentPage.Content = "1";

                connection.Close();
                ShowData(0, 10);
            }
        }




    }
}
