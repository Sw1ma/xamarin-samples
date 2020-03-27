
namespace OrderableListViewItems
{
    public class Item : Observable
    {
        private string name;
        public string Name { get => name; set => SetProperty(ref name, value); }

        private string description;
        public string Description { get => description; set => SetProperty(ref description, value); }

        private string category;
        public string Category { get => category; set => SetProperty(ref category, value); }

        private int order;
        public int Order { get => order; set => SetProperty(ref order, value); }
    }
}
