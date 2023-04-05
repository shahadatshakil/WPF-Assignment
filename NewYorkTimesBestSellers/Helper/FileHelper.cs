using Newtonsoft.Json;
using NewYorkTimesBestSellers.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace NewYorkTimesBestSellers.Helper
{
    public class FileHelper
    {
        public ObservableCollection<Book> GetBooks(string filePath)
        {
            ObservableCollection<Book> books = new ObservableCollection<Book>();

            if (!File.Exists(filePath))
            {
                MessageBox.Show("No file found!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return books;
            }

            string str = File.ReadAllText(filePath);
            try
            {
                books = JsonConvert.DeserializeObject<ObservableCollection<Book>>(str);
            }
            catch (Exception e)
            {
                Console.WriteLine("No file found with book data!");
            }
            return books;
        }

        public void SaveBooks(ObservableCollection<Book> books, string fileName)
        {
            string str = JsonConvert.SerializeObject(books);
            File.WriteAllText(fileName, str);
        }
    }
}
