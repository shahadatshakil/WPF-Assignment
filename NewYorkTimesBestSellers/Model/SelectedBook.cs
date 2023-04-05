using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NewYorkTimesBestSellers.Model
{
    public class SelectedBook: INotifyPropertyChanged
    {
        private Book selectedtBook;

        public Book Book
        {
            get
            {
                return selectedtBook;
            }
            set
            {
                selectedtBook = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
