namespace BasicKeyLogger
{
    partial class Form1
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
            this.numericUpDownThreshold = new System.Windows.Forms.NumericUpDown();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.checkBoxConsent = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownThreshold
            // 
            this.numericUpDownThreshold.Location = new System.Drawing.Point(12, 13);
            this.numericUpDownThreshold.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownThreshold.Name = "numericUpDownThreshold";
            this.numericUpDownThreshold.Size = new System.Drawing.Size(138, 20);
            this.numericUpDownThreshold.TabIndex = 0;
            this.numericUpDownThreshold.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 39);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(138, 70);
            this.txtInput.TabIndex = 1;
            // 
            // checkBoxConsent
            // 
            this.checkBoxConsent.AutoSize = true;
            this.checkBoxConsent.Location = new System.Drawing.Point(174, 16);
            this.checkBoxConsent.Name = "checkBoxConsent";
            this.checkBoxConsent.Size = new System.Drawing.Size(80, 17);
            this.checkBoxConsent.TabIndex = 2;
            this.checkBoxConsent.Text = "checkBox1";
            this.checkBoxConsent.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(171, 42);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.checkBoxConsent);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.numericUpDownThreshold);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownThreshold;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.CheckBox checkBoxConsent;
        private System.Windows.Forms.Label lblStatus;
    }
}

