using MySql.Data.MySqlClient;
using System;

namespace 智能排队机
{
    internal class MySqlCommand
    {
        private string sql;
        private MySqlConnection conn;
        

        public MySqlCommand(string sql, MySqlConnection conn)
        {
            this.sql = sql;
            this.conn = conn;
        }

    }
}