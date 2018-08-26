namespace RiverLink
{
    partial class frmSummaryDetail
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
            this.lblSummaryText = new System.Windows.Forms.Label();
            this.btnSummaryClose = new System.Windows.Forms.Button();
            this.bsSummaryData = new System.Windows.Forms.BindingSource(this.components);
            this.dgSummaryDetail = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.Transaction_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transaction_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transaction_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plaza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Journal_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transponder_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transaction_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transaction_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lane = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plate_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleClass_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsSummaryData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSummaryDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSummaryText
            // 
            this.lblSummaryText.AutoSize = true;
            this.lblSummaryText.Location = new System.Drawing.Point(13, 23);
            this.lblSummaryText.Name = "lblSummaryText";
            this.lblSummaryText.Size = new System.Drawing.Size(35, 13);
            this.lblSummaryText.TabIndex = 0;
            this.lblSummaryText.Text = "label1";
            // 
            // btnSummaryClose
            // 
            this.btnSummaryClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSummaryClose.Location = new System.Drawing.Point(713, 415);
            this.btnSummaryClose.Name = "btnSummaryClose";
            this.btnSummaryClose.Size = new System.Drawing.Size(75, 23);
            this.btnSummaryClose.TabIndex = 1;
            this.btnSummaryClose.Text = "Close";
            this.btnSummaryClose.UseVisualStyleBackColor = true;
            this.btnSummaryClose.Click += new System.EventHandler(this.btnSummaryClose_Click);
            // 
            // bsSummaryData
            // 
            this.bsSummaryData.DataSource = typeof(RiverLink.Models.Transaction);
            // 
            // dgSummaryDetail
            // 
            this.dgSummaryDetail.AllowUserToAddRows = false;
            this.dgSummaryDetail.AllowUserToDeleteRows = false;
            this.dgSummaryDetail.AllowUserToOrderColumns = true;
            this.dgSummaryDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSummaryDetail.AutoGenerateColumns = false;
            this.dgSummaryDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSummaryDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSummaryDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Transaction_Number,
            this.Transaction_Date,
            this.Transaction_Status,
            this.Plaza,
            this.Journal_Id,
            this.Transponder_Number,
            this.Transaction_Type,
            this.Amount,
            this.Transaction_Description,
            this.Lane,
            this.Plate_Number,
            this.VehicleClass_Id});
            this.dgSummaryDetail.DataSource = this.bsSummaryData;
            this.dgSummaryDetail.Location = new System.Drawing.Point(16, 60);
            this.dgSummaryDetail.Name = "dgSummaryDetail";
            this.dgSummaryDetail.ReadOnly = true;
            this.dgSummaryDetail.Size = new System.Drawing.Size(772, 338);
            this.dgSummaryDetail.TabIndex = 7;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(713, 23);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Export Data";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Transaction_Number
            // 
            this.Transaction_Number.DataPropertyName = "TransactionNumber";
            this.Transaction_Number.HeaderText = "Transaction Number";
            this.Transaction_Number.Name = "Transaction_Number";
            this.Transaction_Number.ReadOnly = true;
            // 
            // Transaction_Date
            // 
            this.Transaction_Date.DataPropertyName = "TransactionDate";
            this.Transaction_Date.HeaderText = "Transaction Date";
            this.Transaction_Date.Name = "Transaction_Date";
            this.Transaction_Date.ReadOnly = true;
            // 
            // Transaction_Status
            // 
            this.Transaction_Status.DataPropertyName = "TransactionStatus";
            this.Transaction_Status.HeaderText = "Transaction Status";
            this.Transaction_Status.Name = "Transaction_Status";
            this.Transaction_Status.ReadOnly = true;
            // 
            // Plaza
            // 
            this.Plaza.DataPropertyName = "Plaza";
            this.Plaza.HeaderText = "Plaza";
            this.Plaza.Name = "Plaza";
            this.Plaza.ReadOnly = true;
            // 
            // Journal_Id
            // 
            this.Journal_Id.DataPropertyName = "Journal_Id";
            this.Journal_Id.HeaderText = "Journal Id";
            this.Journal_Id.Name = "Journal_Id";
            this.Journal_Id.ReadOnly = true;
            // 
            // Transponder_Number
            // 
            this.Transponder_Number.DataPropertyName = "TransponderNumber";
            this.Transponder_Number.HeaderText = "Transponder Number";
            this.Transponder_Number.Name = "Transponder_Number";
            this.Transponder_Number.ReadOnly = true;
            // 
            // Transaction_Type
            // 
            this.Transaction_Type.DataPropertyName = "TransactionType";
            this.Transaction_Type.HeaderText = "Transaction Type";
            this.Transaction_Type.Name = "Transaction_Type";
            this.Transaction_Type.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Transaction_Description
            // 
            this.Transaction_Description.DataPropertyName = "TransactionDescription";
            this.Transaction_Description.HeaderText = "Transaction Description";
            this.Transaction_Description.Name = "Transaction_Description";
            this.Transaction_Description.ReadOnly = true;
            // 
            // Lane
            // 
            this.Lane.DataPropertyName = "Lane";
            this.Lane.HeaderText = "Lane";
            this.Lane.Name = "Lane";
            this.Lane.ReadOnly = true;
            // 
            // Plate_Number
            // 
            this.Plate_Number.DataPropertyName = "PlateNumber";
            this.Plate_Number.HeaderText = "Plate Number";
            this.Plate_Number.Name = "Plate_Number";
            this.Plate_Number.ReadOnly = true;
            // 
            // VehicleClass_Id
            // 
            this.VehicleClass_Id.DataPropertyName = "VehicleClass_Id";
            this.VehicleClass_Id.HeaderText = "VehicleClass Id";
            this.VehicleClass_Id.Name = "VehicleClass_Id";
            this.VehicleClass_Id.ReadOnly = true;
            // 
            // FrmSummaryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgSummaryDetail);
            this.Controls.Add(this.btnSummaryClose);
            this.Controls.Add(this.lblSummaryText);
            this.Name = "FrmSummaryDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Summary Detail";
            this.Load += new System.EventHandler(this.FrmSummaryDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsSummaryData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSummaryDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSummaryText;
        private System.Windows.Forms.Button btnSummaryClose;
        private System.Windows.Forms.BindingSource bsSummaryData;
        private System.Windows.Forms.DataGridView dgSummaryDetail;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transaction_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transaction_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transaction_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plaza;
        private System.Windows.Forms.DataGridViewTextBoxColumn Journal_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transponder_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transaction_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transaction_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lane;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plate_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleClass_Id;
    }
}