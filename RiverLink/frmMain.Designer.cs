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
            this.dgVehicles = new System.Windows.Forms.DataGridView();
            this.vehicleIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plateNumberDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.makeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classificationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsVehicle = new System.Windows.Forms.BindingSource(this.components);
            this.tbPayments = new System.Windows.Forms.TabPage();
            this.dgPayments = new System.Windows.Forms.DataGridView();
            this.journalIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postedDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionStatusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionTypeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionDescriptionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPayment = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTransponder = new System.Windows.Forms.Label();
            this.lblTotalCrossings = new System.Windows.Forms.Label();
            this.lblCalcCost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransponderNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransaction)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tbTolls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransactions)).BeginInit();
            this.tbVehicles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVehicles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVehicle)).BeginInit();
            this.tbPayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPayment)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(815, 556);
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
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbTolls);
            this.tabControl1.Controls.Add(this.tbVehicles);
            this.tabControl1.Controls.Add(this.tbPayments);
            this.tabControl1.Location = new System.Drawing.Point(26, 142);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(864, 396);
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
            this.tbTolls.Size = new System.Drawing.Size(856, 370);
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
            this.dgTransactions.AllowUserToOrderColumns = true;
            this.dgTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTransactions.AutoGenerateColumns = false;
            this.dgTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dgTransactions.Size = new System.Drawing.Size(811, 307);
            this.dgTransactions.TabIndex = 6;
            this.dgTransactions.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgTransactions_ColumnHeaderMouseClick);
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
            // postedDateDataGridViewTextBoxColumn
            // 
            this.postedDateDataGridViewTextBoxColumn.DataPropertyName = "PostedDate";
            this.postedDateDataGridViewTextBoxColumn.HeaderText = "Posted Date";
            this.postedDateDataGridViewTextBoxColumn.Name = "postedDateDataGridViewTextBoxColumn";
            this.postedDateDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.vehicleClassIdDataGridViewTextBoxColumn.HeaderText = "Vehicle Class Id";
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
            this.cmbTransponder.SelectedIndexChanged += new System.EventHandler(this.cmbTransponder_SelectedIndexChanged);
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
            this.tbVehicles.Size = new System.Drawing.Size(856, 370);
            this.tbVehicles.TabIndex = 1;
            this.tbVehicles.Text = "Vehicles";
            this.tbVehicles.UseVisualStyleBackColor = true;
            // 
            // dgVehicles
            // 
            this.dgVehicles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgVehicles.AutoGenerateColumns = false;
            this.dgVehicles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVehicles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vehicleIdDataGridViewTextBoxColumn,
            this.plateNumberDataGridViewTextBoxColumn2,
            this.makeDataGridViewTextBoxColumn,
            this.modelDataGridViewTextBoxColumn,
            this.yearDataGridViewTextBoxColumn,
            this.vehicleStateDataGridViewTextBoxColumn,
            this.vehicleStatusDataGridViewTextBoxColumn,
            this.classificationDataGridViewTextBoxColumn});
            this.dgVehicles.DataSource = this.bsVehicle;
            this.dgVehicles.Location = new System.Drawing.Point(19, 29);
            this.dgVehicles.Name = "dgVehicles";
            this.dgVehicles.Size = new System.Drawing.Size(819, 327);
            this.dgVehicles.TabIndex = 1;
            this.dgVehicles.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgVehicles_ColumnHeaderMouseClick);
            // 
            // vehicleIdDataGridViewTextBoxColumn
            // 
            this.vehicleIdDataGridViewTextBoxColumn.DataPropertyName = "Vehicle_Id";
            this.vehicleIdDataGridViewTextBoxColumn.HeaderText = "Vehicle Id";
            this.vehicleIdDataGridViewTextBoxColumn.Name = "vehicleIdDataGridViewTextBoxColumn";
            // 
            // plateNumberDataGridViewTextBoxColumn2
            // 
            this.plateNumberDataGridViewTextBoxColumn2.DataPropertyName = "PlateNumber";
            this.plateNumberDataGridViewTextBoxColumn2.HeaderText = "Plate Number";
            this.plateNumberDataGridViewTextBoxColumn2.Name = "plateNumberDataGridViewTextBoxColumn2";
            // 
            // makeDataGridViewTextBoxColumn
            // 
            this.makeDataGridViewTextBoxColumn.DataPropertyName = "Make";
            this.makeDataGridViewTextBoxColumn.HeaderText = "Make";
            this.makeDataGridViewTextBoxColumn.Name = "makeDataGridViewTextBoxColumn";
            // 
            // modelDataGridViewTextBoxColumn
            // 
            this.modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
            this.modelDataGridViewTextBoxColumn.HeaderText = "Model";
            this.modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Year";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            // 
            // vehicleStateDataGridViewTextBoxColumn
            // 
            this.vehicleStateDataGridViewTextBoxColumn.DataPropertyName = "VehicleState";
            this.vehicleStateDataGridViewTextBoxColumn.HeaderText = "Vehicle State";
            this.vehicleStateDataGridViewTextBoxColumn.Name = "vehicleStateDataGridViewTextBoxColumn";
            // 
            // vehicleStatusDataGridViewTextBoxColumn
            // 
            this.vehicleStatusDataGridViewTextBoxColumn.DataPropertyName = "VehicleStatus";
            this.vehicleStatusDataGridViewTextBoxColumn.HeaderText = "Vehicle Status";
            this.vehicleStatusDataGridViewTextBoxColumn.Name = "vehicleStatusDataGridViewTextBoxColumn";
            // 
            // classificationDataGridViewTextBoxColumn
            // 
            this.classificationDataGridViewTextBoxColumn.DataPropertyName = "Classification";
            this.classificationDataGridViewTextBoxColumn.HeaderText = "Classification";
            this.classificationDataGridViewTextBoxColumn.Name = "classificationDataGridViewTextBoxColumn";
            // 
            // bsVehicle
            // 
            this.bsVehicle.DataSource = typeof(RiverLink.Models.Vehicle);
            // 
            // tbPayments
            // 
            this.tbPayments.Controls.Add(this.dgPayments);
            this.tbPayments.Location = new System.Drawing.Point(4, 22);
            this.tbPayments.Name = "tbPayments";
            this.tbPayments.Size = new System.Drawing.Size(856, 370);
            this.tbPayments.TabIndex = 2;
            this.tbPayments.Text = "Payments";
            this.tbPayments.UseVisualStyleBackColor = true;
            // 
            // dgPayments
            // 
            this.dgPayments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPayments.AutoGenerateColumns = false;
            this.dgPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.journalIdDataGridViewTextBoxColumn1,
            this.transactionDateDataGridViewTextBoxColumn1,
            this.postedDateDataGridViewTextBoxColumn1,
            this.transactionStatusDataGridViewTextBoxColumn1,
            this.transactionTypeDataGridViewTextBoxColumn1,
            this.amountDataGridViewTextBoxColumn1,
            this.transactionDescriptionDataGridViewTextBoxColumn1});
            this.dgPayments.DataSource = this.bsPayment;
            this.dgPayments.Location = new System.Drawing.Point(19, 29);
            this.dgPayments.Name = "dgPayments";
            this.dgPayments.Size = new System.Drawing.Size(819, 327);
            this.dgPayments.TabIndex = 1;
            this.dgPayments.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPayments_ColumnHeaderMouseClick);
            // 
            // journalIdDataGridViewTextBoxColumn1
            // 
            this.journalIdDataGridViewTextBoxColumn1.DataPropertyName = "Journal_Id";
            this.journalIdDataGridViewTextBoxColumn1.HeaderText = "Journal Id";
            this.journalIdDataGridViewTextBoxColumn1.Name = "journalIdDataGridViewTextBoxColumn1";
            // 
            // transactionDateDataGridViewTextBoxColumn1
            // 
            this.transactionDateDataGridViewTextBoxColumn1.DataPropertyName = "TransactionDate";
            this.transactionDateDataGridViewTextBoxColumn1.HeaderText = "Transaction Date";
            this.transactionDateDataGridViewTextBoxColumn1.Name = "transactionDateDataGridViewTextBoxColumn1";
            // 
            // postedDateDataGridViewTextBoxColumn1
            // 
            this.postedDateDataGridViewTextBoxColumn1.DataPropertyName = "PostedDate";
            this.postedDateDataGridViewTextBoxColumn1.HeaderText = "Posted Date";
            this.postedDateDataGridViewTextBoxColumn1.Name = "postedDateDataGridViewTextBoxColumn1";
            // 
            // transactionStatusDataGridViewTextBoxColumn1
            // 
            this.transactionStatusDataGridViewTextBoxColumn1.DataPropertyName = "TransactionStatus";
            this.transactionStatusDataGridViewTextBoxColumn1.HeaderText = "Transaction Status";
            this.transactionStatusDataGridViewTextBoxColumn1.Name = "transactionStatusDataGridViewTextBoxColumn1";
            // 
            // transactionTypeDataGridViewTextBoxColumn1
            // 
            this.transactionTypeDataGridViewTextBoxColumn1.DataPropertyName = "TransactionType";
            this.transactionTypeDataGridViewTextBoxColumn1.HeaderText = "Transaction Type";
            this.transactionTypeDataGridViewTextBoxColumn1.Name = "transactionTypeDataGridViewTextBoxColumn1";
            // 
            // amountDataGridViewTextBoxColumn1
            // 
            this.amountDataGridViewTextBoxColumn1.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn1.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn1.Name = "amountDataGridViewTextBoxColumn1";
            // 
            // transactionDescriptionDataGridViewTextBoxColumn1
            // 
            this.transactionDescriptionDataGridViewTextBoxColumn1.DataPropertyName = "TransactionDescription";
            this.transactionDescriptionDataGridViewTextBoxColumn1.HeaderText = "Transaction Description";
            this.transactionDescriptionDataGridViewTextBoxColumn1.Name = "transactionDescriptionDataGridViewTextBoxColumn1";
            // 
            // bsPayment
            // 
            this.bsPayment.DataSource = typeof(RiverLink.Models.Transaction);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCalcCost);
            this.groupBox1.Controls.Add(this.lblTotalCrossings);
            this.groupBox1.Controls.Add(this.lblTransponder);
            this.groupBox1.Location = new System.Drawing.Point(30, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(856, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summary";
            // 
            // lblTransponder
            // 
            this.lblTransponder.AutoSize = true;
            this.lblTransponder.BackColor = System.Drawing.SystemColors.Control;
            this.lblTransponder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransponder.ForeColor = System.Drawing.Color.Black;
            this.lblTransponder.Location = new System.Drawing.Point(19, 41);
            this.lblTransponder.Name = "lblTransponder";
            this.lblTransponder.Size = new System.Drawing.Size(203, 24);
            this.lblTransponder.TabIndex = 4;
            this.lblTransponder.Text = "Transponder Number: ";
            // 
            // lblTotalCrossings
            // 
            this.lblTotalCrossings.AutoSize = true;
            this.lblTotalCrossings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCrossings.ForeColor = System.Drawing.Color.Black;
            this.lblTotalCrossings.Location = new System.Drawing.Point(342, 41);
            this.lblTotalCrossings.Name = "lblTotalCrossings";
            this.lblTotalCrossings.Size = new System.Drawing.Size(149, 24);
            this.lblTotalCrossings.TabIndex = 5;
            this.lblTotalCrossings.Text = "Total Crossings: ";
            // 
            // lblCalcCost
            // 
            this.lblCalcCost.AutoSize = true;
            this.lblCalcCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalcCost.ForeColor = System.Drawing.Color.Black;
            this.lblCalcCost.Location = new System.Drawing.Point(623, 41);
            this.lblCalcCost.Name = "lblCalcCost";
            this.lblCalcCost.Size = new System.Drawing.Size(180, 24);
            this.lblCalcCost.TabIndex = 6;
            this.lblCalcCost.Text = "Calculated Cost: $76";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 591);
            this.Controls.Add(this.groupBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgVehicles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVehicle)).EndInit();
            this.tbPayments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPayment)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TabPage tbPayments;
        private System.Windows.Forms.DataGridView dgVehicles;
        private System.Windows.Forms.DataGridView dgPayments;
        private System.Windows.Forms.BindingSource bsVehicle;
        private System.Windows.Forms.BindingSource bsPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plateNumberDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn makeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classificationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn journalIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn postedDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionStatusDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionTypeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionDescriptionDataGridViewTextBoxColumn1;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTransponder;
        private System.Windows.Forms.Label lblCalcCost;
        private System.Windows.Forms.Label lblTotalCrossings;
    }
}

