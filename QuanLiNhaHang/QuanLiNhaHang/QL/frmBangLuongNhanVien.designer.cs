
namespace DoAnQuanLyNhanVien
{
    partial class frmBangLuongNhanVien
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
            this.dgvBangLuongNV = new System.Windows.Forms.DataGridView();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.btnWordExport = new System.Windows.Forms.Button();
            this.btnPDFExport = new System.Windows.Forms.Button();
            this.btnPrinter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangLuongNV)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBangLuongNV
            // 
            this.dgvBangLuongNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangLuongNV.Location = new System.Drawing.Point(61, 47);
            this.dgvBangLuongNV.Name = "dgvBangLuongNV";
            this.dgvBangLuongNV.ReadOnly = true;
            this.dgvBangLuongNV.RowHeadersWidth = 51;
            this.dgvBangLuongNV.RowTemplate.Height = 24;
            this.dgvBangLuongNV.Size = new System.Drawing.Size(913, 504);
            this.dgvBangLuongNV.TabIndex = 0;
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcelExport.ForeColor = System.Drawing.Color.Blue;
            this.btnExcelExport.Location = new System.Drawing.Point(61, 580);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(164, 47);
            this.btnExcelExport.TabIndex = 1;
            this.btnExcelExport.Text = "In ra Excel";
            this.btnExcelExport.UseVisualStyleBackColor = true;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // btnWordExport
            // 
            this.btnWordExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWordExport.ForeColor = System.Drawing.Color.Blue;
            this.btnWordExport.Location = new System.Drawing.Point(307, 580);
            this.btnWordExport.Name = "btnWordExport";
            this.btnWordExport.Size = new System.Drawing.Size(164, 47);
            this.btnWordExport.TabIndex = 2;
            this.btnWordExport.Text = "In ra Word";
            this.btnWordExport.UseVisualStyleBackColor = true;
            this.btnWordExport.Click += new System.EventHandler(this.btnWordExport_Click);
            // 
            // btnPDFExport
            // 
            this.btnPDFExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDFExport.ForeColor = System.Drawing.Color.Blue;
            this.btnPDFExport.Location = new System.Drawing.Point(563, 580);
            this.btnPDFExport.Name = "btnPDFExport";
            this.btnPDFExport.Size = new System.Drawing.Size(164, 47);
            this.btnPDFExport.TabIndex = 3;
            this.btnPDFExport.Text = "In ra PDF";
            this.btnPDFExport.UseVisualStyleBackColor = true;
            this.btnPDFExport.Click += new System.EventHandler(this.btnPDFExport_Click);
            // 
            // btnPrinter
            // 
            this.btnPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrinter.ForeColor = System.Drawing.Color.Blue;
            this.btnPrinter.Location = new System.Drawing.Point(810, 580);
            this.btnPrinter.Name = "btnPrinter";
            this.btnPrinter.Size = new System.Drawing.Size(164, 47);
            this.btnPrinter.TabIndex = 5;
            this.btnPrinter.Text = "To print";
            this.btnPrinter.UseVisualStyleBackColor = true;
            this.btnPrinter.Click += new System.EventHandler(this.btnPrinter_Click);
            // 
            // frmBangLuongNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 677);
            this.Controls.Add(this.btnPrinter);
            this.Controls.Add(this.btnPDFExport);
            this.Controls.Add(this.btnWordExport);
            this.Controls.Add(this.btnExcelExport);
            this.Controls.Add(this.dgvBangLuongNV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBangLuongNhanVien";
            this.Text = "frmBangLuongNhanVien";
            this.Load += new System.EventHandler(this.frmBangLuongNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangLuongNV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBangLuongNV;
        private System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.Button btnWordExport;
        private System.Windows.Forms.Button btnPDFExport;
        private System.Windows.Forms.Button btnPrinter;
    }
}