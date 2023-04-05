using Microsoft.Win32;
using NewYorkTimesBestSellers.Command;
using NewYorkTimesBestSellers.Helper;
using NewYorkTimesBestSellers.Model;
using NewYorkTimesBestSellers.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace NewYorkTimesBestSellers.ViewModel
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Book> filteredBooks;

        private List<Book> Allbook;

        private BookService bookService;

        private string filterBookName;
        public SelectedBook CurrentSelectedBook { get; set; } 
        public Book MySelectedBook { get; set; }
        public ICommand SeeLatestButtonCommand { get; set; }
        public ICommand SeeFromFileButtonCommand { get; set; }
        public ICommand SaveFileButtonCommand { get; set; }
        public ICommand MouseClickCommand { get; set; }
 
        public ObservableCollection<Book> FilteredBooks
        {
            get
            {
                return filteredBooks;
            }
            set
            {
                filteredBooks = value;
                NotifyPropertyChanged();
            }
        }

        public string FilterBookName
        {
            get
            {
                return filterBookName;
            }
            set
            {
                filterBookName = value;
                OnFilterChanged(FilterBookName);
            }
        }

        public BookViewModel()
        {
            SeeLatestButtonCommand = new RelayCommand(OnSeeLatestButtonClicked);
            SeeFromFileButtonCommand = new RelayCommand(OnSeeFromFileButtonClicked);
            SaveFileButtonCommand = new RelayCommand(OnSaveFileButtonClicked);
            MouseClickCommand = new RelayCommand(OnMouseDoubleClicked);

            CurrentSelectedBook = new SelectedBook();
            MySelectedBook = new Book();
            filteredBooks = new ObservableCollection<Book>();
            bookService = new BookService();
        }

        private void OnSeeLatestButtonClicked()
        {
            FilteredBooks = bookService.GetBooksFromAPI();
            Allbook = new List<Book>(FilteredBooks);
        }

        private void OnSeeFromFileButtonClicked()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFile.ShowDialog() == true)
            {
                string fileName = openFile.FileName;

                FilteredBooks = bookService.GetBooksFromFile(fileName);
                Allbook = new List<Book>(FilteredBooks);
            }
        }

        private void OnFilterChanged(string filter)
        {
            var res = Allbook.Where(book => book.title.StartsWith(filter)).ToList();
            FilteredBooks.Clear();

            foreach(Book book in res)
            {
                FilteredBooks.Add(book);
            }
        }

        private void OnSaveFileButtonClicked()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".txt";
            saveFile.Filter = "Text documents (.txt)|*.txt";
            saveFile.InitialDirectory = Directory.GetCurrentDirectory();
            saveFile.OverwritePrompt = true;

            if (saveFile.ShowDialog() == true)
            {
                string fileName = saveFile.FileName;
                bookService.SaveBooks(FilteredBooks, fileName);
                MessageBox.Show("File saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void OnMouseDoubleClicked()
        {
            CurrentSelectedBook.Book = MySelectedBook;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
