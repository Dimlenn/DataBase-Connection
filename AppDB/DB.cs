using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace AppDB
{
    internal class DB
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=hotel");

        public void OpenConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }
        public void CloseConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }
        public MySqlConnection GetConnection()
        { 
            return conn;
        }
    }
}
