using Mvvm.Contracts;
using Mvvm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mvvm.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            PageTitle = "Mvvm Sample";

            Items = new List<IItemModel>();
            LoadCommand = new Command(Load, 
                canExecute: () => { return IsNotBusy; });
        }

        private IItemModel _item;
        public IItemModel Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
        }

        public IList<IItemModel> Items { get; set; }

        public ICommand LoadCommand;

        public void Load()
        {
            if (Item != null)
                return;

            var item = new ItemModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "New item",
                Description = "Some description of an item.",
                ItemType = Enums.ItemType.TypeA
            };

            Items.Add(item);
            Item = Items.Where(i => i.Id == item.Id).FirstOrDefault();
        }
    }
}