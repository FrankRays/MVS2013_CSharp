using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextEditor
{
    // Интерфейс для взаимодействия с графическим интерфейсом MainForm
    interface IMainForm
    {
        string FilePath { get; }
        string Content { get; set; }
        void SetSymbolCount(int count);
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler FileSaveAsClick;
        event EventHandler ContentChanged;
    }

    // Данный класс реализует View (Model View Presenter)
    public partial class FormMainWindow : Form, IMainForm
    {
        private string filePath = "";  // поле содержит путь к файлу открытому в данный момент

        public FormMainWindow()
        {
            InitializeComponent();
            menuFileOpen.Click += menuFileOpen_Click;
            menuFileSave.Click += menuFileSave_Click;
            menuFileSaveAs.Click += menuFileSaveAs_Click;
            menuFileNew.Click += menuFileNew_Click;
            menuViewFont.Click += menuViewFont_Click;
            textBoxMainField.TextChanged += textBoxMainField_TextChanged;
        }

        private void ChangeFormTitle(string CurrentFileName)
        {
            this.Text = "Text Editor " + CurrentFileName;
        }

        #region Проброс событий
        void menuFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text Files|*.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filePath = dlg.FileName;
                FileSaveAsClick(this, EventArgs.Empty);

                string fileName = Path.GetFileName(filePath);
                ChangeFormTitle(fileName);
            }
        }

        void textBoxMainField_TextChanged(object sender, EventArgs e)
        {
            ContentChanged(this, EventArgs.Empty);
        }

        void menuViewFont_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Font font;
                font = dlg.Font;
                textBoxMainField.Font = font;
            }
        }

        void menuFileNew_Click(object sender, EventArgs e)
        {
            filePath = "";
            textBoxMainField.Text = "";

            ChangeFormTitle("New File");
        }

        void menuFileSave_Click(object sender, EventArgs e)
        {
            if (filePath == "")
            {
                menuFileSaveAs_Click(this, EventArgs.Empty);
            }
            else 
                FileSaveClick(this, EventArgs.Empty);
        }

        void menuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Files|*.txt|All Files|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filePath = dlg.FileName;
                FileOpenClick(this, EventArgs.Empty);

                string fileName = Path.GetFileName(filePath);
                ChangeFormTitle(fileName);
            }
        }
        #endregion

        #region Реализация интерфейса IMainForm
        public string FilePath
        {
            get { return filePath; }
        }

        public string Content
        {
            get { return textBoxMainField.Text;  }
            set { textBoxMainField.Text = value; }
        }

        public void SetSymbolCount(int count)
        {
            statusStringSymbolsCount.Text = count.ToString();
        }

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler FileSaveAsClick;
        public event EventHandler ContentChanged;
        #endregion

    }
}
