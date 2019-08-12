using Mvvm.Enums;

namespace Mvvm.Contracts
{
    public interface IItemModel : IModelBase
    {
        string Title { get; set; }
        string Description { get; set; }
        ItemType ItemType { get; set; }
    }
}