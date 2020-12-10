namespace TimePunch
{
    partial class UserHoursLabel
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.hoursLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(14, 13);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(63, 19);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "label1";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(281, 13);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(63, 19);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "label2";
            // 
            // hoursLinkLabel
            // 
            this.hoursLinkLabel.AutoSize = true;
            this.hoursLinkLabel.Location = new System.Drawing.Point(507, 13);
            this.hoursLinkLabel.Name = "hoursLinkLabel";
            this.hoursLinkLabel.Size = new System.Drawing.Size(99, 19);
            this.hoursLinkLabel.TabIndex = 2;
            this.hoursLinkLabel.TabStop = true;
            this.hoursLinkLabel.Text = "linkLabel1";
            this.hoursLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.hoursLinkLabel_LinkClicked);
            // 
            // UserHoursLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hoursLinkLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.nameLabel);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserHoursLabel";
            this.Size = new System.Drawing.Size(635, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.LinkLabel hoursLinkLabel;
    }
}
