using Mvvm.Contracts;
using Mvvm.Enums;

namespace Mvvm.Models
{
    public class ItemModel : ModelBase, IItemModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ItemType ItemType { get; set; }
    }
}