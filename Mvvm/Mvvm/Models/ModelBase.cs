using Mvvm.Contracts;
using Mvvm.Core;

namespace Mvvm.Models
{
    public class ModelBase : Observable, IModelBase
    {
        public string Id { get; set; }
    }
}