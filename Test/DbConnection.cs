using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    internal class DbConnection
    {
        public  MySqlConnection GetConnection()
        {
            string sql = "";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                
                con.Open();
                

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySqlConnection! \n " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return con;

        }


    }
}
