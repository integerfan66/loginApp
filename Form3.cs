using System;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace loginApp
{
    public partial class Form3 : Form
    {
        public Form3(int ReceivedData)
        {
            InitializeComponent();
            this.FormClosed += Form3_FormClosed;
            if(ReceivedData != 0)
            {
                EnableObjectsMethod();
            }
            
        }
        SqlConnection connect;

        private void Form3_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection("Data Source=DESKTOP-A36V29R\\SQLEXPRESS;Initial Catalog=LoginDB;Integrated Security=True;");
            try
            {
                connect.Open();
                string query = "SELECT catName FROM categories";
                SqlCommand cmd = new SqlCommand(query, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                listBox1.Items.Clear();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader[0].ToString());
                }
                listBox1.Items.Add("Tüm ögeleri göster");
                cmd.Dispose();
                reader.Close();
                query = "SELECT proName, proPrice FROM products";
                cmd = new SqlCommand(query, connect);
                reader = cmd.ExecuteReader();
                listBox2.Items.Clear();
                while (reader.Read()) {
                    listBox2.Items.Add(reader[0].ToString() + "\t" + reader[1].ToString());
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally { connect.Close(); }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                if (listBox1.SelectedIndex != listBox1.Items.Count - 1)
                {
                    string query = "SELECT proName, proPrice FROM products WHERE catID = @catID";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@catID", listBox1.SelectedIndex);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox2.Items.Clear();
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader[0].ToString() + "\t" + reader[1].ToString());
                    }
                }
                else
                {
                    string query = "SELECT proName, proPrice FROM products";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox2.Items.Clear();
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader[0].ToString() + "\t" + reader[1].ToString());
                    }
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

        private void button1_Click(object sender, EventArgs e)
        {
            //artarak
            Ascending();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //azalarak
            Descending();
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MinMaxPrice();
        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            MinMaxPrice();
        }

        public void MinMaxPrice()
        {
            try
            {
                connect.Open();
                if (listBox1.SelectedIndex != listBox1.Items.Count - 1)
                {
                    if (textBox1.Text != "" && textBox2.Text == "")
                    {
                        string query = "SELECT proName, proPrice FROM products WHERE catID = @catID AND proPrice >= @minPrice ";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@minPrice", textBox1.Text);
                        cmd.Parameters.AddWithValue("@catID", listBox1.SelectedIndex);
                        SqlDataReader reader = cmd.ExecuteReader();
                        listBox2.Items.Clear();
                        while (reader.Read())
                        {
                            listBox2.Items.Add(reader[0].ToString() + "\t" + reader[1].ToString());
                        }
                    }
                    else if (textBox1.Text == "" && textBox2.Text != "")
                    {
                        string query = "SELECT proName, proPrice FROM products WHERE catID = @catID AND proPrice >= @minPrice ";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@maxPrice", textBox2.Text);
                        cmd.Parameters.AddWithValue("@catID", listBox1.SelectedIndex);
                        SqlDataReader reader = cmd.ExecuteReader();
                        listBox2.Items.Clear();
                        while (reader.Read())
                        {
                            listBox2.Items.Add(reader[0].ToString() + "\t" + reader[1].ToString());
                        }
                    }
                    else
                    {
                        string query = "SELECT proName, proPrice FROM products WHERE catID = @catID AND proPrice >= @minPrice AND proPrice <= @maxPrice";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@minPrice", textBox1.Text);
                        cmd.Parameters.AddWithValue("@maxPrice", textBox2.Text);
                        cmd.Parameters.AddWithValue("@catID", listBox1.SelectedIndex);
                        SqlDataReader reader = cmd.ExecuteReader();
                        listBox2.Items.Clear();
                        while (reader.Read())
                        {
                            listBox2.Items.Add(reader[0].ToString() + "\t" + reader[1].ToString());
                        }
                    }


                }
                else
                {
                    if (textBox1.Text != "" && textBox2.Text == "")
                    {
                        string query = "SELECT proName, proPrice FROM products WHERE proPrice >= @minPrice ";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@minPrice", textBox1.Text);
                        SqlDataReader reader = cmd.ExecuteReader();
                        listBox2.Items.Clear();
                        while (reader.Read())
                        {
                            listBox2.Items.Add(reader[0].ToString() + "\t" + reader[1].ToString());
                        }
                    }
                    else if (textBox1.Text == "" && textBox2.Text != "")
                    {
                        string query = "SELECT proName, proPrice FROM products WHERE proPrice >= @maxPrice ";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@maxPrice", textBox2.Text);
                        SqlDataReader reader = cmd.ExecuteReader();
                        listBox2.Items.Clear();
                        while (reader.Read())
                        {
                            listBox2.Items.Add(reader[0].ToString() + "\t" + reader[1].ToString());
                        }
                    }
                    else
                    {
                        string query = "SELECT proName, proPrice FROM products WHERE proPrice >= @minPrice AND proPrice <= @maxPrice";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@minPrice", textBox1.Text);
                        cmd.Parameters.AddWithValue("@maxPrice", textBox2.Text);
                        SqlDataReader reader = cmd.ExecuteReader();
                        listBox2.Items.Clear();
                        while (reader.Read())
                        {
                            listBox2.Items.Add(reader[0].ToString() + "\t" + reader[1].ToString());
                        }
                    }
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

        public void Ascending()
        {
            try
            {
                connect.Open();
                if (listBox1.SelectedIndex != listBox1.Items.Count - 1)
                {
                    string query = "SELECT proName, proPrice FROM products WHERE catID = @catID ORDER BY proPrice ASC";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@catID", listBox1.SelectedIndex);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox2.Items.Clear();
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader[0].ToString() + "\t" + reader[1].ToString());
                    }

                }
                else
                {
                    string query = "SELECT proName, proPrice FROM products ORDER BY proPrice ASC";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox2.Items.Clear();
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader[0].ToString() + "\t" + reader[1].ToString());
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally { connect.Close(); }
        }

        public void Descending()
        {
            try
            {
                connect.Open();
                if (listBox1.SelectedIndex != listBox1.Items.Count - 1)
                {
                    string query = "SELECT proName, proPrice FROM products WHERE catID = @catID ORDER BY proPrice DESC";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@catID", listBox1.SelectedIndex);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox2.Items.Clear();
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader[0].ToString() + "\t" + reader[1].ToString());
                    }

                }
                else
                {
                    string query = "SELECT proName, proPrice FROM products ORDER BY proPrice DESC";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox2.Items.Clear();
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader[0].ToString() + "\t" + reader[1].ToString());
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally { connect.Close(); }
        }

        public void EnableObjectsMethod()
        {
            
            for(int i = 5; i<=14; i++)
            {
                Label existingLabel = this.Controls.Find("label" + i, true)[0] as Label;
                if (existingLabel != null)
                {
                    existingLabel.Enabled = true;
                    existingLabel.Visible = true;
                }
            }
            for(int i = 3; i <= 9; i++)
            {
                TextBox existingTextBox = this.Controls.Find("textBox" + i, true)[0] as TextBox;
                if (existingTextBox != null)
                {
                    existingTextBox.Enabled = true;
                    existingTextBox.Visible = true;
                }
            }
            for(int i=3; i<=5; i++)
            {
                Button existingButton = this.Controls.Find("button" + i, true)[0] as Button;
                if (existingButton != null)
                {
                    existingButton.Enabled = true;
                    existingButton.Visible = true;
                }
            }

            
        }
        /*
        public void ListCategories()
        {
            try
            {
                connect.Open();
                string query = "SELECT catName FROM categories";
                SqlCommand cmd = new SqlCommand(query, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                listBox1.Items.Clear();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader[0].ToString());
                }
                listBox1.Items.Add("Tüm ögeleri göster");
            }
            catch (Exception)
            {

                throw;
            }
            finally { connect.Close(); }
        }
        */
        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Boşlukları doldurunuz.");
            }
            else
            {
                try
                {
                    int categoryIndex;
                    connect.Open();
                    string query;
                    SqlCommand cmd;

                    
                    
                        if (!listBox1.Items.Contains(textBox5.Text))
                        {
                        query = "INSERT INTO categories VALUES(@catName)";
                        cmd = new SqlCommand(query, connect);
                        listBox1.Items.Add(textBox5.Text);
                            cmd.Parameters.AddWithValue("@catName", textBox5.Text);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        
                        
                      query = "SELECT catName FROM categories";
                    cmd = new SqlCommand(query, connect);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[0].ToString());
                    }
                    listBox1.Items.Add("Tüm öğeleri göster");
                    cmd.Dispose();
                    reader.Close();

                        
                    categoryIndex = listBox1.Items.IndexOf(textBox5.Text);
                    query = "INSERT INTO products VALUES(@proName,@proPrice,@catID)";
                    cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@proName", textBox3.Text);
                    cmd.Parameters.AddWithValue("@proPrice", textBox4.Text);
                    cmd.Parameters.AddWithValue("@catID", categoryIndex);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    query = "SELECT proName,proPrice FROM products";
                    cmd = new SqlCommand(query, connect);
                    reader = cmd.ExecuteReader();
                    listBox2.Items.Clear();
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader[0].ToString() + "\t" + reader[1].ToString());
                    }
                    
                    cmd.Dispose();
                    reader.Close();
                    

                }
                catch (Exception)
                {

                    throw;
                }
                finally { connect.Close(); }
                
                
                

                
            }
        }
    }
}
