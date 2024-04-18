using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
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
        string defaultProName;

        private void Form3_Load(object sender, EventArgs e)
        {
            //yüklenince listele
            connect = new SqlConnection("Data Source=DESKTOP-A36V29R\\SQLEXPRESS;Initial Catalog=LoginDB;Integrated Security=True;");
            try
            {
                ListCategories();
                ListProducts();
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
                
                    connect.Open();
                    if (listBox1.SelectedIndex != listBox1.Items.Count - 1 && listBox1.SelectedItem != null)
                    {
                        string query = "SELECT proName, proPrice, stockState FROM products WHERE catID = @catID";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@catID", IndexOfCategory(listBox1.SelectedItem.ToString()));
                        SqlDataReader reader = cmd.ExecuteReader();
                        GetProductsFromReader(reader);
                        catDelete_Box.Text = listBox1.SelectedItem.ToString();
                    }
                    else
                    {
                        string query = "SELECT proName, proPrice, stockState FROM products";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        SqlDataReader reader = cmd.ExecuteReader();
                        GetProductsFromReader(reader);
                        catDelete_Box.Clear();
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

        public void GetProductsFromReader(SqlDataReader reader)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            while (reader.Read())
            {
                listBox2.Items.Add(reader[0].ToString());
                listBox3.Items.Add(reader[1].ToString());
                if (reader[2].ToString() != "" && reader[2].ToString() != "0")
                {
                    listBox4.Items.Add(reader[2].ToString());
                }
                else if (reader[2].ToString() == "")
                {
                    listBox4.Items.Add("Kayıt yok");
                }
                else
                {
                    listBox4.Items.Add("Tükenmiş");
                }
            }
            reader.Close();
        }

        

        public void Ascending()
        {
            //ürünleri fiyatına göre artarak listele
            try
            {
                connect.Open();
                if (listBox1.SelectedIndex != listBox1.Items.Count - 1 && listBox1.SelectedItem != null)
                {
                    string categoryName = listBox1.SelectedItem.ToString();
                    string query = "SELECT proName, proPrice, stockState FROM products WHERE catID = @catID ORDER BY proPrice ASC";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@catID", IndexOfCategory(categoryName));
                    SqlDataReader reader = cmd.ExecuteReader();
                    GetProductsFromReader(reader);

                }
                else
                {
                    string query = "SELECT proName, proPrice, stockState FROM products ORDER BY proPrice ASC";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    SqlDataReader reader = cmd.ExecuteReader();
                    GetProductsFromReader(reader);
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
                if (listBox1.SelectedIndex != listBox1.Items.Count - 1 && listBox1.SelectedItem != null)
                {

                    string categoryName = listBox1.SelectedItem.ToString();
                    string query = "SELECT proName, proPrice, stockState FROM products WHERE catID = @catID ORDER BY proPrice DESC";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@catID", IndexOfCategory(categoryName));
                    SqlDataReader reader = cmd.ExecuteReader();
                    GetProductsFromReader(reader);

                }
                else
                {
                    string query = "SELECT proName, proPrice, stockState FROM products ORDER BY proPrice DESC";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    SqlDataReader reader = cmd.ExecuteReader();
                    listBox2.Items.Clear();
                    GetProductsFromReader(reader);
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
            try
            {
                //eğer giriş yapan admin ise kontrolleri göster
                for (int i = 1; i <= 10; i++) //WHİLE DÖNGÜSÜ YAPILACAK !!!!!!!!!!!!
                {
                    Label upd_Label = this.Controls.Find("update_Label" + i, true).FirstOrDefault() as Label;
                    if (upd_Label != null)
                    {
                        upd_Label.Enabled = true;
                        upd_Label.Visible = true;
                    }

                    Label del_Label = this.Controls.Find("delete_Label" + i, true).FirstOrDefault() as Label;

                    if (del_Label != null)
                    {
                        del_Label.Enabled = true;
                        del_Label.Visible = true;
                    }

                    Label catDel_Label = this.Controls.Find("catDelete_Label" + i, true).FirstOrDefault() as Label;

                    if (catDel_Label != null)
                    {
                        catDel_Label.Enabled = true;
                        catDel_Label.Visible = true;
                    }

                    Label add_Label = this.Controls.Find("add_Label" + i, true).FirstOrDefault() as Label;

                    if (add_Label != null)
                    {
                        add_Label.Enabled = true;
                        add_Label.Visible = true;
                    }
                }
                for (int i = 1; i <= 2; i++)
                {
                    RichTextBox existingRichTB = this.Controls.Find("richTextBox" + i, true).FirstOrDefault() as RichTextBox;
                    if (existingRichTB != null)
                    {
                        existingRichTB.Enabled = true;
                        existingRichTB.Visible = true;
                    }
                }
                for (int i = 1; i <= 4; i++)
                {
                    TextBox upd_Box = this.Controls.Find("update_Box" + i, true).FirstOrDefault() as TextBox;
                    if (upd_Box != null)
                    {
                        upd_Box.Enabled = true;
                        upd_Box.Visible = true;
                    }

                    TextBox add_Box = this.Controls.Find("add_Box" + i, true).FirstOrDefault() as TextBox;
                    if (add_Box != null)
                    {
                        add_Box.Enabled = true;
                        add_Box.Visible = true;
                    }
                }

                TextBox del_Box = this.Controls.Find("delete_Box", true).FirstOrDefault() as TextBox;
                if (del_Box != null)
                {
                    del_Box.Enabled = true;
                    del_Box.Visible = true;
                }

                TextBox catDel_Box = this.Controls.Find("catDelete_Box", true).FirstOrDefault() as TextBox;
                if (catDel_Box != null)
                {
                    catDel_Box.Enabled = true;
                    catDel_Box.Visible = true;
                }

                Button upd_Button = this.Controls.Find("update_Button", true).FirstOrDefault() as Button;
                if (upd_Button != null)
                {
                    upd_Button.Enabled = true;
                    upd_Button.Visible = true;
                }

                Button del_Button = this.Controls.Find("delete_Button", true).FirstOrDefault() as Button;
                if (del_Button != null)
                {
                    del_Button.Enabled = true;
                    del_Button.Visible = true;
                }

                Button catDel_Button = this.Controls.Find("catDelete_Button", true).FirstOrDefault() as Button;
                if (catDel_Button != null)
                {
                    catDel_Button.Enabled = true;
                    catDel_Button.Visible = true;
                }

                Button add_Button = this.Controls.Find("add_Button", true).FirstOrDefault() as Button;
                if (add_Button != null)
                {
                    add_Button.Enabled = true;
                    add_Button.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                string query = "SELECT proName, proPrice, stockState FROM products";
                SqlCommand cmd = new SqlCommand(query, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                while (reader.Read())
                {
                    listBox2.Items.Add(reader[0].ToString());
                    listBox3.Items.Add(reader[1].ToString());
                    if (reader[2].ToString() != "" && reader[2].ToString() != "0")
                    {
                        listBox4.Items.Add(reader[2].ToString());
                    }
                    else if (reader[2].ToString() == "")
                    {
                        listBox4.Items.Add("Kayıt yok");
                    }
                    else
                    {
                        listBox4.Items.Add("Tükenmiş");
                    }
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
                cmd.Parameters.AddWithValue("@catName", update_Box3.Text);
                int catCount = (int)cmd.ExecuteScalar();
                cmd.Dispose();
                if (catCount == 0)
                {
                    query = "INSERT INTO categories VALUES(@catName)";
                    cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@catName", update_Box3.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int IndexOfProductCategory(string inputName)
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

        public int IndexOfCategory(string inputName)
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
            if(add_Box1.Text == "" || add_Box2.Text == "" || add_Box3.Text == "")
            {
                MessageBox.Show("Boşlukları doldurunuz.");
            }
            else
            {
                try
                {



                    string productName = null;
                    

                    for (int i = 0; i < listBox2.Items.Count; i++)
                    {
                        string value = listBox2.Items[i].ToString();

                        productName = value;
                        
                        if (productName == add_Box1.Text) // If product name is found, exit the loop
                        {
                            break;
                        }
                    }

                    if (add_Box1.Text != productName)
                    {
                        int categoryIndex;
                        connect.Open();
                        string query;
                        SqlCommand cmd;


                        //eğer eklenecek ürünün kategorisi yoksa listeye ekliyoruz
                        if (!listBox1.Items.Contains(add_Box3.Text))
                        {
                            query = "INSERT INTO categories VALUES(@catName)";
                            cmd = new SqlCommand(query, connect);
                            listBox1.Items.Add(add_Box3.Text);
                            cmd.Parameters.AddWithValue("@catName", add_Box3.Text);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }


                        ListCategories();

                        //ürünü ekliyoruz
                        categoryIndex = IndexOfCategory(add_Box3.Text);
                        if(richTextBox1.Text == "")
                        {
                            query = "INSERT INTO products VALUES(@proName,@proPrice,@catID)";
                            cmd = new SqlCommand(query, connect);
                            cmd.Parameters.AddWithValue("@proName", add_Box1.Text);
                            cmd.Parameters.AddWithValue("@proPrice", add_Box2.Text);
                            cmd.Parameters.AddWithValue("@catID", categoryIndex);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        else
                        {
                            query = "INSERT INTO products VALUES(@proName,@proPrice,@catID, @proDesc)";
                            cmd = new SqlCommand(query, connect);
                            cmd.Parameters.AddWithValue("@proName", add_Box1.Text);
                            cmd.Parameters.AddWithValue("@proPrice", add_Box2.Text);
                            cmd.Parameters.AddWithValue("@catID", categoryIndex);
                            cmd.Parameters.AddWithValue("@proDesc", richTextBox1.Text);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                        

                        ListProducts();

                        for (int i = 3; i <= 5; i++)
                        {
                            TextBox existingTextBox = this.Controls.Find("textBox" + i, true).FirstOrDefault() as TextBox;
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
                if (listBox1.SelectedIndex != listBox1.Items.Count-1 && listBox1.SelectedIndex != -1 || delete_Box.Text != "")
                {
                    connect.Open();
                    string categoryName = listBox1.SelectedItem.ToString();
                    int categoryIndex = IndexOfCategory(categoryName);
                    
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
                    
                    catDelete_Box.Clear();

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
                string productName = delete_Box.Text;
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
                    for (int i = 1; i <= 4; i++)
                    {
                        TextBox existingTextBox = this.Controls.Find("update_Box" + i, true).FirstOrDefault() as TextBox;
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
                if (listBox2.SelectedItem != null)
                {

                    defaultProName = listBox2.SelectedItem.ToString();
                    //bir ürün seçildiğinde ürünün ismini "silme" kısmındaki textbox'a
                    //atıyoruz

                    int indexer = listBox2.Items.IndexOf(listBox2.SelectedItem.ToString());
                    string indexed = listBox3.Items[indexer].ToString();

                    string productName;
                    //ürün güncelleme için ve silme için atama 
                    update_Box1.Text = delete_Box.Text = productName = listBox2.SelectedItem.ToString();
                    update_Box2.Text = indexed; //ürünün fiyatını güncelleme kısmına atama

                    //ürünün kategori id'sini alıyoruz, ürün güncelleme kısmına atıyoruz
                    connect.Open();
                    string query = "SELECT catName FROM products, categories WHERE proName = @proName AND products.catID = @catID AND products.catID = categories.catID";
                    SqlCommand cmd = new SqlCommand(query, connect);

                    cmd.Parameters.AddWithValue("@proName", listBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@catID", IndexOfProductCategory(productName));
                    string result = cmd.ExecuteScalar().ToString();
                    cmd.Dispose();
                    update_Box3.Text = result;

                    query = "SELECT proDesc FROM products WHERE proName = @proName";
                    cmd = new SqlCommand(query, connect);
                    cmd.Parameters.AddWithValue("@proName", productName);
                    richTextBox2.Text = cmd.ExecuteScalar().ToString();




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
                
                string r2 = richTextBox2.Text;
                
                    
                        connect.Open();
                        

                        for(int i = 7; i <= 10; i++)
                        {
                            TextBox existingTextBox = this.Controls.Find("textBox" + i, true).FirstOrDefault() as TextBox;
                            if (existingTextBox != null || r2 == "" || r2 != "")
                            {
                                
                                switch (i)
                                {
                                    case 7:
                                        if(existingTextBox.Text != "")
                                        {
                                            query = "UPDATE products SET proName = @proName WHERE proName = @defProName";
                                            cmd = new SqlCommand(query, connect);
                                            cmd.Parameters.AddWithValue("@proName", existingTextBox.Text);
                                            cmd.Parameters.AddWithValue("@defProName", defaultProName);
                                            cmd.ExecuteNonQuery();
                                            cmd.Dispose();
                                            
                                        }
                                        break;
                                    case 8:
                                        if (existingTextBox.Text != "")
                                        {
                                            query = "UPDATE products SET proPrice = @proPrice WHERE proName = @defProName";
                                            cmd = new SqlCommand(query, connect);
                                            cmd.Parameters.AddWithValue("@proPrice", existingTextBox.Text);
                                            cmd.Parameters.AddWithValue("@defProName", defaultProName);
                                            cmd.ExecuteNonQuery();
                                            cmd.Dispose();
                                            
                                        }
                                        break;
                                    case 9:
                                        if (existingTextBox.Text != "")
                                        {
                                            UpdateInsertCategory();
                                            query = "UPDATE products SET catID = @catID WHERE proName = @defProName";
                                            cmd = new SqlCommand(query, connect);
                                            cmd.Parameters.AddWithValue("@catID", IndexOfCategory(existingTextBox.Text));
                                            cmd.Parameters.AddWithValue("@defProName", defaultProName);
                                            cmd.ExecuteNonQuery();
                                            cmd.Dispose();
                                            
                                        }
                                        break;
                                    case 10:
                                        if(update_Box1.Text == "" && update_Box2.Text == "" && update_Box3.Text == "")
                                        {
                                            MessageBox.Show("Hiç boşluk doldurmadınız.");
                                        }
                                        else
                                        {
                                            query = "UPDATE products SET proDesc = @proDesc WHERE proName = @defProName";
                                            cmd = new SqlCommand(query, connect);
                                            cmd.Parameters.AddWithValue("@proDesc", r2);
                                            cmd.Parameters.AddWithValue("@defProName", defaultProName);
                                            cmd.ExecuteNonQuery();
                                            cmd.Dispose();
                                            richTextBox2.Clear();
                                        }
                                        break;
                                }
                            }
                        }

                        for (int j = 7; j <= 9; j++)
                        {
                            TextBox existingTextBox = this.Controls.Find("textBox" + j, true).FirstOrDefault() as TextBox;
                            if(existingTextBox != null)
                            existingTextBox.Clear();
                        }
                        

                        ListProducts();



                                 
                    
                
                

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

        private void ProductDescClick(object sender, EventArgs e)
        {
            try
            {
                if(listBox2.SelectedItem != null)
                {
                    string value = listBox2.SelectedItem.ToString();
                    for (int i = 0; i != value.Length; i++)
                    {
                        if (value[i] == '\t')
                        {

                            connect.Open();
                            string query = "SELECT proDesc FROM products WHERE proName = @proName";
                            SqlCommand cmd = new SqlCommand(query, connect);
                            cmd.Parameters.AddWithValue("@proName", value.Substring(0, i));
                            string desc = cmd.ExecuteScalar().ToString();
                            if(desc == "")
                            {
                                MessageBox.Show("Ürünün açıklaması yok");
                            }
                            else
                            {
                                MessageBox.Show(desc);
                            }
                            
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

        private void MinMaxPriceText_Changed(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                if (listBox1.SelectedIndex != listBox1.Items.Count - 1 && listBox1.SelectedItem != null)
                {

                    string categoryName = listBox1.SelectedItem.ToString();
                    if (lowPrice_Box.Text != "" && hiPrice_Box.Text == "")
                    {
                        string query = "SELECT proName, proPrice FROM products WHERE catID = @catID AND proPrice >= @minPrice ";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@minPrice", lowPrice_Box.Text);
                        cmd.Parameters.AddWithValue("@catID", IndexOfCategory(categoryName));
                        SqlDataReader reader = cmd.ExecuteReader();
                        GetProductsFromReader(reader);
                    }
                    else if (lowPrice_Box.Text == "" && hiPrice_Box.Text != "")
                    {
                        string query = "SELECT proName, proPrice FROM products WHERE catID = @catID AND proPrice >= @minPrice ";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@maxPrice", hiPrice_Box.Text);
                        cmd.Parameters.AddWithValue("@catID", IndexOfCategory(categoryName));
                        SqlDataReader reader = cmd.ExecuteReader();
                        GetProductsFromReader(reader);
                    }
                    else
                    {
                        string query = "SELECT proName, proPrice FROM products WHERE catID = @catID AND proPrice >= @minPrice AND proPrice <= @maxPrice";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@minPrice", lowPrice_Box.Text);
                        cmd.Parameters.AddWithValue("@maxPrice", hiPrice_Box.Text);
                        cmd.Parameters.AddWithValue("@catID", IndexOfCategory(categoryName));
                        SqlDataReader reader = cmd.ExecuteReader();
                        listBox2.Items.Clear();
                        GetProductsFromReader(reader);
                    }


                }
                else
                {
                    if (lowPrice_Box.Text != "" && hiPrice_Box.Text == "")
                    {
                        string query = "SELECT proName, proPrice FROM products WHERE proPrice >= @minPrice ";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@minPrice", lowPrice_Box.Text);
                        SqlDataReader reader = cmd.ExecuteReader();
                        GetProductsFromReader(reader);
                    }
                    else if (lowPrice_Box.Text == "" && hiPrice_Box.Text != "")
                    {
                        string query = "SELECT proName, proPrice FROM products WHERE proPrice >= @maxPrice ";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@maxPrice", hiPrice_Box.Text);
                        SqlDataReader reader = cmd.ExecuteReader();
                        listBox2.Items.Clear();
                        GetProductsFromReader(reader);
                    }
                    else
                    {
                        string query = "SELECT proName, proPrice FROM products WHERE proPrice >= @minPrice AND proPrice <= @maxPrice";
                        SqlCommand cmd = new SqlCommand(query, connect);
                        cmd.Parameters.AddWithValue("@minPrice", lowPrice_Box.Text);
                        cmd.Parameters.AddWithValue("@maxPrice", hiPrice_Box.Text);
                        SqlDataReader reader = cmd.ExecuteReader();
                        GetProductsFromReader(reader);
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
    }
}
