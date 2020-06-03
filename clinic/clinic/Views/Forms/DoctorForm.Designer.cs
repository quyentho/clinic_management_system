namespace clinic.Views.Forms
{
    partial class DoctorForm
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
            this.btnPatientFiles = new System.Windows.Forms.Button();
            this.btnAssignService = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvReception = new System.Windows.Forms.DataGridView();
            this.btnLogout = new System.Windows.Forms.Button();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAddPrescription = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReception)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPatientFiles
            // 
            this.btnPatientFiles.BackColor = System.Drawing.Color.LightGreen;
            this.btnPatientFiles.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatientFiles.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnPatientFiles.Location = new System.Drawing.Point(199, 9);
            this.btnPatientFiles.Name = "btnPatientFiles";
            this.btnPatientFiles.Size = new System.Drawing.Size(227, 32);
            this.btnPatientFiles.TabIndex = 1;
            this.btnPatientFiles.Text = "HỒ SƠ BỆNH";
            this.btnPatientFiles.UseVisualStyleBackColor = false;
            // 
            // btnAssignService
            // 
            this.btnAssignService.Enabled = false;
            this.btnAssignService.Location = new System.Drawing.Point(281, 462);
            this.btnAssignService.Name = "btnAssignService";
            this.btnAssignService.Size = new System.Drawing.Size(128, 50);
            this.btnAssignService.TabIndex = 21;
            this.btnAssignService.Text = " Chọn Dịch Vụ";
            this.btnAssignService.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvReception);
            this.panel1.Location = new System.Drawing.Point(55, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 366);
            this.panel1.TabIndex = 19;
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
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LightGreen;
            this.btnLogout.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnLogout.Location = new System.Drawing.Point(432, 9);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(229, 32);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "ĐĂNG XUẤT";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // cbSearch
            // 
            this.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "SDT",
            "Tên"});
            this.cbSearch.Location = new System.Drawing.Point(231, 418);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(63, 24);
            this.cbSearch.TabIndex = 26;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(520, 419);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 23);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(300, 419);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(214, 20);
            this.txtSearch.TabIndex = 24;
            // 
            // btnAddPrescription
            // 
            this.btnAddPrescription.Enabled = false;
            this.btnAddPrescription.Location = new System.Drawing.Point(416, 462);
            this.btnAddPrescription.Name = "btnAddPrescription";
            this.btnAddPrescription.Size = new System.Drawing.Size(128, 50);
            this.btnAddPrescription.TabIndex = 23;
            this.btnAddPrescription.Text = "Tạo Toa Thuốc";
            this.btnAddPrescription.UseVisualStyleBackColor = true;
            // 
            // DoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 520);
            this.Controls.Add(this.btnPatientFiles);
            this.Controls.Add(this.btnAssignService);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnAddPrescription);
            this.Name = "DoctorForm";
            this.Text = "DoctorForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReception)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPatientFiles;
        private System.Windows.Forms.Button btnAssignService;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvReception;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAddPrescription;
    }
}