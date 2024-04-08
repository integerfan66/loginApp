using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace loginApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.FormClosed += Form2_FormClosed;
        }
        SqlConnection connect;
        private void Form2_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection("Data Source=DESKTOP-A36V29R\\SQLEXPRESS;Initial Catalog=LoginDB;Integrated Security=True;");
            this.BeginInvoke((Action)(() =>
            {
                textBox1.Focus();
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {   if(textBox2.Text == textBox3.Text)
                {
                    if(textBox2.TextLength == 8)
                    {
                        connect.Open();
                        string query = "INSERT INTO users values(@userName,@userPass,@userAccess,@lastLogin)";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@userName", textBox1.Text);
                        cmd.Parameters.AddWithValue("@userPass", textBox2.Text);
                        cmd.Parameters.AddWithValue("@userAccess", 0);
                        cmd.Parameters.AddWithValue("@lastLogin", DateTime.Now);
                        cmd.ExecuteNonQuery();
                        Form1 form1 = new Form1();
                        this.Hide();
                        form1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Şifre 8 karakterli olmalıdır.");
                    }
                    

                }
                else
                {
                    MessageBox.Show("Şifrelerin birbirine uyuştuğuna emin olunuz.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { connect.Close(); }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Suppress the key press event
                e.Handled = true;
                MessageBox.Show("Özel karakter girmeyiniz.");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Özel karakter girmeyiniz.");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Özel karakter girmeyiniz.");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                e.Handled = true; // Prevent default behavior of Enter key (e.g., triggering button clicks)
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
                e.Handled = true; // Prevent default behavior of Enter key (e.g., triggering button clicks)
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Manually trigger button1_Click event
                button1_Click(sender, e);
                e.Handled = true; // Prevent default behavior of Enter key (e.g., triggering button clicks)
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
