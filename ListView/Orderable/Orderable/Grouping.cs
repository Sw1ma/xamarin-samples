using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OrderableListViewItems
{
    /// <summary>
    /// Grouping of items(I) by key (K) into ObservableCollection.
    /// </summary>
    public class Grouping<K, I> : ObservableCollection<I>
    {
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public K Key { get; }

        /// <summary>
        /// Returns list of items in the grouping.
        /// </summary>
        public new IList<I> Items => base.Items;

        /// <summary>
        /// Initializes a new instance of the Grouping class.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="items">Items.</param>
        public Grouping(K key, IEnumerable<I> items)
        {
            Key = key;

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
