using Microsoft.Win32;
using NYTimesBestSeller_Prism_.Events;
using NYTimesBestSeller_Prism_.Interfaces;
using NYTimesBestSeller_Prism_.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Data;

namespace NYTimesBestSeller_Prism_.ViewModels
{
    public class BookListViewModel: BindableBase
    {
        public DelegateCommand ViewLatestBooksCommand { get; private set; }
        public DelegateCommand ViewFromFileCommand { get; private set; }
        public DelegateCommand SaveFileCommand { get; private set; }

        private IBookServices bookServices;

        private Book selectedBook;

        private ObservableCollection<Book> books;

        private string filterText;

        private readonly IEventAggregator eventAggregator;

        public string FilterText
        {
            get 
            { 
                return filterText;
            }
            set
            { 
                SetProperty(ref filterText, value);
                CollectionViewSource.GetDefaultView(Books).Refresh();
            }
        }

        public ObservableCollection<Book> Books
        {
            get 
            { 
                return books;
            }
            set 
            {
                SetProperty(ref books, value);
                CollectionViewSource.GetDefaultView(Books).Filter = FilterBooks;
            }
        }

        public Book SelectedBook
        {
            get
            {
                return selectedBook;
            }
            set
            {
                SetProperty(ref selectedBook, value);
                eventAggregator.GetEvent<BookSentEvent>().Publish(SelectedBook);
            }
        }

        public BookListViewModel(IBookServices bookServices, IEventAggregator eventAggregator)
        {
            ViewLatestBooksCommand = new DelegateCommand(SetBooksFromAPI);
            ViewFromFileCommand = new DelegateCommand(SetBooksFromFile);
            SaveFileCommand = new DelegateCommand(SaveFile);

            this.bookServices = bookServices;
            this.eventAggregator = eventAggregator;
            selectedBook = new Book();
            filterText = string.Empty;
            books = new ObservableCollection<Book>();
        }

        private void SetBooksFromAPI()
        {
            Books = bookServices.GetBooksFromAPI();
        }

        private void SetBooksFromFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFile.ShowDialog() == true)
            {
                string fileName = openFile.FileName;
                Books = bookServices.GetBooksFromFile(fileName);
            }
        }

        private void SaveFile()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".txt";
            saveFile.Filter = "Text documents (.txt)|*.txt";
            saveFile.InitialDirectory = Directory.GetCurrentDirectory();
            saveFile.OverwritePrompt = true;

            if (saveFile.ShowDialog() == true)
            {
                string fileName = saveFile.FileName;
                bookServices.SaveBooks(Books, fileName);
                MessageBox.Show("File saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool FilterBooks(object obj)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                return true;
            }

            if(obj is Book book)
            {
                return book.title.StartsWith(FilterText);
            }
            return false;
        }
    }
}
