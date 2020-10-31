namespace 库存管理系统
{
    partial class AddGoods
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.no = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.price = new System.Windows.Forms.TextBox();
            this.type = new System.Windows.Forms.TextBox();
            this.lastdate = new System.Windows.Forms.TextBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.company = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "商品名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "商品价格：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "生产日期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "商品种类：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "保质期：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 33);
            this.button1.TabIndex = 6;
            this.button1.Text = "添加商品";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // no
            // 
            this.no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.no.Location = new System.Drawing.Point(81, 18);
            this.no.Name = "no";
            this.no.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.no.Size = new System.Drawing.Size(174, 21);
            this.no.TabIndex = 7;
            // 
            // name
            // 
            this.name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.name.Location = new System.Drawing.Point(81, 52);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(174, 21);
            this.name.TabIndex = 8;
            // 
            // price
            // 
            this.price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.price.Location = new System.Drawing.Point(81, 85);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(174, 21);
            this.price.TabIndex = 9;
            // 
            // type
            // 
            this.type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.type.Location = new System.Drawing.Point(81, 114);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(174, 21);
            this.type.TabIndex = 10;
            // 
            // lastdate
            // 
            this.lastdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lastdate.Location = new System.Drawing.Point(81, 180);
            this.lastdate.Name = "lastdate";
            this.lastdate.Size = new System.Drawing.Size(174, 21);
            this.lastdate.TabIndex = 12;
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(81, 146);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(174, 21);
            this.date.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "所在公司：";
            // 
            // company
            // 
            this.company.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.company.Location = new System.Drawing.Point(81, 214);
            this.company.Name = "company";
            this.company.Size = new System.Drawing.Size(174, 21);
            this.company.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 272);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 33);
            this.button2.TabIndex = 16;
            this.button2.Text = "重置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(270, 328);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.company);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.date);
            this.Controls.Add(this.lastdate);
            this.Controls.Add(this.type);
            this.Controls.Add(this.price);
            this.Controls.Add(this.name);
            this.Controls.Add(this.no);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddGoods";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddGoods";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddGoods_FormClosed);
            this.Load += new System.EventHandler(this.AddGoods_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox no;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.TextBox type;
        private System.Windows.Forms.TextBox lastdate;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox company;
        private System.Windows.Forms.Button button2;
    }
}