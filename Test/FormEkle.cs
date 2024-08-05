using K4os.Compression.LZ4.Encoders;
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
    public partial class FormEkle : Form
    {

       private readonly Form1 _parent;
       public string id, marka, name, sipn, mik, birim, birimf, topfi, term, acik;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public FormEkle(Form1 Parent)
        {
            InitializeComponent();
            _parent = Parent;
            
        }
        
        public void UpdateInfo()
        {
            lblText.Text = "Stok Düzenle";
            btnSave.Text = "Düzenle";
            txtBirim.Text = birim;
            txtBirimFiyat.Text = birimf;
            txtMarka.Text = marka;
            txtName.Text = name;
            txtSiparisNo.Text = sipn;
            txtToplamFiyat.Text = topfi;
            TxtTermin.Text = term;
            TxtAçıklama.Text = acik;
            txtMiktar.Text = mik;
        }
        public void SaveInfo()
        {
            lblText.Text = "Stok Ekle";
            btnSave.Text = "Kaydet";

        }


        public void Clear()
        {
            txtMarka.Text = txtName.Text = txtBirim.Text = txtBirimFiyat.Text = txtMiktar.Text = txtSiparisNo.Text = txtToplamFiyat.Text = TxtTermin.Text = TxtAçıklama.Text = string.Empty;
        }
        
        




        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Name not entered");
                
                return;                

            }
            if (txtMarka.Text.Trim().Length < 1)
            {
                MessageBox.Show("Brand not entered");
                return;
            }
            if (txtSiparisNo.Text.Trim().Length < 1)
            {
                MessageBox.Show("Unit not entered");
                return;
            }
            if (txtBirimFiyat.Text.Trim().Length < 1)
            {
                MessageBox.Show("Unit Price not entered");
                return;
            }
            if (!decimal.TryParse(txtBirimFiyat.Text.Trim(), out _))
            {
                MessageBox.Show("Please enter a valid number for Unit Price.");
                return;
            }
            if (!decimal.TryParse(txtMiktar.Text.Trim(), out _))
            {
                MessageBox.Show("Please enter a valid number for unit.");
                return;
            }
            if (btnSave.Text =="Kaydet")
            {
                StockProp stockProp=new StockProp(txtName.Text.Trim(),txtMarka.Text.Trim(),txtSiparisNo.Text.Trim(),txtMiktar.Text.Trim(),txtBirim.Text.Trim(),txtBirimFiyat.Text.Trim(),txtToplamFiyat.Text.Trim(),TxtTermin.Text.Trim(),TxtAçıklama.Text.Trim());
                DbStock.AddStock(stockProp);
                LogProb logProb = new LogProb(txtName.Text.Trim(),"Kaydedildi", txtMarka.Text.Trim(), UserLogin.name);
                DbStock.LogFill(logProb);               
                Clear();
                this.Hide();
            }
            if (btnSave.Text == "Düzenle")
            {
                StockProp stockProp = new StockProp(txtName.Text.Trim(), txtMarka.Text.Trim(), txtSiparisNo.Text.Trim(), txtMiktar.Text.Trim(), txtBirim.Text.Trim(), txtBirimFiyat.Text.Trim(), txtToplamFiyat.Text.Trim(), TxtTermin.Text.Trim(), TxtAçıklama.Text.Trim());
                DbStock.UpdateStock(stockProp,id);
                LogProb logProb = new LogProb(txtName.Text.Trim(), "Güncellendi", txtMarka.Text.Trim(), UserLogin.name);
                DbStock.LogFill(logProb);

            }          
            _parent.Display();
            
            

        }

    }
}
