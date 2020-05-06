namespace clinic.Views.Forms
{
    partial class FormAssignService
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.dgvService = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.dgvServicesSelected = new System.Windows.Forms.DataGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicesSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(541, 248);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(119, 52);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Xong";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(300, 248);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(119, 52);
            this.btnChoose.TabIndex = 7;
            this.btnChoose.Text = "Chọn";
            this.btnChoose.UseVisualStyleBackColor = true;
            // 
            // dgvService
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.NavajoWhite;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvService.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvService.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvService.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvService.Location = new System.Drawing.Point(300, 12);
            this.dgvService.Name = "dgvService";
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.dgvService.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvService.RowTemplate.Height = 25;
            this.dgvService.Size = new System.Drawing.Size(365, 230);
            this.dgvService.TabIndex = 6;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(421, 248);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(119, 52);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Xoá";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // dgvServicesSelected
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.NavajoWhite;
            this.dgvServicesSelected.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvServicesSelected.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicesSelected.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicesSelected.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvServicesSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicesSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.columnPrice});
            this.dgvServicesSelected.Location = new System.Drawing.Point(12, 12);
            this.dgvServicesSelected.Name = "dgvServicesSelected";
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.dgvServicesSelected.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvServicesSelected.Size = new System.Drawing.Size(282, 288);
            this.dgvServicesSelected.TabIndex = 11;
            // 
            // columnName
            // 
            this.columnName.HeaderText = "Tên Dịch Vụ";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            // 
            // columnPrice
            // 
            this.columnPrice.HeaderText = "Giá Dịch Vụ";
            this.columnPrice.Name = "columnPrice";
            this.columnPrice.ReadOnly = true;
            // 
            // FormAssignService
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 305);
            this.Controls.Add(this.dgvServicesSelected);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.dgvService);
            this.Name = "FormAssignService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉ Định Dịch Vụ";
            this.Load += new System.EventHandler(this.FormAssignServices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicesSelected)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.DataGridView dgvService;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridView dgvServicesSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPrice;
    }
}