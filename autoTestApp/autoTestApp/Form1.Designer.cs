namespace autoTestApp
{
    partial class frLogin
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
            this.txtUID = new System.Windows.Forms.TextBox();
            this.txtUPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rd2 = new System.Windows.Forms.RadioButton();
            this.rd1 = new System.Windows.Forms.RadioButton();
            this.rd3 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(452, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "رقم الدخول";
            // 
            // txtUID
            // 
            this.txtUID.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtUID.Location = new System.Drawing.Point(210, 194);
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(185, 27);
            this.txtUID.TabIndex = 1;
            // 
            // txtUPass
            // 
            this.txtUPass.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUPass.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtUPass.Location = new System.Drawing.Point(210, 239);
            this.txtUPass.Name = "txtUPass";
            this.txtUPass.PasswordChar = '*';
            this.txtUPass.Size = new System.Drawing.Size(185, 27);
            this.txtUPass.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(452, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "رقم السري";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::autoTestApp.Properties.Resources.imagesCA0FNVEI;
            this.pictureBox1.Location = new System.Drawing.Point(295, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(281, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "الامتحانات الالكترونيه";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Beige;
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnLogin.Location = new System.Drawing.Point(187, 46);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(111, 36);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "دخول";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(120, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 19);
            this.label4.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(120, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 19);
            this.label5.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.rd3);
            this.panel1.Controls.Add(this.rd1);
            this.panel1.Controls.Add(this.rd2);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Location = new System.Drawing.Point(210, 282);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(322, 120);
            this.panel1.TabIndex = 9;
            // 
            // rd2
            // 
            this.rd2.AutoSize = true;
            this.rd2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.rd2.Location = new System.Drawing.Point(39, 46);
            this.rd2.Name = "rd2";
            this.rd2.Size = new System.Drawing.Size(57, 18);
            this.rd2.TabIndex = 0;
            this.rd2.Text = "مدرس";
            this.rd2.UseVisualStyleBackColor = true;
            // 
            // rd1
            // 
            this.rd1.AutoSize = true;
            this.rd1.Checked = true;
            this.rd1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.rd1.Location = new System.Drawing.Point(17, 11);
            this.rd1.Name = "rd1";
            this.rd1.Size = new System.Drawing.Size(79, 18);
            this.rd1.TabIndex = 1;
            this.rd1.TabStop = true;
            this.rd1.Text = "مدير النظام";
            this.rd1.UseVisualStyleBackColor = true;
            // 
            // rd3
            // 
            this.rd3.AutoSize = true;
            this.rd3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.rd3.Location = new System.Drawing.Point(45, 81);
            this.rd3.Name = "rd3";
            this.rd3.Size = new System.Drawing.Size(51, 18);
            this.rd3.TabIndex = 10;
            this.rd3.Text = "طالب";
            this.rd3.UseVisualStyleBackColor = true;
            // 
            // frLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(752, 407);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtUPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUID);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frLogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "  الدخول الى النظام";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.TextBox txtUPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rd3;
        private System.Windows.Forms.RadioButton rd1;
        private System.Windows.Forms.RadioButton rd2;

    }
}

