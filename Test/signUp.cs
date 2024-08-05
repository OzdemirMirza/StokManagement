using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Test;
using System.Security.Principal;

namespace Test
{
    public partial class signUp : Form
    {
        public signUp()
        {
            InitializeComponent();
        }
        UserProb userProb;
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                 textBox3.UseSystemPasswordChar = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                textBox4.UseSystemPasswordChar = false;
            }
            else
            {
                textBox4.UseSystemPasswordChar = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("The username, name, and password cannot be empty");
            }
            else if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("The passwords do not match");
            }
            else
            {
                userProb = new UserProb(textBox1.Text, textBox3.Text, textBox2.Text);
                DbStock.SignUp(userProb);
                MessageBox.Show("Account saved");
                this.Close();
            }


        }

    }
}

