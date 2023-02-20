
namespace QuanLiNhaHang
{
    partial class Login_Form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonNV = new System.Windows.Forms.RadioButton();
            this.radioButtonQL = new System.Windows.Forms.RadioButton();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonclose = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxAnPass = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 530);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nguyễn Phước Công - 20110447";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Develop by";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.radioButtonNV);
            this.panel2.Controls.Add(this.radioButtonQL);
            this.panel2.Controls.Add(this.buttonLogin);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.buttonclose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(300, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 530);
            this.panel2.TabIndex = 1;
            // 
            // radioButtonNV
            // 
            this.radioButtonNV.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonNV.ForeColor = System.Drawing.Color.Teal;
            this.radioButtonNV.Location = new System.Drawing.Point(182, 286);
            this.radioButtonNV.Name = "radioButtonNV";
            this.radioButtonNV.Size = new System.Drawing.Size(194, 41);
            this.radioButtonNV.TabIndex = 6;
            this.radioButtonNV.TabStop = true;
            this.radioButtonNV.Text = "Nhân Viên";
            this.radioButtonNV.UseVisualStyleBackColor = false;
            // 
            // radioButtonQL
            // 
            this.radioButtonQL.Checked = true;
            this.radioButtonQL.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonQL.ForeColor = System.Drawing.Color.Teal;
            this.radioButtonQL.Location = new System.Drawing.Point(10, 291);
            this.radioButtonQL.Name = "radioButtonQL";
            this.radioButtonQL.Size = new System.Drawing.Size(161, 36);
            this.radioButtonQL.TabIndex = 5;
            this.radioButtonQL.TabStop = true;
            this.radioButtonQL.Text = "Quản Lý";
            this.radioButtonQL.UseVisualStyleBackColor = false;
            this.radioButtonQL.CheckedChanged += new System.EventHandler(this.radioButtonQL_CheckedChanged);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Teal;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(15, 347);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(148, 35);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "LOGIN";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Controls.Add(this.textBoxPass);
            this.panel4.Controls.Add(this.pictureBoxAnPass);
            this.panel4.Location = new System.Drawing.Point(0, 235);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(450, 45);
            this.panel4.TabIndex = 3;
            // 
            // textBoxPass
            // 
            this.textBoxPass.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPass.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.textBoxPass.Location = new System.Drawing.Point(45, 14);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(370, 21);
            this.textBoxPass.TabIndex = 4;
            this.textBoxPass.Click += new System.EventHandler(this.textBoxPass_Click);
            this.textBoxPass.Enter += new System.EventHandler(this.textBoxPass_Enter);
            this.textBoxPass.Leave += new System.EventHandler(this.textBoxPass_Leave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.textBoxUser);
            this.panel3.Location = new System.Drawing.Point(0, 185);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 45);
            this.panel3.TabIndex = 2;
            // 
            // textBoxUser
            // 
            this.textBoxUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUser.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.textBoxUser.Location = new System.Drawing.Point(45, 14);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(370, 21);
            this.textBoxUser.TabIndex = 2;
            this.textBoxUser.Click += new System.EventHandler(this.textBoxUser_Click);
            this.textBoxUser.Enter += new System.EventHandler(this.textBoxUser_Enter);
            this.textBoxUser.Leave += new System.EventHandler(this.textBoxUser_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Teal;
            this.label6.Location = new System.Drawing.Point(6, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "Login to your account";
            // 
            // buttonclose
            // 
            this.buttonclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonclose.FlatAppearance.BorderSize = 0;
            this.buttonclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonclose.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.buttonclose.Location = new System.Drawing.Point(410, 0);
            this.buttonclose.Name = "buttonclose";
            this.buttonclose.Size = new System.Drawing.Size(40, 40);
            this.buttonclose.TabIndex = 0;
            this.buttonclose.Text = "X";
            this.buttonclose.UseVisualStyleBackColor = true;
            this.buttonclose.Click += new System.EventHandler(this.buttonclose_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(15, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBoxAnPass
            // 
            this.pictureBoxAnPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxAnPass.Location = new System.Drawing.Point(421, 11);
            this.pictureBoxAnPass.Name = "pictureBoxAnPass";
            this.pictureBoxAnPass.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxAnPass.TabIndex = 4;
            this.pictureBoxAnPass.TabStop = false;
            this.pictureBoxAnPass.Click += new System.EventHandler(this.pictureBoxAnPass_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(15, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::QuanLiNhaHang.Properties.Resources.f9bc59f6a050610e3841;
            this.pictureBox1.Location = new System.Drawing.Point(39, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 232);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 436);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nguyễn Nhật Tính - 20110576";
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 530);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login_Form";
            this.Load += new System.EventHandler(this.Login_Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonclose;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.PictureBox pictureBoxAnPass;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.RadioButton radioButtonNV;
        private System.Windows.Forms.RadioButton radioButtonQL;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
    }
}