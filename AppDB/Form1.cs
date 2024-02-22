using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            
            MySqlCommand select = new MySqlCommand("SELECT * FROM residents", db.GetConnection());

            adapter.SelectCommand = select;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                int count = 0;
                foreach (DataRow row in table.Rows) 
                {
                    count++;
                }
                richTextBox1.Text = count.ToString();
            }
            else
            {
                richTextBox1.Text = "Ничего не найдено";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlCommand insertRes = new MySqlCommand("INSERT INTO residents (`Номер пропуска`, `ФИО`, `Номер`) VALUES (@passnum, @name, @roomnum)", db.GetConnection());

            insertRes.Parameters.Add("@passnum", MySqlDbType.Int24).Value = 777;
            insertRes.Parameters.Add("@name", MySqlDbType.VarChar).Value = "Меленцов Дмитрий Андреевич";
            insertRes.Parameters.Add("@roomnum", MySqlDbType.Int32).Value = 6;

            db.OpenConnection();

            if (insertRes.ExecuteNonQuery() == 1)
            {
                richTextBox1.Text = "Добавление выполнено успешно";
            }
            else
            {
                richTextBox1.Text = "Добавление не выполнено";
            }

            db.CloseConnection();
        }
    }
}
