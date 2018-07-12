namespace RiverLink
{
    partial class frmMain
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
            this.bsYear = new System.Windows.Forms.BindingSource(this.components);
            this.bsMonth = new System.Windows.Forms.BindingSource(this.components);
            this.bsTransponderNumber = new System.Windows.Forms.BindingSource(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.bsTransaction = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbTolls = new System.Windows.Forms.TabPage();
            this.tbVehicles = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTransponder = new System.Windows.Forms.ComboBox();
            this.transactionNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleClassIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plateNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.laneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transponderNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.journalIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plazaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTransactions = new System.Windows.Forms.DataGridView();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bsYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransponderNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransaction)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tbTolls.SuspendLayout();
            this.tbVehicles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(815, 441);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // bsTransaction
            // 
            this.bsTransaction.DataSource = typeof(RiverLink.Models.Transaction);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbTolls);
            this.tabControl1.Controls.Add(this.tbVehicles);
            this.tabControl1.Location = new System.Drawing.Point(26, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(864, 411);
            this.tabControl1.TabIndex = 8;
            // 
            // tbTolls
            // 
            this.tbTolls.AccessibleName = "";
            this.tbTolls.Controls.Add(this.cmbYear);
            this.tbTolls.Controls.Add(this.label1);
            this.tbTolls.Controls.Add(this.dgTransactions);
            this.tbTolls.Controls.Add(this.label2);
            this.tbTolls.Controls.Add(this.cmbTransponder);
            this.tbTolls.Controls.Add(this.cmbMonth);
            this.tbTolls.Controls.Add(this.label3);
            this.tbTolls.Location = new System.Drawing.Point(4, 22);
            this.tbTolls.Name = "tbTolls";
            this.tbTolls.Padding = new System.Windows.Forms.Padding(3);
            this.tbTolls.Size = new System.Drawing.Size(856, 385);
            this.tbTolls.TabIndex = 0;
            this.tbTolls.Text = "Tolls";
            this.tbTolls.UseVisualStyleBackColor = true;
            // 
            // tbVehicles
            // 
            this.tbVehicles.Controls.Add(this.dataGridView1);
            this.tbVehicles.Location = new System.Drawing.Point(4, 22);
            this.tbVehicles.Name = "tbVehicles";
            this.tbVehicles.Padding = new System.Windows.Forms.Padding(3);
            this.tbVehicles.Size = new System.Drawing.Size(856, 385);
            this.tbVehicles.TabIndex = 1;
            this.tbVehicles.Text = "Vehicles";
            this.tbVehicles.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Month";
            // 
            // cmbMonth
            // 
            this.cmbMonth.DataSource = this.bsMonth;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(165, 30);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(121, 21);
            this.cmbMonth.TabIndex = 3;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Transponder";
            // 
            // cmbTransponder
            // 
            this.cmbTransponder.DataSource = this.bsTransponderNumber;
            this.cmbTransponder.FormattingEnabled = true;
            this.cmbTransponder.Location = new System.Drawing.Point(306, 30);
            this.cmbTransponder.Name = "cmbTransponder";
            this.cmbTransponder.Size = new System.Drawing.Size(121, 21);
            this.cmbTransponder.TabIndex = 5;
            this.cmbTransponder.SelectedIndexChanged += new System.EventHandler(this.cmbTransponder_SelectedIndexChanged_1);
            // 
            // transactionNumberDataGridViewTextBoxColumn
            // 
            this.transactionNumberDataGridViewTextBoxColumn.DataPropertyName = "TransactionNumber";
            this.transactionNumberDataGridViewTextBoxColumn.HeaderText = "TransactionNumber";
            this.transactionNumberDataGridViewTextBoxColumn.Name = "transactionNumberDataGridViewTextBoxColumn";
            this.transactionNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vehicleClassIdDataGridViewTextBoxColumn
            // 
            this.vehicleClassIdDataGridViewTextBoxColumn.DataPropertyName = "VehicleClass_Id";
            this.vehicleClassIdDataGridViewTextBoxColumn.HeaderText = "VehicleClass_Id";
            this.vehicleClassIdDataGridViewTextBoxColumn.Name = "vehicleClassIdDataGridViewTextBoxColumn";
            this.vehicleClassIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // plateNumberDataGridViewTextBoxColumn
            // 
            this.plateNumberDataGridViewTextBoxColumn.DataPropertyName = "PlateNumber";
            this.plateNumberDataGridViewTextBoxColumn.HeaderText = "PlateNumber";
            this.plateNumberDataGridViewTextBoxColumn.Name = "plateNumberDataGridViewTextBoxColumn";
            this.plateNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // laneDataGridViewTextBoxColumn
            // 
            this.laneDataGridViewTextBoxColumn.DataPropertyName = "Lane";
            this.laneDataGridViewTextBoxColumn.HeaderText = "Lane";
            this.laneDataGridViewTextBoxColumn.Name = "laneDataGridViewTextBoxColumn";
            this.laneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionDescriptionDataGridViewTextBoxColumn
            // 
            this.transactionDescriptionDataGridViewTextBoxColumn.DataPropertyName = "TransactionDescription";
            this.transactionDescriptionDataGridViewTextBoxColumn.HeaderText = "TransactionDescription";
            this.transactionDescriptionDataGridViewTextBoxColumn.Name = "transactionDescriptionDataGridViewTextBoxColumn";
            this.transactionDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionTypeDataGridViewTextBoxColumn
            // 
            this.transactionTypeDataGridViewTextBoxColumn.DataPropertyName = "TransactionType";
            this.transactionTypeDataGridViewTextBoxColumn.HeaderText = "TransactionType";
            this.transactionTypeDataGridViewTextBoxColumn.Name = "transactionTypeDataGridViewTextBoxColumn";
            this.transactionTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transponderNumberDataGridViewTextBoxColumn
            // 
            this.transponderNumberDataGridViewTextBoxColumn.DataPropertyName = "TransponderNumber";
            this.transponderNumberDataGridViewTextBoxColumn.HeaderText = "TransponderNumber";
            this.transponderNumberDataGridViewTextBoxColumn.Name = "transponderNumberDataGridViewTextBoxColumn";
            this.transponderNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // journalIdDataGridViewTextBoxColumn
            // 
            this.journalIdDataGridViewTextBoxColumn.DataPropertyName = "Journal_Id";
            this.journalIdDataGridViewTextBoxColumn.HeaderText = "Journal_Id";
            this.journalIdDataGridViewTextBoxColumn.Name = "journalIdDataGridViewTextBoxColumn";
            this.journalIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // plazaDataGridViewTextBoxColumn
            // 
            this.plazaDataGridViewTextBoxColumn.DataPropertyName = "Plaza";
            this.plazaDataGridViewTextBoxColumn.HeaderText = "Plaza";
            this.plazaDataGridViewTextBoxColumn.Name = "plazaDataGridViewTextBoxColumn";
            this.plazaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionStatusDataGridViewTextBoxColumn
            // 
            this.transactionStatusDataGridViewTextBoxColumn.DataPropertyName = "TransactionStatus";
            this.transactionStatusDataGridViewTextBoxColumn.HeaderText = "TransactionStatus";
            this.transactionStatusDataGridViewTextBoxColumn.Name = "transactionStatusDataGridViewTextBoxColumn";
            this.transactionStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // postedDateDataGridViewTextBoxColumn
            // 
            this.postedDateDataGridViewTextBoxColumn.DataPropertyName = "PostedDate";
            this.postedDateDataGridViewTextBoxColumn.HeaderText = "PostedDate";
            this.postedDateDataGridViewTextBoxColumn.Name = "postedDateDataGridViewTextBoxColumn";
            this.postedDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionDateDataGridViewTextBoxColumn
            // 
            this.transactionDateDataGridViewTextBoxColumn.DataPropertyName = "TransactionDate";
            this.transactionDateDataGridViewTextBoxColumn.HeaderText = "TransactionDate";
            this.transactionDateDataGridViewTextBoxColumn.Name = "transactionDateDataGridViewTextBoxColumn";
            this.transactionDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionIdDataGridViewTextBoxColumn
            // 
            this.transactionIdDataGridViewTextBoxColumn.DataPropertyName = "Transaction_Id";
            this.transactionIdDataGridViewTextBoxColumn.HeaderText = "Transaction_Id";
            this.transactionIdDataGridViewTextBoxColumn.Name = "transactionIdDataGridViewTextBoxColumn";
            this.transactionIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dgTransactions
            // 
            this.dgTransactions.AllowUserToAddRows = false;
            this.dgTransactions.AllowUserToDeleteRows = false;
            this.dgTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTransactions.AutoGenerateColumns = false;
            this.dgTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transactionIdDataGridViewTextBoxColumn,
            this.transactionDateDataGridViewTextBoxColumn,
            this.postedDateDataGridViewTextBoxColumn,
            this.transactionStatusDataGridViewTextBoxColumn,
            this.plazaDataGridViewTextBoxColumn,
            this.journalIdDataGridViewTextBoxColumn,
            this.transponderNumberDataGridViewTextBoxColumn,
            this.transactionTypeDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.transactionDescriptionDataGridViewTextBoxColumn,
            this.laneDataGridViewTextBoxColumn,
            this.plateNumberDataGridViewTextBoxColumn,
            this.vehicleClassIdDataGridViewTextBoxColumn,
            this.transactionNumberDataGridViewTextBoxColumn});
            this.dgTransactions.DataSource = this.bsTransaction;
            this.dgTransactions.Location = new System.Drawing.Point(22, 60);
            this.dgTransactions.Name = "dgTransactions";
            this.dgTransactions.ReadOnly = true;
            this.dgTransactions.Size = new System.Drawing.Size(811, 322);
            this.dgTransactions.TabIndex = 6;
            // 
            // cmbYear
            // 
            this.cmbYear.DataSource = this.bsYear;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(22, 30);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(121, 21);
            this.cmbYear.TabIndex = 10;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Year";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(819, 327);
            this.dataGridView1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 476);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExit);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Riverlink";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransponderNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransaction)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tbTolls.ResumeLayout(false);
            this.tbTolls.PerformLayout();
            this.tbVehicles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.BindingSource bsYear;
        private System.Windows.Forms.BindingSource bsMonth;
        private System.Windows.Forms.BindingSource bsTransponderNumber;
        private System.Windows.Forms.BindingSource bsTransaction;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbTolls;
        private System.Windows.Forms.TabPage tbVehicles;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postedDateDataGridViewTextBoxColumn;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTransponder;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

