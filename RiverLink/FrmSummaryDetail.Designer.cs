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
            // FrmSummaryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}