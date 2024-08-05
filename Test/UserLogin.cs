using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public  partial class UserLogin : Form
        
    {


        DbConnection conn=new DbConnection();

        Form1 form1;
        signUp signUp;

        public static string  name;

     
        
        public UserLogin()
        {
            InitializeComponent();



        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
          

            string username=txtID.Text;
            string password=txtPwd.Text;

                
                string sql = "SELECT Name FROM Admin WHERE UserName=@LogName AND Password=@LogPsw";

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlConnection con = conn.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@LogName", MySqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@LogPsw", MySqlDbType.VarChar).Value = password; 
          
                adapter.SelectCommand = cmd;
                adapter.Fill(table);

        

            if (table.Rows.Count > 0 && ((name = table.Rows[0]["Name"].ToString())!=null) )
            {


                // MessageBox.Show(name);

                form1 = new Form1();

                // FormClosing olayını dinlemek için Form1_FormClosing metodunu ekleyin
                form1.FormClosing += Form1_FormClosing;

                this.Hide();
                form1.ShowDialog();

            }
            else 
            {
                MessageBox.Show("Login Failed");
                
            }
            
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signUp =new signUp();
            signUp.ShowDialog();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Eğer olaya abone olan birisi varsa, olayı tetikle
            FormClosedByUser?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler FormClosedByUser;
    }
}
