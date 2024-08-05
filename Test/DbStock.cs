using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    internal class DbStock
    {
        public static DbConnection db=new DbConnection();

      

        public static void AddStock(StockProp stcprb)
        {
            
            string sql = "INSERT INTO Hücre VALUES (NULL,@StokMarka,@StokAd,@StokSip,@StokMiktar,@StokBirim,@StokBirimFiyat,@StokToplamFiyat,@StokTermin,@StokAciklama)";
            MySqlConnection con = db.GetConnection();           
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType=CommandType.Text;
            cmd.Parameters.Add("@StokMarka", MySqlDbType.VarChar).Value = stcprb.Marka;
            cmd.Parameters.Add("@StokAd", MySqlDbType.VarChar).Value = stcprb.Name;
            cmd.Parameters.Add("@StokSip", MySqlDbType.VarChar).Value = stcprb.SipNO;
            cmd.Parameters.Add("@StokMiktar", MySqlDbType.VarChar).Value = stcprb.Miktar;
            cmd.Parameters.Add("@StokBirim", MySqlDbType.VarChar).Value = stcprb.Birim;
            cmd.Parameters.Add("@StokBirimFiyat", MySqlDbType.VarChar).Value = stcprb.BirimFiyat;
            cmd.Parameters.Add("@StokToplamFiyat", MySqlDbType.VarChar).Value = stcprb.ToplamFiyat;
            cmd.Parameters.Add("@StokTermin", MySqlDbType.VarChar).Value = stcprb.Termin;
            cmd.Parameters.Add("@StokAciklama", MySqlDbType.VarChar).Value = stcprb.Açıklama;


            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("Eklendi \n " , "Information",MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Eklenmedi \n " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }

        public static void UpdateStock(StockProp stcprb,string id)
        {
            string sql = "UPDATE Hücre SET Marka=@SMarka,Name=@SName,SiparisNo=@SipNo,Miktar=@SMiktar,Birim=@SBirim,BirimFiyat=@SBfiyat,ToplamFiyat=@STfiyat,Termin=@STermin,Aciklama=@SAciklama WHERE ID=@StockID";
            MySqlConnection con = db.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StockID", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@SMarka", MySqlDbType.VarChar).Value = stcprb.Marka;
            cmd.Parameters.Add("@SName", MySqlDbType.VarChar).Value = stcprb.Name;
            cmd.Parameters.Add("@SipNO", MySqlDbType.VarChar).Value = stcprb.SipNO;
            cmd.Parameters.Add("@SMiktar", MySqlDbType.VarChar).Value = stcprb.Miktar;
            cmd.Parameters.Add("@SBirim", MySqlDbType.VarChar).Value = stcprb.Birim;
            cmd.Parameters.Add("@SBfiyat", MySqlDbType.VarChar).Value = stcprb.BirimFiyat;
            cmd.Parameters.Add("@STfiyat", MySqlDbType.VarChar).Value = stcprb.ToplamFiyat;
            cmd.Parameters.Add("@STermin", MySqlDbType.VarChar).Value = stcprb.Termin;
            cmd.Parameters.Add("@SAciklama", MySqlDbType.VarChar).Value = stcprb.Açıklama;
            

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Güncellendi \n ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Güncellenmedi \n " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }

        public static void DeleteStock(string id)
        {
            string sql = "DELETE FROM Hücre WHERE ID=@StockID";
            MySqlConnection con = db.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("StockID",MySqlDbType.VarChar).Value=id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Silindi \n ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Silinmedi \n " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }

        public static void DisplayAndSearch(string query,DataGridView dataGridView)
        {
            string sql=query;
            MySqlConnection con = db.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView.DataSource = tbl;
            con.Close();
        
        }

        public static void LogFill(LogProb logProb)
        {
            string sql = "INSERT INTO LogTable VALUES (NULL,@name,@marka,@kisi,@durum,NULL)";
            MySqlConnection con = db.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = logProb.Name;
            cmd.Parameters.Add("@marka", MySqlDbType.VarChar).Value = logProb.Marka;
            cmd.Parameters.Add("@kisi", MySqlDbType.VarChar).Value = logProb.Kisi;
            cmd.Parameters.Add("@durum", MySqlDbType.VarChar).Value = logProb.Durum;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void SignUp(UserProb userProb)
        {
            string sql = "INSERT INTO Admin VALUES (NULL,@name,@password,@username)";
            MySqlConnection con = db.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = userProb.Name;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = userProb.UserName;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = userProb.Password;
            
            cmd.ExecuteNonQuery();
            con.Close();
        }





    }
}
