using NYTimesBestSeller_Prism_.Events;
using NYTimesBestSeller_Prism_.Models;
using Prism.Events;
using Prism.Mvvm;

namespace NYTimesBestSeller_Prism_.ViewModels
{
    public class BookDetailsViewModel:BindableBase
    {
        private IEventAggregator eventAggregator;

        private Book selectedBook;

        public Book SelectedBook
        {
            get
            {
                return selectedBook;
            }
            set
            {
                SetProperty(ref selectedBook, value);
            }
        }

        public BookDetailsViewModel(IEventAggregator eventAggregator)
        {
            selectedBook = new Book();
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<BookSentEvent>().Subscribe(OnSelectedBookChanged);
        }

        private void OnSelectedBookChanged(object selectedBook)
        {
            SelectedBook = (Book)selectedBook;
        }

    }
}
