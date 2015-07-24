namespace Bank_Manager
{
    partial class NewCredit
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
            this.groupBox_CreditDetails = new System.Windows.Forms.GroupBox();
            this.dateTime_DeadlineDate = new System.Windows.Forms.DateTimePicker();
            this.dateTime_OpenDate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label_PhoneNumber = new System.Windows.Forms.Label();
            this.label_DateofBirth = new System.Windows.Forms.Label();
            this.label_Amount = new System.Windows.Forms.Label();
            this.label_DabitorID = new System.Windows.Forms.Label();
            this.textBox_Amount = new System.Windows.Forms.TextBox();
            this.textBox_DebitorID = new System.Windows.Forms.TextBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.groupBox_CreditDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_CreditDetails
            // 
            this.groupBox_CreditDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_CreditDetails.Controls.Add(this.dateTime_DeadlineDate);
            this.groupBox_CreditDetails.Controls.Add(this.dateTime_OpenDate);
            this.groupBox_CreditDetails.Controls.Add(this.button1);
            this.groupBox_CreditDetails.Controls.Add(this.label_PhoneNumber);
            this.groupBox_CreditDetails.Controls.Add(this.label_DateofBirth);
            this.groupBox_CreditDetails.Controls.Add(this.label_Amount);
            this.groupBox_CreditDetails.Controls.Add(this.label_DabitorID);
            this.groupBox_CreditDetails.Controls.Add(this.textBox_Amount);
            this.groupBox_CreditDetails.Controls.Add(this.textBox_DebitorID);
            this.groupBox_CreditDetails.Location = new System.Drawing.Point(12, 12);
            this.groupBox_CreditDetails.Name = "groupBox_CreditDetails";
            this.groupBox_CreditDetails.Size = new System.Drawing.Size(495, 150);
            this.groupBox_CreditDetails.TabIndex = 8;
            this.groupBox_CreditDetails.TabStop = false;
            this.groupBox_CreditDetails.Text = "Credit Details";
            // 
            // dateTime_DeadlineDate
            // 
            this.dateTime_DeadlineDate.Location = new System.Drawing.Point(97, 112);
            this.dateTime_DeadlineDate.Name = "dateTime_DeadlineDate";
            this.dateTime_DeadlineDate.Size = new System.Drawing.Size(200, 20);
            this.dateTime_DeadlineDate.TabIndex = 13;
            // 
            // dateTime_OpenDate
            // 
            this.dateTime_OpenDate.Location = new System.Drawing.Point(97, 83);
            this.dateTime_OpenDate.Name = "dateTime_OpenDate";
            this.dateTime_OpenDate.Size = new System.Drawing.Size(200, 20);
            this.dateTime_OpenDate.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(439, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label_PhoneNumber
            // 
            this.label_PhoneNumber.AutoSize = true;
            this.label_PhoneNumber.Location = new System.Drawing.Point(6, 115);
            this.label_PhoneNumber.Name = "label_PhoneNumber";
            this.label_PhoneNumber.Size = new System.Drawing.Size(75, 13);
            this.label_PhoneNumber.TabIndex = 9;
            this.label_PhoneNumber.Text = "Deadline Date";
            // 
            // label_DateofBirth
            // 
            this.label_DateofBirth.AutoSize = true;
            this.label_DateofBirth.Location = new System.Drawing.Point(6, 87);
            this.label_DateofBirth.Name = "label_DateofBirth";
            this.label_DateofBirth.Size = new System.Drawing.Size(59, 13);
            this.label_DateofBirth.TabIndex = 7;
            this.label_DateofBirth.Text = "Open Date";
            // 
            // label_Amount
            // 
            this.label_Amount.AutoSize = true;
            this.label_Amount.Location = new System.Drawing.Point(6, 57);
            this.label_Amount.Name = "label_Amount";
            this.label_Amount.Size = new System.Drawing.Size(43, 13);
            this.label_Amount.TabIndex = 6;
            this.label_Amount.Text = "Amount";
            // 
            // label_DabitorID
            // 
            this.label_DabitorID.AutoSize = true;
            this.label_DabitorID.Location = new System.Drawing.Point(6, 33);
            this.label_DabitorID.Name = "label_DabitorID";
            this.label_DabitorID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_DabitorID.Size = new System.Drawing.Size(55, 13);
            this.label_DabitorID.TabIndex = 5;
            this.label_DabitorID.Text = "Debitor ID";
            // 
            // textBox_Amount
            // 
            this.textBox_Amount.Location = new System.Drawing.Point(97, 53);
            this.textBox_Amount.MaxLength = 8;
            this.textBox_Amount.Name = "textBox_Amount";
            this.textBox_Amount.Size = new System.Drawing.Size(336, 20);
            this.textBox_Amount.TabIndex = 1;
            this.textBox_Amount.TextChanged += new System.EventHandler(this.textBox_Amount_TextChanged);
            // 
            // textBox_DebitorID
            // 
            this.textBox_DebitorID.Location = new System.Drawing.Point(97, 26);
            this.textBox_DebitorID.Name = "textBox_DebitorID";
            this.textBox_DebitorID.Size = new System.Drawing.Size(336, 20);
            this.textBox_DebitorID.TabIndex = 0;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(218, 168);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 27);
            this.button_Save.TabIndex = 9;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // NewCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 207);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.groupBox_CreditDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Bank_Manager.Resources.AddCreditIco;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewCredit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Credit";
            this.groupBox_CreditDetails.ResumeLayout(false);
            this.groupBox_CreditDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_CreditDetails;
        private System.Windows.Forms.Label label_PhoneNumber;
        private System.Windows.Forms.Label label_DateofBirth;
        private System.Windows.Forms.Label label_Amount;
        private System.Windows.Forms.Label label_DabitorID;
        private System.Windows.Forms.TextBox textBox_Amount;
        private System.Windows.Forms.TextBox textBox_DebitorID;
        private System.Windows.Forms.DateTimePicker dateTime_DeadlineDate;
        private System.Windows.Forms.DateTimePicker dateTime_OpenDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_Save;
    }
}