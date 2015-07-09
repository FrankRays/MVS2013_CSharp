namespace TextEditor
{
    partial class FormMainWindow
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
            this.menuOnTop = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewFont = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxMainField = new System.Windows.Forms.TextBox();
            this.statusStringOnBot = new System.Windows.Forms.StatusStrip();
            this.statusStringFixed = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStringSymbolsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOnTop.SuspendLayout();
            this.statusStringOnBot.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuOnTop
            // 
            this.menuOnTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuOnTop.Location = new System.Drawing.Point(0, 0);
            this.menuOnTop.Name = "menuOnTop";
            this.menuOnTop.Size = new System.Drawing.Size(656, 24);
            this.menuOnTop.TabIndex = 0;
            this.menuOnTop.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.menuFileOpen,
            this.toolStripSeparator1,
            this.menuFileSave,
            this.menuFileSaveAs});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuFileNew
            // 
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.Size = new System.Drawing.Size(152, 22);
            this.menuFileNew.Text = "New";
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.Size = new System.Drawing.Size(152, 22);
            this.menuFileOpen.Text = "Open";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.Size = new System.Drawing.Size(152, 22);
            this.menuFileSave.Text = "Save";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewFont});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // menuViewFont
            // 
            this.menuViewFont.Name = "menuViewFont";
            this.menuViewFont.Size = new System.Drawing.Size(98, 22);
            this.menuViewFont.Text = "Font";
            // 
            // textBoxMainField
            // 
            this.textBoxMainField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMainField.Location = new System.Drawing.Point(13, 28);
            this.textBoxMainField.Multiline = true;
            this.textBoxMainField.Name = "textBoxMainField";
            this.textBoxMainField.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMainField.Size = new System.Drawing.Size(631, 376);
            this.textBoxMainField.TabIndex = 1;
            // 
            // statusStringOnBot
            // 
            this.statusStringOnBot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStringFixed,
            this.statusStringSymbolsCount});
            this.statusStringOnBot.Location = new System.Drawing.Point(0, 413);
            this.statusStringOnBot.Name = "statusStringOnBot";
            this.statusStringOnBot.Size = new System.Drawing.Size(656, 22);
            this.statusStringOnBot.TabIndex = 2;
            this.statusStringOnBot.Text = "statusStrip1";
            // 
            // statusStringFixed
            // 
            this.statusStringFixed.Name = "statusStringFixed";
            this.statusStringFixed.Size = new System.Drawing.Size(55, 17);
            this.statusStringFixed.Text = "Symbols:";
            // 
            // statusStringSymbolsCount
            // 
            this.statusStringSymbolsCount.Name = "statusStringSymbolsCount";
            this.statusStringSymbolsCount.Size = new System.Drawing.Size(13, 17);
            this.statusStringSymbolsCount.Text = "0";
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Name = "menuFileSaveAs";
            this.menuFileSaveAs.Size = new System.Drawing.Size(152, 22);
            this.menuFileSaveAs.Text = "Save as..";
            // 
            // FormMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 435);
            this.Controls.Add(this.statusStringOnBot);
            this.Controls.Add(this.textBoxMainField);
            this.Controls.Add(this.menuOnTop);
            this.MainMenuStrip = this.menuOnTop;
            this.Name = "FormMainWindow";
            this.Text = "Text Editor";
            this.menuOnTop.ResumeLayout(false);
            this.menuOnTop.PerformLayout();
            this.statusStringOnBot.ResumeLayout(false);
            this.statusStringOnBot.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuOnTop;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuViewFont;
        private System.Windows.Forms.TextBox textBoxMainField;
        private System.Windows.Forms.StatusStrip statusStringOnBot;
        private System.Windows.Forms.ToolStripStatusLabel statusStringFixed;
        private System.Windows.Forms.ToolStripStatusLabel statusStringSymbolsCount;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;

    }
}

