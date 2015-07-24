namespace Bank_Manager
{
    partial class NewPayment
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
            this.dateTime_Date = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label_PaymentDate = new System.Windows.Forms.Label();
            this.label_Amount = new System.Windows.Forms.Label();
            this.label_CreditID = new System.Windows.Forms.Label();
            this.textBox_Amount = new System.Windows.Forms.TextBox();
            this.textBox_CreditID = new System.Windows.Forms.TextBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.groupBox_CreditDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_CreditDetails
            // 
            this.groupBox_CreditDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_CreditDetails.Controls.Add(this.dateTime_Date);
            this.groupBox_CreditDetails.Controls.Add(this.button1);
            this.groupBox_CreditDetails.Controls.Add(this.label_PaymentDate);
            this.groupBox_CreditDetails.Controls.Add(this.label_Amount);
            this.groupBox_CreditDetails.Controls.Add(this.label_CreditID);
            this.groupBox_CreditDetails.Controls.Add(this.textBox_Amount);
            this.groupBox_CreditDetails.Controls.Add(this.textBox_CreditID);
            this.groupBox_CreditDetails.Location = new System.Drawing.Point(12, 12);
            this.groupBox_CreditDetails.Name = "groupBox_CreditDetails";
            this.groupBox_CreditDetails.Size = new System.Drawing.Size(491, 125);
            this.groupBox_CreditDetails.TabIndex = 9;
            this.groupBox_CreditDetails.TabStop = false;
            this.groupBox_CreditDetails.Text = "Payment Details";
            // 
            // dateTime_Date
            // 
            this.dateTime_Date.Location = new System.Drawing.Point(97, 78);
            this.dateTime_Date.Name = "dateTime_Date";
            this.dateTime_Date.Size = new System.Drawing.Size(200, 20);
            this.dateTime_Date.TabIndex = 12;
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
            // label_PaymentDate
            // 
            this.label_PaymentDate.AutoSize = true;
            this.label_PaymentDate.Location = new System.Drawing.Point(6, 78);
            this.label_PaymentDate.Name = "label_PaymentDate";
            this.label_PaymentDate.Size = new System.Drawing.Size(30, 13);
            this.label_PaymentDate.TabIndex = 7;
            this.label_PaymentDate.Text = "Date";
            // 
            // label_Amount
            // 
            this.label_Amount.AutoSize = true;
            this.label_Amount.Location = new System.Drawing.Point(6, 52);
            this.label_Amount.Name = "label_Amount";
            this.label_Amount.Size = new System.Drawing.Size(43, 13);
            this.label_Amount.TabIndex = 6;
            this.label_Amount.Text = "Amount";
            // 
            // label_CreditID
            // 
            this.label_CreditID.AutoSize = true;
            this.label_CreditID.Location = new System.Drawing.Point(6, 26);
            this.label_CreditID.Name = "label_CreditID";
            this.label_CreditID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_CreditID.Size = new System.Drawing.Size(48, 13);
            this.label_CreditID.TabIndex = 5;
            this.label_CreditID.Text = "Credit ID";
            // 
            // textBox_Amount
            // 
            this.textBox_Amount.Location = new System.Drawing.Point(97, 52);
            this.textBox_Amount.MaxLength = 12;
            this.textBox_Amount.Name = "textBox_Amount";
            this.textBox_Amount.Size = new System.Drawing.Size(154, 20);
            this.textBox_Amount.TabIndex = 1;
            this.textBox_Amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Amount_KeyPress);
            // 
            // textBox_CreditID
            // 
            this.textBox_CreditID.Location = new System.Drawing.Point(97, 26);
            this.textBox_CreditID.Name = "textBox_CreditID";
            this.textBox_CreditID.Size = new System.Drawing.Size(336, 20);
            this.textBox_CreditID.TabIndex = 0;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(220, 143);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 31);
            this.button_Save.TabIndex = 10;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // NewPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 185);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.groupBox_CreditDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Bank_Manager.Resources.AddPaymentIco;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Payment";
            this.groupBox_CreditDetails.ResumeLayout(false);
            this.groupBox_CreditDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_CreditDetails;
        private System.Windows.Forms.DateTimePicker dateTime_Date;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_PaymentDate;
        private System.Windows.Forms.Label label_Amount;
        private System.Windows.Forms.Label label_CreditID;
        private System.Windows.Forms.TextBox textBox_Amount;
        private System.Windows.Forms.TextBox textBox_CreditID;
        private System.Windows.Forms.Button button_Save;
    }
}