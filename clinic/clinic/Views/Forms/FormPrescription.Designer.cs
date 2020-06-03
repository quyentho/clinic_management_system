namespace clinic.Views.Forms
{
    partial class FormPrescription
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMedicinesSelected = new System.Windows.Forms.DataGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.dgvMedicine = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicinesSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicine)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMedicinesSelected
            // 
            this.dgvMedicinesSelected.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.NavajoWhite;
            this.dgvMedicinesSelected.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMedicinesSelected.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicinesSelected.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMedicinesSelected.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMedicinesSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicinesSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.columnPrice,
            this.columnQuantity,
            this.columnDosage});
            this.dgvMedicinesSelected.Location = new System.Drawing.Point(9, 12);
            this.dgvMedicinesSelected.Name = "dgvMedicinesSelected";
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.dgvMedicinesSelected.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMedicinesSelected.Size = new System.Drawing.Size(434, 306);
            this.dgvMedicinesSelected.TabIndex = 16;
            this.dgvMedicinesSelected.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicinesSelected_CellEnter);
            this.dgvMedicinesSelected.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvMedicinesSelected_RowsAdded);
            this.dgvMedicinesSelected.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvMedicinesSelected_RowsRemoved);
            // 
            // columnName
            // 
            this.columnName.FillWeight = 99.49239F;
            this.columnName.HeaderText = "Tên Thuốc";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            // 
            // columnPrice
            // 
            this.columnPrice.FillWeight = 101.5228F;
            this.columnPrice.HeaderText = "Giá";
            this.columnPrice.Name = "columnPrice";
            this.columnPrice.ReadOnly = true;
            // 
            // columnQuantity
            // 
            this.columnQuantity.FillWeight = 99.49239F;
            this.columnQuantity.HeaderText = "Số Lượng";
            this.columnQuantity.Name = "columnQuantity";
            // 
            // columnDosage
            // 
            this.columnDosage.FillWeight = 99.49239F;
            this.columnDosage.HeaderText = "Liều lượng";
            this.columnDosage.Name = "columnDosage";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(649, 274);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(119, 52);
            this.btnRemove.TabIndex = 15;
            this.btnRemove.Text = "Loại bỏ";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(774, 274);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(119, 52);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "Xong";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(528, 274);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(119, 52);
            this.btnChoose.TabIndex = 13;
            this.btnChoose.Text = "Chọn";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // dgvMedicine
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.NavajoWhite;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvMedicine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMedicine.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvMedicine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicine.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMedicine.Location = new System.Drawing.Point(449, 12);
            this.dgvMedicine.Name = "dgvMedicine";
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.dgvMedicine.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMedicine.RowTemplate.Height = 25;
            this.dgvMedicine.Size = new System.Drawing.Size(483, 230);
            this.dgvMedicine.TabIndex = 12;
            this.dgvMedicine.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicine_CellEnter);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(595, 248);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(222, 20);
            this.txtSearch.TabIndex = 17;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // FormPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 330);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvMedicinesSelected);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.dgvMedicine);
            this.Name = "FormPrescription";
            this.Text = "FormPrescription";
            this.Load += new System.EventHandler(this.FormPrescription_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicinesSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMedicinesSelected;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.DataGridView dgvMedicine;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDosage;
    }
}