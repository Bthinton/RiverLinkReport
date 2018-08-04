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
            this.lblSummaryText = new System.Windows.Forms.Label();
            this.btnSummaryClose = new System.Windows.Forms.Button();
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
            // FrmSummaryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSummaryClose);
            this.Controls.Add(this.lblSummaryText);
            this.Name = "FrmSummaryDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Summary Detail";
            this.Load += new System.EventHandler(this.FrmSummaryDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSummaryText;
        private System.Windows.Forms.Button btnSummaryClose;
    }
}