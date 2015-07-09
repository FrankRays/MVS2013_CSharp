using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.BaseLibrary; // подключаем пространство имен где реализуется логика приложения

namespace TextEditor
{
    // Данный класс реализует Presenter, соеденяет остальные слои паттерна MVP (Model View Presenter)
    class MainPresenter
    {
        private readonly IMainForm view;
        private readonly IMessageService messageService;
        private readonly IFileManager fileManager;

        public MainPresenter(IMainForm _view, IFileManager _fileManager, IMessageService _messageService)
        {
            view = _view;
            fileManager = _fileManager;
            messageService = _messageService;

            view.ContentChanged += view_ContentChanged;
            view.FileOpenClick += view_FileOpenClick;
            view.FileSaveClick += view_FileSaveClick;
            view.FileSaveAsClick += view_FileSaveAsClick;
        }

        void view_FileSaveAsClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = view.FilePath;
                string content = view.Content;

                fileManager.SaveContent(filePath, content);

                messageService.ShowMessage("File Saved!");
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        void view_FileNewClick(object sender, EventArgs e)
        {
            //try
            //{
            //    string filePath = view.FilePath;

            //    string content = fileManager.GetContent(filePath);
            //    int symbols = fileManager.GetSymbolCount(filePath);

            //    view.Content = content;
            //    view.SetSymbolCount(symbols);
            //}
            //catch (Exception ex)
            //{
            //    messageService.ShowError(ex.Message);
            //}
        }

        void view_FileSaveClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = view.FilePath;
                string content = view.Content;

                fileManager.SaveContent(filePath, content);

                messageService.ShowMessage("File Saved!");
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        void view_FileOpenClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = view.FilePath;

                string content = fileManager.GetContent(filePath);
                int symbols = fileManager.GetSymbolCount(content);

                view.Content = content;
                view.SetSymbolCount(symbols);
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        void view_ContentChanged(object sender, EventArgs e)
        {
            string content = view.Content;

            int count = content.Count();

            view.SetSymbolCount(count);
        }


    }
}
