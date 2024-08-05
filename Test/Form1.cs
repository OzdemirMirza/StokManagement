using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Test
{
    public partial class Form1 : Form
    {
        FormEkle form;
        FormLogs formLogs;
        


        public Form1()
        {
            InitializeComponent();
            
            form=new FormEkle(this);
            lblUser.Text = UserLogin.name;
            dataGridView.RowPrePaint += dataGridView_RowPrePaint;
            this.FormClosed += Form1_FormClosed;



        }
        

        public void Display()
        {
            DbStock.DisplayAndSearch("SELECT * FROM Hücre;", dataGridView);
        }
        
       

        private void btnNew_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.SaveInfo();
            form.ShowDialog();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbStock.DisplayAndSearch("SELECT * FROM Hücre WHERE Name LIKE '%" +txtSearch.Text+ "%'", dataGridView);

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                // Düzenle
                form.Clear();
                form.id=dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.marka= dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.name= dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.sipn= dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.mik= dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.birim= dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                form.birimf= dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                form.topfi= dataGridView.Rows[e.RowIndex].Cells[9].Value.ToString();
                form.term= dataGridView.Rows[e.RowIndex].Cells[10].Value.ToString();
                form.acik= dataGridView.Rows[e.RowIndex].Cells[11].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();

                return;
            }
            if (e.ColumnIndex == 1) 
            {
                //Sil
                if(MessageBox.Show("Do you want to delete this record?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbStock.DeleteStock(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    LogProb logProb = new LogProb(form.name = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString(), "Silindi", form.marka = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString(), UserLogin.name);
                    DbStock.LogFill(logProb);
                    Display();
                }
                return;
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
           formLogs = new FormLogs();
           formLogs.ShowDialog();
           
        }
        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0) // Çift satırları kontrol et
            {
                // Gri arka plan rengi ayarla
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                // Çift olmayan satırların arka plan rengini varsayılan yap
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = dataGridView.DefaultCellStyle.BackColor;
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Form1 kapanırken uygulamayı tamamen kapat
            Application.Exit();
        }










    }
}
