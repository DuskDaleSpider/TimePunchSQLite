namespace TimePunch
{
    partial class ViewUsersHours
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
            this.userHoursGroupBox = new System.Windows.Forms.GroupBox();
            this.userHoursFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.backButton = new System.Windows.Forms.Button();
            this.userHoursGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // userHoursGroupBox
            // 
            this.userHoursGroupBox.Controls.Add(this.userHoursFlowLayout);
            this.userHoursGroupBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userHoursGroupBox.Location = new System.Drawing.Point(3, 3);
            this.userHoursGroupBox.Name = "userHoursGroupBox";
            this.userHoursGroupBox.Size = new System.Drawing.Size(649, 347);
            this.userHoursGroupBox.TabIndex = 0;
            this.userHoursGroupBox.TabStop = false;
            this.userHoursGroupBox.Text = "User Hours";
            // 
            // userHoursFlowLayout
            // 
            this.userHoursFlowLayout.AutoScroll = true;
            this.userHoursFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userHoursFlowLayout.Location = new System.Drawing.Point(3, 22);
            this.userHoursFlowLayout.Name = "userHoursFlowLayout";
            this.userHoursFlowLayout.Size = new System.Drawing.Size(643, 322);
            this.userHoursFlowLayout.TabIndex = 0;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(6, 360);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(646, 44);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // ViewUsersHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.userHoursGroupBox);
            this.Name = "ViewUsersHours";
            this.Size = new System.Drawing.Size(655, 407);
            this.Load += new System.EventHandler(this.ViewUsersHours_Load);
            this.userHoursGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox userHoursGroupBox;
        private System.Windows.Forms.FlowLayoutPanel userHoursFlowLayout;
        private System.Windows.Forms.Button backButton;
    }
}
