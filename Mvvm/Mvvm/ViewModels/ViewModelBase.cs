using Mvvm.Core;

namespace Mvvm.ViewModels
{
    public class ViewModelBase : Observable
    {
        public ViewModelBase()
        { }

        string _pageTitle;
        public string PageTitle
        {
            get => _pageTitle;
            set => SetProperty(ref _pageTitle, value);
        }

        bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                SetProperty(ref _isBusy, value);
                OnPropertyChanged(nameof(IsNotBusy));
            }
        }

        public bool IsNotBusy => !IsBusy;
    }
}