namespace TimePunch
{
    partial class ViewHours
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hoursFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.backButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hoursFlowLayoutPanel);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(150, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 285);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hours";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // hoursFlowLayoutPanel
            // 
            this.hoursFlowLayoutPanel.AutoScroll = true;
            this.hoursFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hoursFlowLayoutPanel.Location = new System.Drawing.Point(3, 22);
            this.hoursFlowLayoutPanel.Name = "hoursFlowLayoutPanel";
            this.hoursFlowLayoutPanel.Size = new System.Drawing.Size(339, 260);
            this.hoursFlowLayoutPanel.TabIndex = 0;
            // 
            // backButton
            // 
            this.backButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.backButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.backButton.Location = new System.Drawing.Point(0, 346);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(655, 61);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // ViewHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewHours";
            this.Size = new System.Drawing.Size(655, 407);
            this.Load += new System.EventHandler(this.ViewHours_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.FlowLayoutPanel hoursFlowLayoutPanel;
    }
}
