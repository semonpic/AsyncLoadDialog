namespace AsyncLoadDialog
{
    partial class AsyncLoadForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.processBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.labPrecent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(441, 101);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // processBar
            // 
            this.processBar.Location = new System.Drawing.Point(12, 45);
            this.processBar.Name = "processBar";
            this.processBar.Size = new System.Drawing.Size(446, 30);
            this.processBar.Step = 1;
            this.processBar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loading Data,Please Wait";
            // 
            // labPrecent
            // 
            this.labPrecent.AutoSize = true;
            this.labPrecent.Location = new System.Drawing.Point(464, 56);
            this.labPrecent.Name = "labPrecent";
            this.labPrecent.Size = new System.Drawing.Size(17, 12);
            this.labPrecent.TabIndex = 3;
            this.labPrecent.Text = "0%";
            // 
            // AsyncLoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(535, 136);
            this.Controls.Add(this.labPrecent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.processBar);
            this.Controls.Add(this.btnCancel);
            this.HelpButton = true;
            this.Name = "AsyncLoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AsynLoadForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AsyncLoadForm_FormClosed);
            this.Load += new System.EventHandler(this.AsynLoadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar processBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labPrecent;
    }
}