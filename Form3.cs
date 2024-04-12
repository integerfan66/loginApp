﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
            this.FormClosed += Form3_FormClosed; //lazım
            
            //eğer giren admin ise kontrölleri göster
            if(ReceivedData != 0)
            {
                EnableObjectsMethod();
            }
            
        }
        SqlConnection connect;

        private void Form3_Load(object sender, EventArgs e)
        {
            //yüklenince listele
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
            connect.Close();
            Application.Exit(); //lazım
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kategoriye göre ürün listeleme
            try
            {
                if(listBox1.SelectedItem != null)
                {
                    connect.Open();
                    if (listBox1.SelectedIndex != listBox1.Items.Count - 1)
                    {
                        string query = "SELECT proName, proPrice FROM products WHERE catID = @catID";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@catID", GetCategoryIndexCat(listBox1.SelectedItem.ToString()));
                        SqlDataReader reader = cmd.ExecuteReader();
                        listBox2.Items.Clear();
                        while (reader.Read())
                        {
                            listBox2.Items.Add(reader[0].ToString() + "\t" + reader[1].ToString());
                        }
                        textBox10.Text = listBox1.SelectedItem.ToString();
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
            //adı üstünde, iki fiyat arasında ürün araması yapmak için
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
            //ürünleri fiyatına göre artarak listele
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
            //ürünleri fiyatına göre azalarak listele
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
            //eğer giriş yapan admin ise kontrölleri göster
            //(karşılaştırma kısmı form3_load'da ((eğer görmediysen)
            for (int i = 5; i<=16; i++)
            {
                Label existingLabel = this.Controls.Find("label" + i, true)[0] as Label;
                if (existingLabel != null)
                {
                    existingLabel.Enabled = true;
                    existingLabel.Visible = true;
                }
            }
            for(int i = 3; i <= 10; i++)
            {
                TextBox existingTextBox = this.Controls.Find("textBox" + i, true)[0] as TextBox;
                if (existingTextBox != null)
                {
                    existingTextBox.Enabled = true;
                    existingTextBox.Visible = true;
                }
            }
            for(int i=3; i<=6; i++)
            {
                Button existingButton = this.Controls.Find("button" + i, true)[0] as Button;
                if (existingButton != null)
                {
                    existingButton.Enabled = true;
                    existingButton.Visible = true;
                }
            }

            
        }

        public void ListProducts()
        {
            try
            {
                if (connect.State == ConnectionState.Closed) //!!!! önemli
                {
                    connect.Open();
                }

                string query = "SELECT proName, proPrice FROM products";
                SqlCommand cmd = new SqlCommand(query, connect);
                SqlDataReader reader = cmd.ExecuteReader();
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
            
            
        }
        
        public void ListCategories()
        {
            try
            {
                
                if (connect.State == ConnectionState.Closed) //!!!! bu da önemli
                {
                    connect.Open();
                }
                
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
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void UpdateInsertCategory()
        {
            try
            {
                if(connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                string query = "SELECT COUNT(*) FROM categories WHERE catName = @catName";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@catName", textBox9.Text);
                int catCount = (int)cmd.ExecuteScalar();
                cmd.Dispose();
                if (catCount == 0)
                {
                    query = "INSERT INTO categories VALUES(@catName)";
                    cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@catName", textBox9.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCategoryIndex(string inputName)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                string query = "SELECT catID FROM products WHERE proName = @proName";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@proName",inputName);
                int categoryId = (int)cmd.ExecuteScalar();
                cmd.Dispose();
                return categoryId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCategoryIndexCat(string inputName)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                string query = "SELECT catID FROM categories WHERE catName = @catName";
                SqlCommand cmd = new SqlCommand(query, connect);
                cmd.Parameters.AddWithValue("@catName", inputName);
                int categoryId = (int)cmd.ExecuteScalar();
                cmd.Dispose();
                return categoryId;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        
        private void button3_Click(object sender, EventArgs e)
        {
            //Ürün ekleme
            if(textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Boşlukları doldurunuz.");
            }
            else
            {
                try
                {



                    string productName = null;
                    string selectedValue = null;

                    for (int i = 0; i < listBox2.Items.Count; i++)
                    {
                        string value = listBox2.Items[i].ToString();
                        for (int j = 0; j < value.Length; j++)
                        {
                            if (value[j] == '\t')
                            {
                                productName = value.Substring(0, j);
                                selectedValue = value;
                                break;
                            }
                        }
                        if (productName != null) // If product name is found, exit the loop
                        {
                            break;
                        }
                    }

                    if (textBox3.Text != productName)
                    {
                        int categoryIndex;
                        connect.Open();
                        string query;
                        SqlCommand cmd;


                        //eğer eklenecek ürünün kategorisi yoksa listeye ekliyoruz
                        if (!listBox1.Items.Contains(textBox5.Text))
                        {
                            query = "INSERT INTO categories VALUES(@catName)";
                            cmd = new SqlCommand(query, connect);
                            listBox1.Items.Add(textBox5.Text);
                            cmd.Parameters.AddWithValue("@catName", textBox5.Text);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }


                        ListCategories();

                        //ürünü ekliyoruz
                        categoryIndex = GetCategoryIndexCat(textBox5.Text);
                        query = "INSERT INTO products VALUES(@proName,@proPrice,@catID)";
                        cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@proName", textBox3.Text);
                        cmd.Parameters.AddWithValue("@proPrice", textBox4.Text);
                        cmd.Parameters.AddWithValue("@catID", categoryIndex);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                        ListProducts();

                        for (int i = 3; i <= 5; i++)
                        {
                            TextBox existingTextBox = this.Controls.Find("textBox" + i, true)[0] as TextBox;
                            if (existingTextBox != null)
                            {
                                existingTextBox.Clear();
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Bu üründen zaten var");
                    }
                



                  
                                    
                                    
                                
                            
                        
                        
                    

                    
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    connect.Close();


                }
                
                
                

                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (listBox1.SelectedIndex != listBox1.Items.Count-1 && listBox1.SelectedIndex != -1 || textBox6.Text != "")
                {
                    connect.Open();
                    string categoryName = listBox1.SelectedItem.ToString();
                    int categoryIndex = GetCategoryIndexCat(categoryName);
                    
                    string query = "DELETE FROM products WHERE catID = @catID";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@catID", categoryIndex);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    

                    query = "DELETE FROM categories WHERE catID = @catID";
                    cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@catID", categoryIndex);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    MessageBox.Show("Geçerli");
                    
                    ListProducts();
                    ListCategories();
                    
                    textBox10.Clear();

                }
                else
                {
                    MessageBox.Show("Geçersiz");
                }
                

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connect.Close();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //Ürünün olup olmadığına bakıyor, değerini 'value'ya atıyoruz
                connect.Open();
                string productName = textBox6.Text;
                string query = "SELECT COUNT(*) FROM products WHERE proName = @proName";
                SqlCommand cmd = new SqlCommand(query,connect);
                cmd.Parameters.AddWithValue("@proName", productName);
                int value = (int)cmd.ExecuteScalar();
                cmd.Dispose();
                if (value!=0) //eğer ürün varsa siliyoruz
                {
                    query = "DELETE FROM products WHERE proName = @proName";
                    cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@proName", productName);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    ListProducts();
                    for (int i = 6; i <= 9; i++)
                    {
                        TextBox existingTextBox = this.Controls.Find("textBox" + i, true)[0] as TextBox;
                        if (existingTextBox != null)
                        {
                            existingTextBox.Clear();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ürün bulunamadı.");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connect.Close();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(listBox2.SelectedItem != null)
                {
                    //bir ürün seçildiğinde ürünün ismini "silme" kısmındaki textbox'a
                    //atıyoruz, ve aradaki boşluğu da substring kullanarak eliyoruz
                    string value = listBox2.SelectedItem.ToString();

                    for (int i = 0; i != value.Length; i++)
                    {
                        if (value[i] == '\t')
                        {
                            string productName;
                            //ürün güncelleme için ve silme için atama 
                            textBox7.Text = textBox6.Text = productName = value.Substring(0, i);
                            textBox8.Text = value.Substring(i + 1); //ürünün fiyatını güncelleme kısmına atama

                            //ürünün kategori id'sini alıyoruz, ürün güncelleme kısmına atıyoruz
                            connect.Open();
                            string query = "SELECT catName FROM products, categories WHERE proName = @proName AND products.catID = @catID AND products.catID = categories.catID";
                            SqlCommand cmd = new SqlCommand(query, connect);

                            cmd.Parameters.AddWithValue("@proName", value.Substring(0, i));
                            cmd.Parameters.AddWithValue("@catID", GetCategoryIndex(productName));
                            string result = cmd.ExecuteScalar().ToString();
                            cmd.Dispose();
                            textBox9.Text = result;



                            break;
                        }
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connect.Close();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //bu çok saçma olucak ama başka yol bilmiyorum ((ürün güncelleme
            try
            {
                string query;
                SqlCommand cmd;
                string value = listBox2.SelectedItem.ToString();
                string defName;
                string t7 = textBox7.Text;
                string t8 = textBox8.Text;
                string t9 = textBox9.Text;
                for (int i = 0; i != value.Length; i++)
                {
                    if (value[i] == '\t')
                    {
                        //ürünün kategori id'sini alıyoruz, ürün güncelleme kısmına atıyoruz
                        connect.Open();
                        query = "SELECT proName FROM products WHERE proName = @proName";
                        cmd = new SqlCommand(query, connect);

                        cmd.Parameters.AddWithValue("@proName", value.Substring(0, i));
                        string result = cmd.ExecuteScalar().ToString();
                        cmd.Dispose();


                        defName = result;
                        t7 = textBox7.Text;
                        t8 = textBox8.Text;
                        t9 = textBox9.Text;
                        if (t7 != "" && t8 != "" && t9 != "")
                        {
                            UpdateInsertCategory();
                            query = "UPDATE products SET proName = @proName, proPrice = @proPrice, catID = @catID WHERE proName = @defProName";
                            cmd = new SqlCommand(query, connect);
                            cmd.Parameters.AddWithValue("@defProName", defName);
                            cmd.Parameters.AddWithValue("@proName", t7);
                            cmd.Parameters.AddWithValue("@proPrice", Convert.ToInt32(t8));
                            cmd.Parameters.AddWithValue("@catID", GetCategoryIndexCat(t9));
                            cmd.ExecuteNonQuery();

                        }
                        else if (t7 != "" && t8 != "" && t9 == "")
                        {
                            query = "UPDATE products SET proName = @proName, proPrice = @proPrice WHERE proName = @defProName";
                            cmd = new SqlCommand(query, connect);
                            cmd.Parameters.AddWithValue("@defProName", defName);
                            cmd.Parameters.AddWithValue("@proName", t7);
                            cmd.Parameters.AddWithValue("@proPrice", Convert.ToInt32(t8));

                            cmd.ExecuteNonQuery();
                        }
                        else if (t7 != "" && t8 == "" && t9 == "")
                        {
                            query = "UPDATE products SET proName = @proName WHERE proName = @defProName";
                            cmd = new SqlCommand(query, connect);
                            cmd.Parameters.AddWithValue("@defProName", defName);
                            cmd.Parameters.AddWithValue("@proName", t7);

                            cmd.ExecuteNonQuery();
                        }
                        else if (t7 == "" && t8 != "" && t9 == "")
                        {
                            query = "UPDATE products SET proPrice = @proPrice WHERE proName = @defProName";
                            cmd = new SqlCommand(query, connect);
                            cmd.Parameters.AddWithValue("@defProName", defName);

                            cmd.Parameters.AddWithValue("@proPrice", Convert.ToInt32(t8));

                            cmd.ExecuteNonQuery();
                        }
                        else if (t7 == "" && t8 == "" && t9 != "")
                        {
                            UpdateInsertCategory();
                            query = "UPDATE products SET proName = @proName, proPrice = @proPrice, catID = @catID WHERE proName = @defProName";
                            cmd = new SqlCommand(query, connect);
                            cmd.Parameters.AddWithValue("@defProName", defName);
                            cmd.Parameters.AddWithValue("@catID", GetCategoryIndexCat(t9));
                            cmd.ExecuteNonQuery();

                        }
                        else {
                            MessageBox.Show("Hiç boşluk doldurmadınız.");
                        }

                        for (int j = 7; i <= 9; i++)
                        {
                            TextBox existingTextBox = this.Controls.Find("textBox" + j, true)[0] as TextBox;
                            if (existingTextBox != null)
                            {
                                existingTextBox.Clear();
                            }
                        }
                        cmd.Dispose();

                        ListProducts();



                        break;           
                    }
                }
                

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connect.Close();
            }
        }

        
    }
}
