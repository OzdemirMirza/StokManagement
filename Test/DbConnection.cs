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
            string sql = "Server=77.245.159.14;Port=3306;Database=kadeyaco_STOK;User ID=kadeyaco_wp233;Password=(x8d)p3XSuM7-!(2;";
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
