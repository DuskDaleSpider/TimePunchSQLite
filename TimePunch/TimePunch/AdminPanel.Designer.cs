namespace TimePunch
{
    partial class AdminPanel
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
            this.settingsButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.usersButton = new System.Windows.Forms.Button();
            this.usersHoursButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // settingsButton
            // 
            this.settingsButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.settingsButton.Location = new System.Drawing.Point(3, 3);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(649, 79);
            this.settingsButton.TabIndex = 6;
            this.settingsButton.Text = "App Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.backButton.Location = new System.Drawing.Point(3, 325);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(649, 79);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // usersButton
            // 
            this.usersButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.usersButton.Location = new System.Drawing.Point(3, 111);
            this.usersButton.Name = "usersButton";
            this.usersButton.Size = new System.Drawing.Size(649, 79);
            this.usersButton.TabIndex = 8;
            this.usersButton.Text = "Users";
            this.usersButton.UseVisualStyleBackColor = true;
            this.usersButton.Click += new System.EventHandler(this.usersButton_Click);
            // 
            // usersHoursButton
            // 
            this.usersHoursButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.usersHoursButton.Location = new System.Drawing.Point(3, 216);
            this.usersHoursButton.Name = "usersHoursButton";
            this.usersHoursButton.Size = new System.Drawing.Size(649, 79);
            this.usersHoursButton.TabIndex = 9;
            this.usersHoursButton.Text = "Users Hours";
            this.usersHoursButton.UseVisualStyleBackColor = true;
            this.usersHoursButton.Click += new System.EventHandler(this.usersHoursButton_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.usersHoursButton);
            this.Controls.Add(this.usersButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.settingsButton);
            this.Name = "AdminPanel";
            this.Size = new System.Drawing.Size(655, 407);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button usersButton;
        private System.Windows.Forms.Button usersHoursButton;
    }
}
