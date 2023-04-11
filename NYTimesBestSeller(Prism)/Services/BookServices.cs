using NYTimesBestSeller_Prism_.Helpers;
using NYTimesBestSeller_Prism_.Interfaces;
using NYTimesBestSeller_Prism_.Models;
using System.Collections.ObjectModel;

namespace NYTimesBestSeller_Prism_.Services
{
    public class BookServices: IBookServices
    {
        private FileHelper fileHelper = new FileHelper();
        private APIHelper apiHelper = new APIHelper();
        public ObservableCollection<Book> GetBooksFromFile(string fileName)
        {
            return fileHelper.GetBooks(fileName);
        }

        public ObservableCollection<Book> GetBooksFromAPI()
        {
            return apiHelper.GetBooks();
        }

        public void SaveBooks(ObservableCollection<Book> books, string fileName)
        {
            fileHelper.SaveBooks(books, fileName);
        }
    }
}
