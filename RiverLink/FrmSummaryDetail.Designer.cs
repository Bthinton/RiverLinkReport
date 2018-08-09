namespace RiverLink
{
    partial class FrmSummaryDetail
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
            this.transactionNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plazaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.journalIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transponderNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.laneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plateNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleClassIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.transactionNumberDataGridViewTextBoxColumn,
            this.transactionDateDataGridViewTextBoxColumn,
            this.transactionStatusDataGridViewTextBoxColumn,
            this.plazaDataGridViewTextBoxColumn,
            this.journalIdDataGridViewTextBoxColumn,
            this.transponderNumberDataGridViewTextBoxColumn,
            this.transactionTypeDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.transactionDescriptionDataGridViewTextBoxColumn,
            this.laneDataGridViewTextBoxColumn,
            this.plateNumberDataGridViewTextBoxColumn,
            this.vehicleClassIdDataGridViewTextBoxColumn});
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
            // transactionNumberDataGridViewTextBoxColumn
            // 
            this.transactionNumberDataGridViewTextBoxColumn.DataPropertyName = "TransactionNumber";
            this.transactionNumberDataGridViewTextBoxColumn.HeaderText = "Transaction Number";
            this.transactionNumberDataGridViewTextBoxColumn.Name = "transactionNumberDataGridViewTextBoxColumn";
            this.transactionNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionDateDataGridViewTextBoxColumn
            // 
            this.transactionDateDataGridViewTextBoxColumn.DataPropertyName = "TransactionDate";
            this.transactionDateDataGridViewTextBoxColumn.HeaderText = "Transaction Date";
            this.transactionDateDataGridViewTextBoxColumn.Name = "transactionDateDataGridViewTextBoxColumn";
            this.transactionDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionStatusDataGridViewTextBoxColumn
            // 
            this.transactionStatusDataGridViewTextBoxColumn.DataPropertyName = "TransactionStatus";
            this.transactionStatusDataGridViewTextBoxColumn.HeaderText = "Transaction Status";
            this.transactionStatusDataGridViewTextBoxColumn.Name = "transactionStatusDataGridViewTextBoxColumn";
            this.transactionStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // plazaDataGridViewTextBoxColumn
            // 
            this.plazaDataGridViewTextBoxColumn.DataPropertyName = "Plaza";
            this.plazaDataGridViewTextBoxColumn.HeaderText = "Plaza";
            this.plazaDataGridViewTextBoxColumn.Name = "plazaDataGridViewTextBoxColumn";
            this.plazaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // journalIdDataGridViewTextBoxColumn
            // 
            this.journalIdDataGridViewTextBoxColumn.DataPropertyName = "Journal_Id";
            this.journalIdDataGridViewTextBoxColumn.HeaderText = "Journal Id";
            this.journalIdDataGridViewTextBoxColumn.Name = "journalIdDataGridViewTextBoxColumn";
            this.journalIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transponderNumberDataGridViewTextBoxColumn
            // 
            this.transponderNumberDataGridViewTextBoxColumn.DataPropertyName = "TransponderNumber";
            this.transponderNumberDataGridViewTextBoxColumn.HeaderText = "Transponder Number";
            this.transponderNumberDataGridViewTextBoxColumn.Name = "transponderNumberDataGridViewTextBoxColumn";
            this.transponderNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionTypeDataGridViewTextBoxColumn
            // 
            this.transactionTypeDataGridViewTextBoxColumn.DataPropertyName = "TransactionType";
            this.transactionTypeDataGridViewTextBoxColumn.HeaderText = "Transaction Type";
            this.transactionTypeDataGridViewTextBoxColumn.Name = "transactionTypeDataGridViewTextBoxColumn";
            this.transactionTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionDescriptionDataGridViewTextBoxColumn
            // 
            this.transactionDescriptionDataGridViewTextBoxColumn.DataPropertyName = "TransactionDescription";
            this.transactionDescriptionDataGridViewTextBoxColumn.HeaderText = "Transaction Description";
            this.transactionDescriptionDataGridViewTextBoxColumn.Name = "transactionDescriptionDataGridViewTextBoxColumn";
            this.transactionDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // laneDataGridViewTextBoxColumn
            // 
            this.laneDataGridViewTextBoxColumn.DataPropertyName = "Lane";
            this.laneDataGridViewTextBoxColumn.HeaderText = "Lane";
            this.laneDataGridViewTextBoxColumn.Name = "laneDataGridViewTextBoxColumn";
            this.laneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // plateNumberDataGridViewTextBoxColumn
            // 
            this.plateNumberDataGridViewTextBoxColumn.DataPropertyName = "PlateNumber";
            this.plateNumberDataGridViewTextBoxColumn.HeaderText = "Plate Number";
            this.plateNumberDataGridViewTextBoxColumn.Name = "plateNumberDataGridViewTextBoxColumn";
            this.plateNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vehicleClassIdDataGridViewTextBoxColumn
            // 
            this.vehicleClassIdDataGridViewTextBoxColumn.DataPropertyName = "VehicleClass_Id";
            this.vehicleClassIdDataGridViewTextBoxColumn.HeaderText = "VehicleClass Id";
            this.vehicleClassIdDataGridViewTextBoxColumn.Name = "vehicleClassIdDataGridViewTextBoxColumn";
            this.vehicleClassIdDataGridViewTextBoxColumn.ReadOnly = true;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plazaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn journalIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transponderNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn laneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plateNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleClassIdDataGridViewTextBoxColumn;
    }
}