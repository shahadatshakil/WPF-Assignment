using NewYorkTimesBestSellers.Helper;
using NewYorkTimesBestSellers.Model;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace NewYorkTimesBestSellers.Services
{
    public class BookService
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
