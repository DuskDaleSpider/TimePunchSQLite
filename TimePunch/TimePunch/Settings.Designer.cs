namespace TimePunch
{
    partial class Settings
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
            this.minLunchLabel = new System.Windows.Forms.Label();
            this.minLunchInput = new System.Windows.Forms.NumericUpDown();
            this.payPeriodStartLabel = new System.Windows.Forms.Label();
            this.payPeriodStartCalander = new System.Windows.Forms.MonthCalendar();
            this.payPeriodLengthLabel = new System.Windows.Forms.Label();
            this.payPeriodLengthInput = new System.Windows.Forms.NumericUpDown();
            this.applyButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.minLunchInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payPeriodLengthInput)).BeginInit();
            this.SuspendLayout();
            // 
            // minLunchLabel
            // 
            this.minLunchLabel.AutoSize = true;
            this.minLunchLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minLunchLabel.Location = new System.Drawing.Point(88, 12);
            this.minLunchLabel.Name = "minLunchLabel";
            this.minLunchLabel.Size = new System.Drawing.Size(234, 19);
            this.minLunchLabel.TabIndex = 0;
            this.minLunchLabel.Text = "Minimum Lunch in Minutes:";
            // 
            // minLunchInput
            // 
            this.minLunchInput.Location = new System.Drawing.Point(394, 12);
            this.minLunchInput.Name = "minLunchInput";
            this.minLunchInput.Size = new System.Drawing.Size(41, 20);
            this.minLunchInput.TabIndex = 1;
            // 
            // payPeriodStartLabel
            // 
            this.payPeriodStartLabel.AutoSize = true;
            this.payPeriodStartLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payPeriodStartLabel.Location = new System.Drawing.Point(88, 65);
            this.payPeriodStartLabel.Name = "payPeriodStartLabel";
            this.payPeriodStartLabel.Size = new System.Drawing.Size(207, 19);
            this.payPeriodStartLabel.TabIndex = 2;
            this.payPeriodStartLabel.Text = "Pay Period Start Date:";
            // 
            // payPeriodStartCalander
            // 
            this.payPeriodStartCalander.Location = new System.Drawing.Point(307, 65);
            this.payPeriodStartCalander.MaxSelectionCount = 1;
            this.payPeriodStartCalander.Name = "payPeriodStartCalander";
            this.payPeriodStartCalander.ShowToday = false;
            this.payPeriodStartCalander.TabIndex = 3;
            // 
            // payPeriodLengthLabel
            // 
            this.payPeriodLengthLabel.AutoSize = true;
            this.payPeriodLengthLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payPeriodLengthLabel.Location = new System.Drawing.Point(88, 259);
            this.payPeriodLengthLabel.Name = "payPeriodLengthLabel";
            this.payPeriodLengthLabel.Size = new System.Drawing.Size(243, 19);
            this.payPeriodLengthLabel.TabIndex = 4;
            this.payPeriodLengthLabel.Text = "Pay Period Length in Days:";
            // 
            // payPeriodLengthInput
            // 
            this.payPeriodLengthInput.Location = new System.Drawing.Point(394, 261);
            this.payPeriodLengthInput.Name = "payPeriodLengthInput";
            this.payPeriodLengthInput.Size = new System.Drawing.Size(41, 20);
            this.payPeriodLengthInput.TabIndex = 5;
            // 
            // applyButton
            // 
            this.applyButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyButton.Location = new System.Drawing.Point(3, 297);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(649, 51);
            this.applyButton.TabIndex = 6;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(3, 354);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(649, 50);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.payPeriodLengthInput);
            this.Controls.Add(this.payPeriodLengthLabel);
            this.Controls.Add(this.payPeriodStartCalander);
            this.Controls.Add(this.payPeriodStartLabel);
            this.Controls.Add(this.minLunchInput);
            this.Controls.Add(this.minLunchLabel);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(655, 407);
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.minLunchInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payPeriodLengthInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label minLunchLabel;
        private System.Windows.Forms.NumericUpDown minLunchInput;
        private System.Windows.Forms.Label payPeriodStartLabel;
        private System.Windows.Forms.MonthCalendar payPeriodStartCalander;
        private System.Windows.Forms.Label payPeriodLengthLabel;
        private System.Windows.Forms.NumericUpDown payPeriodLengthInput;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button backButton;
    }
}
