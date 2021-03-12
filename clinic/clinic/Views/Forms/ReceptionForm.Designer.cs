namespace clinic.Views.Forms
{
    partial class ReceptionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnAssignService = new System.Windows.Forms.Button();
            this.btnAddPatient = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvReception = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnPatientFiles = new System.Windows.Forms.Button();
            this.btnBills = new System.Windows.Forms.Button();
            this.btnAddPrescription = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.btnPersonality = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReception)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.Cyan;
            this.btnPay.Enabled = false;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.ForeColor = System.Drawing.Color.Black;
            this.btnPay.Location = new System.Drawing.Point(634, 453);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(128, 50);
            this.btnPay.TabIndex = 13;
            this.btnPay.Text = "Thanh Toán";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnAssignService
            // 
            this.btnAssignService.Enabled = false;
            this.btnAssignService.Location = new System.Drawing.Point(314, 452);
            this.btnAssignService.Name = "btnAssignService";
            this.btnAssignService.Size = new System.Drawing.Size(128, 50);
            this.btnAssignService.TabIndex = 12;
            this.btnAssignService.Text = " Chọn Dịch Vụ";
            this.btnAssignService.UseVisualStyleBackColor = true;
            this.btnAssignService.Click += new System.EventHandler(this.btnAssignService_Click);
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Location = new System.Drawing.Point(180, 452);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(128, 50);
            this.btnAddPatient.TabIndex = 11;
            this.btnAddPatient.Text = "Tạo Bệnh Nhân Mới";
            this.btnAddPatient.UseVisualStyleBackColor = true;
            this.btnAddPatient.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvReception);
            this.panel1.Location = new System.Drawing.Point(16, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 366);
            this.panel1.TabIndex = 10;
            // 
            // dgvReception
            // 
            this.dgvReception.AllowUserToAddRows = false;
            this.dgvReception.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.NavajoWhite;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvReception.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReception.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvReception.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvReception.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReception.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReception.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReception.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReception.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReception.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvReception.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvReception.Location = new System.Drawing.Point(0, 0);
            this.dgvReception.MultiSelect = false;
            this.dgvReception.Name = "dgvReception";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvReception.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReception.RowTemplate.Height = 25;
            this.dgvReception.Size = new System.Drawing.Size(746, 366);
            this.dgvReception.TabIndex = 0;
            this.dgvReception.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReception_CellDoubleClick);
            this.dgvReception.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReception_CellEnter);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnLogout, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPatientFiles, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnBills, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(42, -1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(701, 38);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LightGreen;
            this.btnLogout.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnLogout.Location = new System.Drawing.Point(469, 3);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(229, 32);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "ĐĂNG XUẤT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnPatientFiles
            // 
            this.btnPatientFiles.BackColor = System.Drawing.Color.LightGreen;
            this.btnPatientFiles.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatientFiles.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnPatientFiles.Location = new System.Drawing.Point(3, 3);
            this.btnPatientFiles.Name = "btnPatientFiles";
            this.btnPatientFiles.Size = new System.Drawing.Size(227, 32);
            this.btnPatientFiles.TabIndex = 1;
            this.btnPatientFiles.Text = "HỒ SƠ BỆNH";
            this.btnPatientFiles.UseVisualStyleBackColor = false;
            this.btnPatientFiles.Click += new System.EventHandler(this.btnPatientFiles_Click);
            // 
            // btnBills
            // 
            this.btnBills.BackColor = System.Drawing.Color.LightGreen;
            this.btnBills.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBills.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnBills.Location = new System.Drawing.Point(236, 3);
            this.btnBills.Name = "btnBills";
            this.btnBills.Size = new System.Drawing.Size(227, 32);
            this.btnBills.TabIndex = 2;
            this.btnBills.Text = "DANH SÁCH HOÁ ĐƠN";
            this.btnBills.UseVisualStyleBackColor = false;
            this.btnBills.Click += new System.EventHandler(this.btnBills_Click);
            // 
            // btnAddPrescription
            // 
            this.btnAddPrescription.Enabled = false;
            this.btnAddPrescription.Location = new System.Drawing.Point(449, 453);
            this.btnAddPrescription.Name = "btnAddPrescription";
            this.btnAddPrescription.Size = new System.Drawing.Size(128, 50);
            this.btnAddPrescription.TabIndex = 14;
            this.btnAddPrescription.Text = "Tạo Toa Thuốc";
            this.btnAddPrescription.UseVisualStyleBackColor = true;
            this.btnAddPrescription.Click += new System.EventHandler(this.btnAddPrescription_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(261, 415);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(214, 20);
            this.txtSearch.TabIndex = 15;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(481, 415);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 23);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbSearch
            // 
            this.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "SDT",
            "Tên"});
            this.cbSearch.Location = new System.Drawing.Point(192, 414);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(63, 24);
            this.cbSearch.TabIndex = 17;
            // 
            // btnPersonality
            // 
            this.btnPersonality.BackColor = System.Drawing.Color.HotPink;
            this.btnPersonality.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonality.ForeColor = System.Drawing.Color.Black;
            this.btnPersonality.Location = new System.Drawing.Point(26, 453);
            this.btnPersonality.Name = "btnPersonality";
            this.btnPersonality.Size = new System.Drawing.Size(128, 50);
            this.btnPersonality.TabIndex = 18;
            this.btnPersonality.Text = "Cá Nhân";
            this.btnPersonality.UseVisualStyleBackColor = false;
            this.btnPersonality.Click += new System.EventHandler(this.btnPersonality_Click);
            // 
            // ReceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 515);
            this.Controls.Add(this.btnAddPatient);
            this.Controls.Add(this.btnPersonality);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnAddPrescription);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnAssignService);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ReceptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiếp Nhận Bệnh";
            this.Load += new System.EventHandler(this.ReceptionForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReception)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnAssignService;
        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvReception;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnPatientFiles;
        private System.Windows.Forms.Button btnBills;
        private System.Windows.Forms.Button btnAddPrescription;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Button btnPersonality;
    }
}