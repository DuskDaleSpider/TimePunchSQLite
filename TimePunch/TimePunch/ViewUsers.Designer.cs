namespace TimePunch
{
    partial class ViewUsers
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
            this.usersGroupBox = new System.Windows.Forms.GroupBox();
            this.usersFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.addUserButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.usersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // usersGroupBox
            // 
            this.usersGroupBox.Controls.Add(this.usersFlowLayout);
            this.usersGroupBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersGroupBox.Location = new System.Drawing.Point(2, 2);
            this.usersGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.usersGroupBox.Name = "usersGroupBox";
            this.usersGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.usersGroupBox.Size = new System.Drawing.Size(651, 316);
            this.usersGroupBox.TabIndex = 0;
            this.usersGroupBox.TabStop = false;
            this.usersGroupBox.Text = "Users";
            // 
            // usersFlowLayout
            // 
            this.usersFlowLayout.AutoScroll = true;
            this.usersFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersFlowLayout.Location = new System.Drawing.Point(2, 21);
            this.usersFlowLayout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.usersFlowLayout.Name = "usersFlowLayout";
            this.usersFlowLayout.Size = new System.Drawing.Size(647, 293);
            this.usersFlowLayout.TabIndex = 0;
            // 
            // addUserButton
            // 
            this.addUserButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.addUserButton.Location = new System.Drawing.Point(4, 322);
            this.addUserButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(650, 37);
            this.addUserButton.TabIndex = 1;
            this.addUserButton.Text = "Add User";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Consolas", 12F);
            this.backButton.Location = new System.Drawing.Point(3, 363);
            this.backButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(650, 37);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // ViewUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.addUserButton);
            this.Controls.Add(this.usersGroupBox);
            this.Name = "ViewUsers";
            this.Size = new System.Drawing.Size(656, 407);
            this.Load += new System.EventHandler(this.ViewUsers_Load);
            this.usersGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox usersGroupBox;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.FlowLayoutPanel usersFlowLayout;
    }
}
