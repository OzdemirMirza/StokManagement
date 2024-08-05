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
    public partial class FormLogs : Form
    {
        public FormLogs()
        {
            InitializeComponent();
            dataGridView1.RowPrePaint += DataGridView1_RowPrePaint;

        }

        public void Display()
        {
            DbStock.DisplayAndSearch("SELECT * FROM LogTable;", dataGridView1);
        }

        private void FormLogs_Shown(object sender, EventArgs e)
        {
            Display();
        }

       

        

       private void DataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
      {
        // Satırın arka plan rengini değiştirelim
        // Örneğin, tek satırları mavi, çift satırları yeşil yapalım
       
            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.Equals("Güncellendi"))
       
            {
                dataGridView1.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.DarkOrange;
       
            }
       
            else if(dataGridView1.Rows[e.RowIndex].Cells[4].Value.Equals("Kaydedildi"))
       
            {
            dataGridView1.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.DarkGreen;
       
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.DarkRed;

            }

      }

        
    }
}
