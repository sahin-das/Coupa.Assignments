using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace Assignment15
{
    class Program
    {
        public static void Main(string[] args)
        {
            var items = new ObservableCollection<string>();

            items.CollectionChanged += Items_CollectionChanged;

            items.Add("Item 1");
            items.Add("Item 2");

            items.Remove("Item 1");
        }
 
        private static void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var newItem in e.NewItems)
                    {
                        Console.WriteLine($"Element '{newItem}' is added in collection");
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var oldItem in e.OldItems)
                    {
                        Console.WriteLine($"Element '{oldItem}' is removed from collection");
                    }
                    break;

                default:
                    Console.WriteLine($"Other action: {e.Action}");
                    break;
            }
        }
    }
}