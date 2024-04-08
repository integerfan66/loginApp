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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace loginApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        SqlConnection connect;
        private void Form1_Load(object sender, EventArgs e)
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
            {
                connect.Open();

                string query = "SELECT COUNT(*) FROM users WHERE userName = @Username AND userPass = @Password";

                SqlCommand command = new SqlCommand(query, connect);

                // Set parameter values for the SELECT query
                command.Parameters.AddWithValue("@Username", textBox1.Text);
                command.Parameters.AddWithValue("@Password", textBox2.Text);

                // Execute the SELECT query
                int count = (int)command.ExecuteScalar();

                // Check if there are any matching accounts
                if (count > 0)
                {
                    // Close the first command before creating a new one
                    command.Dispose();

                    query = "UPDATE users SET lastLoginDate = @lastLogin WHERE userName = @Username";

                    // Create a new command for the UPDATE query
                    command = new SqlCommand(query, connect);

                    // Set parameter values for the UPDATE query
                    command.Parameters.AddWithValue("@Username", textBox1.Text);
                    command.Parameters.AddWithValue("@lastLogin", DateTime.Now);

                    // Execute the UPDATE query
                    int rowsAffected = command.ExecuteNonQuery();

                    command.Dispose();
                    query = "SELECT COUNT(*) FROM users WHERE userName = @Username AND userAccess = 'True'";
                    command = new SqlCommand(query, connect);
                    command.Parameters.AddWithValue("@Username", textBox1.Text);
                    int userCount = (int)command.ExecuteScalar();

                    if (rowsAffected > 0)
                    {
                        // Update successful
                            Form3 form3 = new Form3(userCount);
                            this.Hide();
                            form3.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update last login date.");
                    }
                }
                else
                {
                    MessageBox.Show("Hesap bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.Close();
            }
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
            if (!char.IsLetter(e.KeyChar) &&!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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
                // Manually trigger button1_Click event
                button1_Click(sender, e);
                e.Handled = true; // Prevent default behavior of Enter key (e.g., triggering button clicks)
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
