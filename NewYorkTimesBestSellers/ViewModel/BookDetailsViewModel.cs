using NewYorkTimesBestSellers.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NewYorkTimesBestSellers.ViewModel
{
    public class BookDetailsViewModel: INotifyPropertyChanged
    {
        public Book SelectedBook { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
