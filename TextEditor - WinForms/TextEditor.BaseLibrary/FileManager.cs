using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

public interface IFileManager
{
    //void CreateNewFile();
    string GetContent(string filePath);
    string GetContent(string filePath, Encoding enc);
    void SaveContent(string filePath, string content);
    void SaveContent(string filePath, string content, Encoding enc);
    int GetSymbolCount(string content);

}

namespace TextEditor.BaseLibrary
{
    public class FileManager : IFileManager
    {
        // Данный класс реализует Бизнес-логику приложения паттерна MVP (Model View Presenter)

        private Encoding defaultEncoding = Encoding.GetEncoding(1251); // кодировка по умолчанию

        public string GetContent(string filePath)
        {
            return GetContent(filePath, defaultEncoding);
        }

        public string GetContent(string filePath, Encoding enc)
        {
            string result = File.ReadAllText(filePath, enc);
            return result;
        }

        public void SaveContent(string filePath, string content)
        {
            SaveContent(filePath, content, defaultEncoding);
        }

        public void SaveContent(string filePath, string content, Encoding enc)
        {
            File.WriteAllText(filePath, content, enc);
        }

        public int GetSymbolCount(string content)
        {
            int count = content.Length;
            return count;
        }
    }
}
