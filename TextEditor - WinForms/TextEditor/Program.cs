using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.BaseLibrary;

namespace TextEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormMainWindow formMainWindow = new FormMainWindow();
            MessageService messageService = new MessageService();
            FileManager fileManager = new FileManager();

            MainPresenter mainPresenter = new MainPresenter(formMainWindow, fileManager, messageService);

            Application.Run(formMainWindow);
        }
    }
}
