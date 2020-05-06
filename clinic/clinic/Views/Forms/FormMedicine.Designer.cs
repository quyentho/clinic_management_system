namespace clinic
{
    partial class FormMedicine
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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMedicineName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEntryQuantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtEntryUnit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtEntryPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtSaleUnit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtExpiryDay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtExchangeRatio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMedicineName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 45);
            this.panel2.TabIndex = 0;
            this.panel2.TabStop = true;
            // 
            // txtMedicineName
            // 
            this.txtMedicineName.Location = new System.Drawing.Point(105, 13);
            this.txtMedicineName.Name = "txtMedicineName";
            this.txtMedicineName.Size = new System.Drawing.Size(214, 20);
            this.txtMedicineName.TabIndex = 0;
            this.txtMedicineName.Validating += new System.ComponentModel.CancelEventHandler(this.txtMedicineName_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Thuốc";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtEntryQuantity);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(394, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 45);
            this.panel1.TabIndex = 1;
            this.panel1.TabStop = true;
            // 
            // txtEntryQuantity
            // 
            this.txtEntryQuantity.Location = new System.Drawing.Point(105, 13);
            this.txtEntryQuantity.Name = "txtEntryQuantity";
            this.txtEntryQuantity.Size = new System.Drawing.Size(214, 20);
            this.txtEntryQuantity.TabIndex = 0;
            this.txtEntryQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtEntryQuantity_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số lượng nhập";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtEntryUnit);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(12, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 45);
            this.panel3.TabIndex = 2;
            this.panel3.TabStop = true;
            // 
            // txtEntryUnit
            // 
            this.txtEntryUnit.Location = new System.Drawing.Point(105, 13);
            this.txtEntryUnit.Name = "txtEntryUnit";
            this.txtEntryUnit.Size = new System.Drawing.Size(214, 20);
            this.txtEntryUnit.TabIndex = 0;
            this.txtEntryUnit.Validating += new System.ComponentModel.CancelEventHandler(this.txtEntryUnit_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Đơn vị nhập";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtEntryPrice);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(12, 114);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(350, 45);
            this.panel4.TabIndex = 4;
            this.panel4.TabStop = true;
            // 
            // txtEntryPrice
            // 
            this.txtEntryPrice.Location = new System.Drawing.Point(105, 13);
            this.txtEntryPrice.Name = "txtEntryPrice";
            this.txtEntryPrice.Size = new System.Drawing.Size(214, 20);
            this.txtEntryPrice.TabIndex = 0;
            this.txtEntryPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtEntryPrice_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Giá nhập";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(417, 216);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 42);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(237, 216);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 42);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "Xong";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtSaleUnit);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(394, 63);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(350, 45);
            this.panel5.TabIndex = 3;
            this.panel5.TabStop = true;
            // 
            // txtSaleUnit
            // 
            this.txtSaleUnit.Location = new System.Drawing.Point(105, 13);
            this.txtSaleUnit.Name = "txtSaleUnit";
            this.txtSaleUnit.Size = new System.Drawing.Size(214, 20);
            this.txtSaleUnit.TabIndex = 0;
            this.txtSaleUnit.Validating += new System.ComponentModel.CancelEventHandler(this.txtSaleUnit_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Đơn vị bán";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtSalePrice);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(394, 114);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(350, 45);
            this.panel6.TabIndex = 5;
            this.panel6.TabStop = true;
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Location = new System.Drawing.Point(105, 13);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(214, 20);
            this.txtSalePrice.TabIndex = 0;
            this.txtSalePrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtSalePrice_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Giá bán";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtExpiryDay);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(12, 165);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(350, 45);
            this.panel7.TabIndex = 6;
            this.panel7.TabStop = true;
            // 
            // txtExpiryDay
            // 
            this.txtExpiryDay.Location = new System.Drawing.Point(105, 13);
            this.txtExpiryDay.Name = "txtExpiryDay";
            this.txtExpiryDay.Size = new System.Drawing.Size(214, 20);
            this.txtExpiryDay.TabIndex = 0;
            this.txtExpiryDay.Validating += new System.ComponentModel.CancelEventHandler(this.txtExpiryDay_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Hạn Sử Dụng";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtExchangeRatio);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Location = new System.Drawing.Point(394, 165);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(350, 45);
            this.panel8.TabIndex = 7;
            this.panel8.TabStop = true;
            // 
            // txtExchangeRatio
            // 
            this.txtExchangeRatio.Location = new System.Drawing.Point(106, 13);
            this.txtExchangeRatio.Name = "txtExchangeRatio";
            this.txtExchangeRatio.Size = new System.Drawing.Size(214, 20);
            this.txtExchangeRatio.TabIndex = 0;
            this.txtExchangeRatio.Validating += new System.ComponentModel.CancelEventHandler(this.txtExchangeRatio_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tỷ lệ nhập/bán";
            // 
            // FormMedicine
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(766, 269);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMedicine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thuốc";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMedicine_FormClosed);
            this.Load += new System.EventHandler(this.FormMedicine_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMedicineName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtEntryQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtEntryUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtEntryPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtSaleUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtExpiryDay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtExchangeRatio;
        private System.Windows.Forms.Label label8;
    }
}