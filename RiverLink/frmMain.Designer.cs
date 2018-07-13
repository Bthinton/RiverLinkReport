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
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgTransactions = new System.Windows.Forms.DataGridView();
            this.transactionNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTransponder = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbVehicles = new System.Windows.Forms.TabPage();
            this.tbPayments = new System.Windows.Forms.TabPage();
            this.dgPayments = new System.Windows.Forms.DataGridView();
            this.dgVehicles = new System.Windows.Forms.DataGridView();
            this.bsVehicle = new System.Windows.Forms.BindingSource(this.components);
            this.bsPayment = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransponderNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransaction)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tbTolls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransactions)).BeginInit();
            this.tbVehicles.SuspendLayout();
            this.tbPayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVehicles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPayment)).BeginInit();
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
            this.tabControl1.Controls.Add(this.tbPayments);
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
            this.transactionNumberDataGridViewTextBoxColumn,
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
            this.vehicleClassIdDataGridViewTextBoxColumn});
            this.dgTransactions.DataSource = this.bsTransaction;
            this.dgTransactions.Location = new System.Drawing.Point(22, 60);
            this.dgTransactions.Name = "dgTransactions";
            this.dgTransactions.ReadOnly = true;
            this.dgTransactions.Size = new System.Drawing.Size(811, 322);
            this.dgTransactions.TabIndex = 6;
            this.dgTransactions.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgTransactions_ColumnHeaderMouseClick);
            // 
            // transactionNumberDataGridViewTextBoxColumn
            // 
            this.transactionNumberDataGridViewTextBoxColumn.DataPropertyName = "TransactionNumber";
            this.transactionNumberDataGridViewTextBoxColumn.HeaderText = "TransactionNumber";
            this.transactionNumberDataGridViewTextBoxColumn.Name = "transactionNumberDataGridViewTextBoxColumn";
            this.transactionNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionDateDataGridViewTextBoxColumn
            // 
            this.transactionDateDataGridViewTextBoxColumn.DataPropertyName = "TransactionDate";
            this.transactionDateDataGridViewTextBoxColumn.HeaderText = "TransactionDate";
            this.transactionDateDataGridViewTextBoxColumn.Name = "transactionDateDataGridViewTextBoxColumn";
            this.transactionDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // postedDateDataGridViewTextBoxColumn
            // 
            this.postedDateDataGridViewTextBoxColumn.DataPropertyName = "PostedDate";
            this.postedDateDataGridViewTextBoxColumn.HeaderText = "PostedDate";
            this.postedDateDataGridViewTextBoxColumn.Name = "postedDateDataGridViewTextBoxColumn";
            this.postedDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionStatusDataGridViewTextBoxColumn
            // 
            this.transactionStatusDataGridViewTextBoxColumn.DataPropertyName = "TransactionStatus";
            this.transactionStatusDataGridViewTextBoxColumn.HeaderText = "TransactionStatus";
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
            this.journalIdDataGridViewTextBoxColumn.HeaderText = "Journal_Id";
            this.journalIdDataGridViewTextBoxColumn.Name = "journalIdDataGridViewTextBoxColumn";
            this.journalIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transponderNumberDataGridViewTextBoxColumn
            // 
            this.transponderNumberDataGridViewTextBoxColumn.DataPropertyName = "TransponderNumber";
            this.transponderNumberDataGridViewTextBoxColumn.HeaderText = "TransponderNumber";
            this.transponderNumberDataGridViewTextBoxColumn.Name = "transponderNumberDataGridViewTextBoxColumn";
            this.transponderNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transactionTypeDataGridViewTextBoxColumn
            // 
            this.transactionTypeDataGridViewTextBoxColumn.DataPropertyName = "TransactionType";
            this.transactionTypeDataGridViewTextBoxColumn.HeaderText = "TransactionType";
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
            this.transactionDescriptionDataGridViewTextBoxColumn.HeaderText = "TransactionDescription";
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
            this.plateNumberDataGridViewTextBoxColumn.HeaderText = "PlateNumber";
            this.plateNumberDataGridViewTextBoxColumn.Name = "plateNumberDataGridViewTextBoxColumn";
            this.plateNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vehicleClassIdDataGridViewTextBoxColumn
            // 
            this.vehicleClassIdDataGridViewTextBoxColumn.DataPropertyName = "VehicleClass_Id";
            this.vehicleClassIdDataGridViewTextBoxColumn.HeaderText = "VehicleClass_Id";
            this.vehicleClassIdDataGridViewTextBoxColumn.Name = "vehicleClassIdDataGridViewTextBoxColumn";
            this.vehicleClassIdDataGridViewTextBoxColumn.ReadOnly = true;
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
            // tbVehicles
            // 
            this.tbVehicles.Controls.Add(this.dgVehicles);
            this.tbVehicles.Location = new System.Drawing.Point(4, 22);
            this.tbVehicles.Name = "tbVehicles";
            this.tbVehicles.Padding = new System.Windows.Forms.Padding(3);
            this.tbVehicles.Size = new System.Drawing.Size(856, 385);
            this.tbVehicles.TabIndex = 1;
            this.tbVehicles.Text = "Vehicles";
            this.tbVehicles.UseVisualStyleBackColor = true;
            // 
            // tbPayments
            // 
            this.tbPayments.Controls.Add(this.dgPayments);
            this.tbPayments.Location = new System.Drawing.Point(4, 22);
            this.tbPayments.Name = "tbPayments";
            this.tbPayments.Size = new System.Drawing.Size(856, 385);
            this.tbPayments.TabIndex = 2;
            this.tbPayments.Text = "Payments";
            this.tbPayments.UseVisualStyleBackColor = true;
            // 
            // dgPayments
            // 
            this.dgPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPayments.Location = new System.Drawing.Point(19, 29);
            this.dgPayments.Name = "dgPayments";
            this.dgPayments.Size = new System.Drawing.Size(819, 327);
            this.dgPayments.TabIndex = 1;
            // 
            // dgVehicles
            // 
            this.dgVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVehicles.Location = new System.Drawing.Point(19, 29);
            this.dgVehicles.Name = "dgVehicles";
            this.dgVehicles.Size = new System.Drawing.Size(819, 327);
            this.dgVehicles.TabIndex = 1;
            // 
            // bsVehicle
            // 
            this.bsVehicle.DataSource = typeof(RiverLink.Models.Vehicle);
            // 
            // bsPayment
            // 
            this.bsPayment.DataSource = typeof(RiverLink.Models.Transaction);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgTransactions)).EndInit();
            this.tbVehicles.ResumeLayout(false);
            this.tbPayments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgVehicles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPayment)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTransponder;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionNumberDataGridViewTextBoxColumn;
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
        private System.Windows.Forms.TabPage tbPayments;
        private System.Windows.Forms.DataGridView dgVehicles;
        private System.Windows.Forms.DataGridView dgPayments;
        private System.Windows.Forms.BindingSource bsVehicle;
        private System.Windows.Forms.BindingSource bsPayment;
    }
}

