namespace TimePunch
{
    partial class HoursLabel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateLabel = new System.Windows.Forms.Label();
            this.hoursLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(3, 13);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(63, 19);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "label1";
            // 
            // hoursLinkLabel
            // 
            this.hoursLinkLabel.AutoSize = true;
            this.hoursLinkLabel.Font = new System.Drawing.Font("Consolas", 12F);
            this.hoursLinkLabel.Location = new System.Drawing.Point(111, 13);
            this.hoursLinkLabel.Name = "hoursLinkLabel";
            this.hoursLinkLabel.Size = new System.Drawing.Size(99, 19);
            this.hoursLinkLabel.TabIndex = 1;
            this.hoursLinkLabel.TabStop = true;
            this.hoursLinkLabel.Text = "linkLabel1";
            this.hoursLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.hoursLinkLabel_LinkClicked);
            // 
            // HoursLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.hoursLinkLabel);
            this.Controls.Add(this.dateLabel);
            this.Name = "HoursLabel";
            this.Size = new System.Drawing.Size(225, 48);
            this.Load += new System.EventHandler(this.HoursLabel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.LinkLabel hoursLinkLabel;
    }
}
