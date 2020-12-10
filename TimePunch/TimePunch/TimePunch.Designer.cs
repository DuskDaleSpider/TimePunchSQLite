namespace TimePunch
{
    partial class TimePunch
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
            this.punchInButton = new System.Windows.Forms.Button();
            this.lunchStartButton = new System.Windows.Forms.Button();
            this.lunchEndButton = new System.Windows.Forms.Button();
            this.punchOutButton = new System.Windows.Forms.Button();
            this.punchBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.viewHoursButton = new System.Windows.Forms.Button();
            this.adminButton = new System.Windows.Forms.Button();
            this.punchBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // punchInButton
            // 
            this.punchInButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.punchInButton.Location = new System.Drawing.Point(21, 32);
            this.punchInButton.Name = "punchInButton";
            this.punchInButton.Size = new System.Drawing.Size(147, 138);
            this.punchInButton.TabIndex = 0;
            this.punchInButton.Text = "Punch In";
            this.punchInButton.UseVisualStyleBackColor = true;
            this.punchInButton.Click += new System.EventHandler(this.punchInButton_Click);
            // 
            // lunchStartButton
            // 
            this.lunchStartButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lunchStartButton.Location = new System.Drawing.Point(174, 32);
            this.lunchStartButton.Name = "lunchStartButton";
            this.lunchStartButton.Size = new System.Drawing.Size(147, 138);
            this.lunchStartButton.TabIndex = 1;
            this.lunchStartButton.Text = "Start Lunch";
            this.lunchStartButton.UseVisualStyleBackColor = true;
            this.lunchStartButton.Click += new System.EventHandler(this.lunchStartButton_Click);
            // 
            // lunchEndButton
            // 
            this.lunchEndButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.lunchEndButton.Location = new System.Drawing.Point(327, 32);
            this.lunchEndButton.Name = "lunchEndButton";
            this.lunchEndButton.Size = new System.Drawing.Size(147, 138);
            this.lunchEndButton.TabIndex = 2;
            this.lunchEndButton.Text = "End Lunch";
            this.lunchEndButton.UseVisualStyleBackColor = true;
            this.lunchEndButton.Click += new System.EventHandler(this.lunchEndButton_Click);
            // 
            // punchOutButton
            // 
            this.punchOutButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.punchOutButton.Location = new System.Drawing.Point(480, 32);
            this.punchOutButton.Name = "punchOutButton";
            this.punchOutButton.Size = new System.Drawing.Size(147, 138);
            this.punchOutButton.TabIndex = 3;
            this.punchOutButton.Text = "Punch Out";
            this.punchOutButton.UseVisualStyleBackColor = true;
            this.punchOutButton.Click += new System.EventHandler(this.punchOutButton_Click);
            // 
            // punchBox
            // 
            this.punchBox.Controls.Add(this.lunchEndButton);
            this.punchBox.Controls.Add(this.punchOutButton);
            this.punchBox.Controls.Add(this.punchInButton);
            this.punchBox.Controls.Add(this.lunchStartButton);
            this.punchBox.Location = new System.Drawing.Point(3, 3);
            this.punchBox.Name = "punchBox";
            this.punchBox.Size = new System.Drawing.Size(649, 195);
            this.punchBox.TabIndex = 4;
            this.punchBox.TabStop = false;
            this.punchBox.Text = "Punch Options";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Consolas", 12F);
            this.button1.Location = new System.Drawing.Point(3, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(649, 45);
            this.button1.TabIndex = 5;
            this.button1.Text = "View Today\'s Punches";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.logoutButton.Location = new System.Drawing.Point(3, 357);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(649, 47);
            this.logoutButton.TabIndex = 6;
            this.logoutButton.Text = "Log Out";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // viewHoursButton
            // 
            this.viewHoursButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.viewHoursButton.Location = new System.Drawing.Point(3, 255);
            this.viewHoursButton.Name = "viewHoursButton";
            this.viewHoursButton.Size = new System.Drawing.Size(649, 45);
            this.viewHoursButton.TabIndex = 7;
            this.viewHoursButton.Text = "View Hours";
            this.viewHoursButton.UseVisualStyleBackColor = true;
            this.viewHoursButton.Click += new System.EventHandler(this.viewHoursButton_Click);
            // 
            // adminButton
            // 
            this.adminButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.adminButton.Location = new System.Drawing.Point(3, 306);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(649, 45);
            this.adminButton.TabIndex = 8;
            this.adminButton.Text = "Admin Panel";
            this.adminButton.UseVisualStyleBackColor = true;
            this.adminButton.Click += new System.EventHandler(this.adminButton_Click);
            // 
            // TimePunch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.adminButton);
            this.Controls.Add(this.viewHoursButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.punchBox);
            this.Name = "TimePunch";
            this.Size = new System.Drawing.Size(655, 407);
            this.Load += new System.EventHandler(this.TimePunch_Load);
            this.punchBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button punchInButton;
        private System.Windows.Forms.Button lunchStartButton;
        private System.Windows.Forms.Button lunchEndButton;
        private System.Windows.Forms.Button punchOutButton;
        private System.Windows.Forms.GroupBox punchBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button viewHoursButton;
        private System.Windows.Forms.Button adminButton;
    }
}
