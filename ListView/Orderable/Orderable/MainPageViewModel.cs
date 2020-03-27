using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OrderableListViewItems
{
    public class MainPageViewModel : Observable
    {
        public MainPageViewModel()
        {
            InitializeCommands();
        }

        public ObservableCollection<Grouping<string, Item>> 
            ItemsGroupedByCategory { get; set; }

        public bool EditMode { get; set; } = false;
        public string EditModeText { get; set; } = "Reorder";

        public ICommand LoadCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand MoveUpCommand { get; private set; }
        public ICommand MoveDownCommand { get; private set; }

        private void InitializeCommands()
        {
            LoadCommand = new Command(
                execute: () =>
                {
                    var items = new List<Item>
                    {
                        new Item {
                            Name = "Mouse",
                            Description = "This is a mouse description",
                            Category = "Desktop",
                            Order = 1
                        },
                        new Item {
                            Name = "Keyboard",
                            Description = "This is a keyboard description",
                            Category = "Desktop",
                            Order = 2
                        },
                        new Item {
                            Name = "Screen",
                            Description = "This is a screen description",
                            Category = "Desktop",
                            Order = 3
                        },
                        new Item {
                            Name = "Notebook",
                            Description = "This is a notebook description",
                            Category = "Desktop",
                            Order = 4
                        },
                        new Item {
                            Name = "Phone",
                            Description = "This is a phone description",
                            Category = "Device",
                            Order = 1
                        },
                        new Item {
                            Name = "Tablet",
                            Description = "This is a tablet description",
                            Category = "Device",
                            Order = 2
                        }
                    };

                    var grouped =
                        from i in items
                        orderby i.Order
                        group i by i.Category into g
                        select new Grouping<string, Item>(g.Key, g);

                    ItemsGroupedByCategory = 
                        new ObservableCollection<Grouping<string, Item>>(grouped);

                    OnPropertyChanged(nameof(ItemsGroupedByCategory));
                },
                canExecute: () => { return true; });

            EditCommand = new Command(
                execute: async () => 
                {
                    await Task.Delay(10);

                    EditMode = !EditMode;
                    EditModeText = EditMode ? "Save" : "Reorder";

                    OnPropertyChanged(nameof(EditMode));
                    OnPropertyChanged(nameof(EditModeText));
                },
                canExecute: () => { return true; }
                );

            MoveUpCommand = new Command<object>(
                execute: async (obj) =>
                {
                    if (!(obj is Item item))
                        return;

                    await Task.Delay(10);

                    var group = ItemsGroupedByCategory.Where(
                        g => g.Key.Equals(item.Category)).FirstOrDefault();

                    var oldIndex = group.IndexOf(item);
                    var newIndex = oldIndex - 1;

                    /// Prevent index out of group range exception.
                    if (newIndex < 0)
                        return;

                    oldIndex += 1;

                    group.Insert(newIndex, item);
                    group.RemoveAt(oldIndex);

                    /// Reset order for each item.
                    int order = 1;
                    for (int i = 0; i < group.Count; i++)
                    {
                        group[i].Order = order++;
                    }
                },
                canExecute: (obj) => { return true; });

            MoveDownCommand = new Command<object>(
                execute: async (obj) =>
                {
                    if (!(obj is Item item))
                        return;

                    await Task.Delay(10);

                    var group = ItemsGroupedByCategory.Where(
                        g => g.Key.Equals(item.Category)).FirstOrDefault();

                    var oldIndex = group.IndexOf(item);
                    var newIndex = oldIndex + 2;

                    /// Prevent index out of group range exception.
                    if (newIndex > group.Count)
                        return;

                    group.Insert(newIndex, item);
                    group.RemoveAt(oldIndex);

                    /// Reset order for each item.
                    int order = 1;
                    for (int i = 0; i < group.Count; i++)
                    {
                        group[i].Order = order++;
                    }
                },
                canExecute: (obj) => { return true; });
        }
    }
}
