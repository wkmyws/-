namespace 库存管理系统
{
    partial class Login
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
            this._usr = new System.Windows.Forms.TextBox();
            this._pwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.登录 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.authority = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密  码";
            // 
            // _usr
            // 
            this._usr.BackColor = System.Drawing.SystemColors.Window;
            this._usr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._usr.Location = new System.Drawing.Point(139, 105);
            this._usr.Name = "_usr";
            this._usr.Size = new System.Drawing.Size(100, 21);
            this._usr.TabIndex = 2;
            // 
            // _pwd
            // 
            this._pwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pwd.Location = new System.Drawing.Point(139, 138);
            this._pwd.Name = "_pwd";
            this._pwd.Size = new System.Drawing.Size(100, 21);
            this._pwd.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(70, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "库存管理系统";
            // 
            // 登录
            // 
            this.登录.Location = new System.Drawing.Point(58, 205);
            this.登录.Name = "登录";
            this.登录.Size = new System.Drawing.Size(180, 28);
            this.登录.TabIndex = 4;
            this.登录.Text = "登录";
            this.登录.UseVisualStyleBackColor = true;
            this.登录.Click += new System.EventHandler(this.登录_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "权  限";
            // 
            // authority
            // 
            this.authority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authority.FormattingEnabled = true;
            this.authority.Items.AddRange(new object[] {
            "管理员",
            "用户"});
            this.authority.Location = new System.Drawing.Point(139, 170);
            this.authority.Name = "authority";
            this.authority.Size = new System.Drawing.Size(100, 20);
            this.authority.TabIndex = 8;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.authority);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._pwd);
            this.Controls.Add(this._usr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.登录);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _usr;
        private System.Windows.Forms.TextBox _pwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button 登录;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox authority;


    }
}