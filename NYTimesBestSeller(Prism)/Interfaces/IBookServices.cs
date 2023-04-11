using NYTimesBestSeller_Prism_.Models;
using System.Collections.ObjectModel;

namespace NYTimesBestSeller_Prism_.Interfaces
{
    public interface IBookServices
    {
        public ObservableCollection<Book> GetBooksFromFile(string fileName);
        public ObservableCollection<Book> GetBooksFromAPI();
        public void SaveBooks(ObservableCollection<Book> books, string fileName);
    }
}
