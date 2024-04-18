namespace loginApp
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.category_Label = new System.Windows.Forms.Label();
            this.products_Label = new System.Windows.Forms.Label();
            this.ascList_Button = new System.Windows.Forms.Button();
            this.descList_Button = new System.Windows.Forms.Button();
            this.lowPrice_Box = new System.Windows.Forms.TextBox();
            this.hiPrice_Box = new System.Windows.Forms.TextBox();
            this.lowPrice_Label = new System.Windows.Forms.Label();
            this.hiPrice_Label = new System.Windows.Forms.Label();
            this.add_Label1 = new System.Windows.Forms.Label();
            this.add_Box1 = new System.Windows.Forms.TextBox();
            this.add_Label2 = new System.Windows.Forms.Label();
            this.add_Label3 = new System.Windows.Forms.Label();
            this.add_Box2 = new System.Windows.Forms.TextBox();
            this.add_Label4 = new System.Windows.Forms.Label();
            this.add_Box3 = new System.Windows.Forms.TextBox();
            this.add_Button = new System.Windows.Forms.Button();
            this.delete_Label2 = new System.Windows.Forms.Label();
            this.delete_Label1 = new System.Windows.Forms.Label();
            this.delete_Box = new System.Windows.Forms.TextBox();
            this.delete_Button = new System.Windows.Forms.Button();
            this.update_Button = new System.Windows.Forms.Button();
            this.update_Box1 = new System.Windows.Forms.TextBox();
            this.update_Label4 = new System.Windows.Forms.Label();
            this.update_Box2 = new System.Windows.Forms.TextBox();
            this.update_Label3 = new System.Windows.Forms.Label();
            this.update_Label2 = new System.Windows.Forms.Label();
            this.update_Label1 = new System.Windows.Forms.Label();
            this.update_Box3 = new System.Windows.Forms.TextBox();
            this.catDelete_Label1 = new System.Windows.Forms.Label();
            this.catDelete_Button = new System.Windows.Forms.Button();
            this.catDelete_Label2 = new System.Windows.Forms.Label();
            this.catDelete_Box = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.add_Label6 = new System.Windows.Forms.Label();
            this.update_Label6 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.stocks_Label = new System.Windows.Forms.Label();
            this.add_Box4 = new System.Windows.Forms.TextBox();
            this.add_Label5 = new System.Windows.Forms.Label();
            this.update_Label5 = new System.Windows.Forms.Label();
            this.update_Box4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(456, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(111, 303);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(573, 28);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(127, 303);
            this.listBox2.TabIndex = 1;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            this.listBox2.DoubleClick += new System.EventHandler(this.ProductDescClick);
            // 
            // category_Label
            // 
            this.category_Label.AutoSize = true;
            this.category_Label.Location = new System.Drawing.Point(453, 8);
            this.category_Label.Name = "category_Label";
            this.category_Label.Size = new System.Drawing.Size(57, 13);
            this.category_Label.TabIndex = 2;
            this.category_Label.Text = "Kategoriler";
            // 
            // products_Label
            // 
            this.products_Label.AutoSize = true;
            this.products_Label.Location = new System.Drawing.Point(570, 8);
            this.products_Label.Name = "products_Label";
            this.products_Label.Size = new System.Drawing.Size(41, 13);
            this.products_Label.TabIndex = 3;
            this.products_Label.Text = "Ürünler";
            // 
            // ascList_Button
            // 
            this.ascList_Button.Location = new System.Drawing.Point(580, 333);
            this.ascList_Button.Name = "ascList_Button";
            this.ascList_Button.Size = new System.Drawing.Size(93, 72);
            this.ascList_Button.TabIndex = 4;
            this.ascList_Button.Text = "Artarak Listele";
            this.ascList_Button.UseVisualStyleBackColor = true;
            this.ascList_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // descList_Button
            // 
            this.descList_Button.Location = new System.Drawing.Point(679, 333);
            this.descList_Button.Name = "descList_Button";
            this.descList_Button.Size = new System.Drawing.Size(93, 72);
            this.descList_Button.TabIndex = 5;
            this.descList_Button.Text = "Azalarak Listele";
            this.descList_Button.UseVisualStyleBackColor = true;
            this.descList_Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // lowPrice_Box
            // 
            this.lowPrice_Box.Location = new System.Drawing.Point(652, 411);
            this.lowPrice_Box.Name = "lowPrice_Box";
            this.lowPrice_Box.Size = new System.Drawing.Size(120, 20);
            this.lowPrice_Box.TabIndex = 6;
            this.lowPrice_Box.TextChanged += new System.EventHandler(this.MinMaxPriceText_Changed);
            // 
            // hiPrice_Box
            // 
            this.hiPrice_Box.Location = new System.Drawing.Point(652, 440);
            this.hiPrice_Box.Name = "hiPrice_Box";
            this.hiPrice_Box.Size = new System.Drawing.Size(120, 20);
            this.hiPrice_Box.TabIndex = 7;
            this.hiPrice_Box.TextChanged += new System.EventHandler(this.MinMaxPriceText_Changed);
            // 
            // lowPrice_Label
            // 
            this.lowPrice_Label.AutoSize = true;
            this.lowPrice_Label.Location = new System.Drawing.Point(580, 414);
            this.lowPrice_Label.Name = "lowPrice_Label";
            this.lowPrice_Label.Size = new System.Drawing.Size(66, 13);
            this.lowPrice_Label.TabIndex = 8;
            this.lowPrice_Label.Text = "En Az Fiyat: ";
            // 
            // hiPrice_Label
            // 
            this.hiPrice_Label.AutoSize = true;
            this.hiPrice_Label.Location = new System.Drawing.Point(570, 440);
            this.hiPrice_Label.Name = "hiPrice_Label";
            this.hiPrice_Label.Size = new System.Drawing.Size(76, 13);
            this.hiPrice_Label.TabIndex = 9;
            this.hiPrice_Label.Text = "En Fazla Fiyat:";
            // 
            // add_Label1
            // 
            this.add_Label1.AutoSize = true;
            this.add_Label1.Enabled = false;
            this.add_Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.add_Label1.Location = new System.Drawing.Point(130, 326);
            this.add_Label1.Name = "add_Label1";
            this.add_Label1.Size = new System.Drawing.Size(135, 18);
            this.add_Label1.TabIndex = 11;
            this.add_Label1.Text = "Listeye ürün ekle";
            this.add_Label1.Visible = false;
            // 
            // add_Box1
            // 
            this.add_Box1.Enabled = false;
            this.add_Box1.Location = new System.Drawing.Point(86, 347);
            this.add_Box1.Name = "add_Box1";
            this.add_Box1.Size = new System.Drawing.Size(222, 20);
            this.add_Box1.TabIndex = 10;
            this.add_Box1.Visible = false;
            // 
            // add_Label2
            // 
            this.add_Label2.AutoSize = true;
            this.add_Label2.Enabled = false;
            this.add_Label2.Location = new System.Drawing.Point(32, 350);
            this.add_Label2.Name = "add_Label2";
            this.add_Label2.Size = new System.Drawing.Size(53, 13);
            this.add_Label2.TabIndex = 12;
            this.add_Label2.Text = "Ürün ismi:";
            this.add_Label2.Visible = false;
            // 
            // add_Label3
            // 
            this.add_Label3.AutoSize = true;
            this.add_Label3.Enabled = false;
            this.add_Label3.Location = new System.Drawing.Point(28, 372);
            this.add_Label3.Name = "add_Label3";
            this.add_Label3.Size = new System.Drawing.Size(57, 13);
            this.add_Label3.TabIndex = 13;
            this.add_Label3.Text = "Ürün fiyatı:";
            this.add_Label3.Visible = false;
            // 
            // add_Box2
            // 
            this.add_Box2.Enabled = false;
            this.add_Box2.Location = new System.Drawing.Point(86, 369);
            this.add_Box2.Name = "add_Box2";
            this.add_Box2.Size = new System.Drawing.Size(222, 20);
            this.add_Box2.TabIndex = 14;
            this.add_Box2.Visible = false;
            // 
            // add_Label4
            // 
            this.add_Label4.AutoSize = true;
            this.add_Label4.Enabled = false;
            this.add_Label4.Location = new System.Drawing.Point(4, 395);
            this.add_Label4.Name = "add_Label4";
            this.add_Label4.Size = new System.Drawing.Size(81, 13);
            this.add_Label4.TabIndex = 15;
            this.add_Label4.Text = "Ürün kategorisi:";
            this.add_Label4.Visible = false;
            // 
            // add_Box3
            // 
            this.add_Box3.Enabled = false;
            this.add_Box3.Location = new System.Drawing.Point(86, 392);
            this.add_Box3.Name = "add_Box3";
            this.add_Box3.Size = new System.Drawing.Size(222, 20);
            this.add_Box3.TabIndex = 16;
            this.add_Box3.Visible = false;
            // 
            // add_Button
            // 
            this.add_Button.Enabled = false;
            this.add_Button.Location = new System.Drawing.Point(86, 444);
            this.add_Button.Name = "add_Button";
            this.add_Button.Size = new System.Drawing.Size(222, 23);
            this.add_Button.TabIndex = 17;
            this.add_Button.Text = "Ekle";
            this.add_Button.UseVisualStyleBackColor = true;
            this.add_Button.Visible = false;
            this.add_Button.Click += new System.EventHandler(this.button3_Click);
            // 
            // delete_Label2
            // 
            this.delete_Label2.AutoSize = true;
            this.delete_Label2.Enabled = false;
            this.delete_Label2.Location = new System.Drawing.Point(31, 206);
            this.delete_Label2.Name = "delete_Label2";
            this.delete_Label2.Size = new System.Drawing.Size(53, 13);
            this.delete_Label2.TabIndex = 20;
            this.delete_Label2.Text = "Ürün ismi:";
            this.delete_Label2.Visible = false;
            // 
            // delete_Label1
            // 
            this.delete_Label1.AutoSize = true;
            this.delete_Label1.Enabled = false;
            this.delete_Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.delete_Label1.Location = new System.Drawing.Point(64, 182);
            this.delete_Label1.Name = "delete_Label1";
            this.delete_Label1.Size = new System.Drawing.Size(264, 18);
            this.delete_Label1.TabIndex = 19;
            this.delete_Label1.Text = "Seçilen veya ismi yazılan ürünü sil";
            this.delete_Label1.Visible = false;
            // 
            // delete_Box
            // 
            this.delete_Box.Enabled = false;
            this.delete_Box.Location = new System.Drawing.Point(86, 203);
            this.delete_Box.Name = "delete_Box";
            this.delete_Box.Size = new System.Drawing.Size(222, 20);
            this.delete_Box.TabIndex = 18;
            this.delete_Box.Visible = false;
            // 
            // delete_Button
            // 
            this.delete_Button.Enabled = false;
            this.delete_Button.Location = new System.Drawing.Point(86, 229);
            this.delete_Button.Name = "delete_Button";
            this.delete_Button.Size = new System.Drawing.Size(222, 23);
            this.delete_Button.TabIndex = 21;
            this.delete_Button.Text = "Sil";
            this.delete_Button.UseVisualStyleBackColor = true;
            this.delete_Button.Visible = false;
            this.delete_Button.Click += new System.EventHandler(this.button4_Click);
            // 
            // update_Button
            // 
            this.update_Button.Enabled = false;
            this.update_Button.Location = new System.Drawing.Point(86, 129);
            this.update_Button.Name = "update_Button";
            this.update_Button.Size = new System.Drawing.Size(222, 23);
            this.update_Button.TabIndex = 29;
            this.update_Button.Text = "Güncelle";
            this.update_Button.UseVisualStyleBackColor = true;
            this.update_Button.Visible = false;
            this.update_Button.Click += new System.EventHandler(this.button5_Click);
            // 
            // update_Box1
            // 
            this.update_Box1.Enabled = false;
            this.update_Box1.Location = new System.Drawing.Point(86, 34);
            this.update_Box1.Name = "update_Box1";
            this.update_Box1.Size = new System.Drawing.Size(222, 20);
            this.update_Box1.TabIndex = 28;
            this.update_Box1.Visible = false;
            // 
            // update_Label4
            // 
            this.update_Label4.AutoSize = true;
            this.update_Label4.Enabled = false;
            this.update_Label4.Location = new System.Drawing.Point(3, 82);
            this.update_Label4.Name = "update_Label4";
            this.update_Label4.Size = new System.Drawing.Size(81, 13);
            this.update_Label4.TabIndex = 27;
            this.update_Label4.Text = "Ürün kategorisi:";
            this.update_Label4.Visible = false;
            // 
            // update_Box2
            // 
            this.update_Box2.Enabled = false;
            this.update_Box2.Location = new System.Drawing.Point(86, 56);
            this.update_Box2.Name = "update_Box2";
            this.update_Box2.Size = new System.Drawing.Size(222, 20);
            this.update_Box2.TabIndex = 26;
            this.update_Box2.Visible = false;
            // 
            // update_Label3
            // 
            this.update_Label3.AutoSize = true;
            this.update_Label3.Enabled = false;
            this.update_Label3.Location = new System.Drawing.Point(27, 60);
            this.update_Label3.Name = "update_Label3";
            this.update_Label3.Size = new System.Drawing.Size(57, 13);
            this.update_Label3.TabIndex = 25;
            this.update_Label3.Text = "Ürün fiyatı:";
            this.update_Label3.Visible = false;
            // 
            // update_Label2
            // 
            this.update_Label2.AutoSize = true;
            this.update_Label2.Enabled = false;
            this.update_Label2.Location = new System.Drawing.Point(31, 37);
            this.update_Label2.Name = "update_Label2";
            this.update_Label2.Size = new System.Drawing.Size(53, 13);
            this.update_Label2.TabIndex = 24;
            this.update_Label2.Text = "Ürün ismi:";
            this.update_Label2.Visible = false;
            // 
            // update_Label1
            // 
            this.update_Label1.AutoSize = true;
            this.update_Label1.Enabled = false;
            this.update_Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.update_Label1.Location = new System.Drawing.Point(103, 9);
            this.update_Label1.Name = "update_Label1";
            this.update_Label1.Size = new System.Drawing.Size(177, 18);
            this.update_Label1.TabIndex = 23;
            this.update_Label1.Text = "Seçilen ürünü güncelle";
            this.update_Label1.Visible = false;
            // 
            // update_Box3
            // 
            this.update_Box3.Enabled = false;
            this.update_Box3.Location = new System.Drawing.Point(86, 79);
            this.update_Box3.Name = "update_Box3";
            this.update_Box3.Size = new System.Drawing.Size(222, 20);
            this.update_Box3.TabIndex = 22;
            this.update_Box3.Visible = false;
            // 
            // catDelete_Label1
            // 
            this.catDelete_Label1.AutoSize = true;
            this.catDelete_Label1.Enabled = false;
            this.catDelete_Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.catDelete_Label1.Location = new System.Drawing.Point(54, 254);
            this.catDelete_Label1.Name = "catDelete_Label1";
            this.catDelete_Label1.Size = new System.Drawing.Size(295, 18);
            this.catDelete_Label1.TabIndex = 31;
            this.catDelete_Label1.Text = "Seçilen veya ismi yazılan kategoriyi sil";
            this.catDelete_Label1.Visible = false;
            // 
            // catDelete_Button
            // 
            this.catDelete_Button.Enabled = false;
            this.catDelete_Button.Location = new System.Drawing.Point(86, 301);
            this.catDelete_Button.Name = "catDelete_Button";
            this.catDelete_Button.Size = new System.Drawing.Size(222, 23);
            this.catDelete_Button.TabIndex = 32;
            this.catDelete_Button.Text = "Sil";
            this.catDelete_Button.UseVisualStyleBackColor = true;
            this.catDelete_Button.Visible = false;
            this.catDelete_Button.Click += new System.EventHandler(this.button6_Click);
            // 
            // catDelete_Label2
            // 
            this.catDelete_Label2.AutoSize = true;
            this.catDelete_Label2.Enabled = false;
            this.catDelete_Label2.Location = new System.Drawing.Point(15, 278);
            this.catDelete_Label2.Name = "catDelete_Label2";
            this.catDelete_Label2.Size = new System.Drawing.Size(69, 13);
            this.catDelete_Label2.TabIndex = 34;
            this.catDelete_Label2.Text = "Kategori ismi:";
            this.catDelete_Label2.Visible = false;
            // 
            // catDelete_Box
            // 
            this.catDelete_Box.Enabled = false;
            this.catDelete_Box.Location = new System.Drawing.Point(86, 275);
            this.catDelete_Box.Name = "catDelete_Box";
            this.catDelete_Box.Size = new System.Drawing.Size(222, 20);
            this.catDelete_Box.TabIndex = 33;
            this.catDelete_Box.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(314, 350);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(112, 94);
            this.richTextBox1.TabIndex = 35;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Enabled = false;
            this.richTextBox2.Location = new System.Drawing.Point(314, 30);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(112, 98);
            this.richTextBox2.TabIndex = 36;
            this.richTextBox2.Text = "";
            this.richTextBox2.Visible = false;
            // 
            // add_Label6
            // 
            this.add_Label6.AutoSize = true;
            this.add_Label6.Enabled = false;
            this.add_Label6.Location = new System.Drawing.Point(314, 334);
            this.add_Label6.Name = "add_Label6";
            this.add_Label6.Size = new System.Drawing.Size(63, 13);
            this.add_Label6.TabIndex = 37;
            this.add_Label6.Text = "Açıklaması: ";
            this.add_Label6.Visible = false;
            // 
            // update_Label6
            // 
            this.update_Label6.AutoSize = true;
            this.update_Label6.Enabled = false;
            this.update_Label6.Location = new System.Drawing.Point(314, 14);
            this.update_Label6.Name = "update_Label6";
            this.update_Label6.Size = new System.Drawing.Size(63, 13);
            this.update_Label6.TabIndex = 38;
            this.update_Label6.Text = "Açıklaması: ";
            this.update_Label6.Visible = false;
            // 
            // listBox3
            // 
            this.listBox3.Enabled = false;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(699, 28);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(73, 303);
            this.listBox3.TabIndex = 39;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(778, 28);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(73, 303);
            this.listBox4.TabIndex = 40;
            // 
            // stocks_Label
            // 
            this.stocks_Label.AutoSize = true;
            this.stocks_Label.Location = new System.Drawing.Point(778, 9);
            this.stocks_Label.Name = "stocks_Label";
            this.stocks_Label.Size = new System.Drawing.Size(67, 13);
            this.stocks_Label.TabIndex = 41;
            this.stocks_Label.Text = "Stok durumu";
            // 
            // add_Box4
            // 
            this.add_Box4.Enabled = false;
            this.add_Box4.Location = new System.Drawing.Point(86, 418);
            this.add_Box4.Name = "add_Box4";
            this.add_Box4.Size = new System.Drawing.Size(222, 20);
            this.add_Box4.TabIndex = 42;
            this.add_Box4.Visible = false;
            // 
            // add_Label5
            // 
            this.add_Label5.AutoSize = true;
            this.add_Label5.Enabled = false;
            this.add_Label5.Location = new System.Drawing.Point(15, 421);
            this.add_Label5.Name = "add_Label5";
            this.add_Label5.Size = new System.Drawing.Size(70, 13);
            this.add_Label5.TabIndex = 43;
            this.add_Label5.Text = "Stok durumu:";
            this.add_Label5.Visible = false;
            // 
            // update_Label5
            // 
            this.update_Label5.AutoSize = true;
            this.update_Label5.Enabled = false;
            this.update_Label5.Location = new System.Drawing.Point(15, 106);
            this.update_Label5.Name = "update_Label5";
            this.update_Label5.Size = new System.Drawing.Size(70, 13);
            this.update_Label5.TabIndex = 45;
            this.update_Label5.Text = "Stok durumu:";
            this.update_Label5.Visible = false;
            // 
            // update_Box4
            // 
            this.update_Box4.Enabled = false;
            this.update_Box4.Location = new System.Drawing.Point(86, 103);
            this.update_Box4.Name = "update_Box4";
            this.update_Box4.Size = new System.Drawing.Size(222, 20);
            this.update_Box4.TabIndex = 44;
            this.update_Box4.Visible = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 749);
            this.Controls.Add(this.update_Label5);
            this.Controls.Add(this.update_Box4);
            this.Controls.Add(this.add_Label5);
            this.Controls.Add(this.add_Box4);
            this.Controls.Add(this.stocks_Label);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.update_Label6);
            this.Controls.Add(this.add_Label6);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.catDelete_Label2);
            this.Controls.Add(this.catDelete_Box);
            this.Controls.Add(this.catDelete_Button);
            this.Controls.Add(this.catDelete_Label1);
            this.Controls.Add(this.update_Button);
            this.Controls.Add(this.update_Box1);
            this.Controls.Add(this.update_Label4);
            this.Controls.Add(this.update_Box2);
            this.Controls.Add(this.update_Label3);
            this.Controls.Add(this.update_Label2);
            this.Controls.Add(this.update_Label1);
            this.Controls.Add(this.update_Box3);
            this.Controls.Add(this.delete_Button);
            this.Controls.Add(this.delete_Label2);
            this.Controls.Add(this.delete_Label1);
            this.Controls.Add(this.delete_Box);
            this.Controls.Add(this.add_Button);
            this.Controls.Add(this.add_Box3);
            this.Controls.Add(this.add_Label4);
            this.Controls.Add(this.add_Box2);
            this.Controls.Add(this.add_Label3);
            this.Controls.Add(this.add_Label2);
            this.Controls.Add(this.add_Label1);
            this.Controls.Add(this.add_Box1);
            this.Controls.Add(this.hiPrice_Label);
            this.Controls.Add(this.lowPrice_Label);
            this.Controls.Add(this.hiPrice_Box);
            this.Controls.Add(this.lowPrice_Box);
            this.Controls.Add(this.descList_Button);
            this.Controls.Add(this.ascList_Button);
            this.Controls.Add(this.products_Label);
            this.Controls.Add(this.category_Label);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label category_Label;
        private System.Windows.Forms.Label products_Label;
        private System.Windows.Forms.Button ascList_Button;
        private System.Windows.Forms.Button descList_Button;
        private System.Windows.Forms.TextBox lowPrice_Box;
        private System.Windows.Forms.TextBox hiPrice_Box;
        private System.Windows.Forms.Label lowPrice_Label;
        private System.Windows.Forms.Label hiPrice_Label;
        private System.Windows.Forms.Label add_Label1;
        private System.Windows.Forms.TextBox add_Box1;
        private System.Windows.Forms.Label add_Label2;
        private System.Windows.Forms.Label add_Label3;
        private System.Windows.Forms.TextBox add_Box2;
        private System.Windows.Forms.Label add_Label4;
        private System.Windows.Forms.TextBox add_Box3;
        private System.Windows.Forms.Button add_Button;
        private System.Windows.Forms.Label delete_Label2;
        private System.Windows.Forms.Label delete_Label1;
        private System.Windows.Forms.TextBox delete_Box;
        private System.Windows.Forms.Button delete_Button;
        private System.Windows.Forms.Button update_Button;
        private System.Windows.Forms.TextBox update_Box1;
        private System.Windows.Forms.Label update_Label4;
        private System.Windows.Forms.TextBox update_Box2;
        private System.Windows.Forms.Label update_Label3;
        private System.Windows.Forms.Label update_Label2;
        private System.Windows.Forms.Label update_Label1;
        private System.Windows.Forms.TextBox update_Box3;
        private System.Windows.Forms.Label catDelete_Label1;
        private System.Windows.Forms.Button catDelete_Button;
        private System.Windows.Forms.Label catDelete_Label2;
        private System.Windows.Forms.TextBox catDelete_Box;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label add_Label6;
        private System.Windows.Forms.Label update_Label6;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Label stocks_Label;
        private System.Windows.Forms.TextBox add_Box4;
        private System.Windows.Forms.Label add_Label5;
        private System.Windows.Forms.Label update_Label5;
        private System.Windows.Forms.TextBox update_Box4;
    }
}