using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderableListViewItems
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        protected MainPageViewModel ViewModel => (MainPageViewModel)BindingContext;

        public MainPage()
        {
            InitializeComponent();           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.LoadCommand
                .Execute(null);
        }
    }
}
