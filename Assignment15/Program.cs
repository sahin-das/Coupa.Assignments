using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

public class Program
{
    public static void Main()
    {
        ObservableCollection<string> items = new ObservableCollection<string>();

        items.CollectionChanged += OnCollectionChanged;

        items.Add("Apple");
        items.Add("Banana");
        items.Remove("Apple");
    }

    private static void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                foreach (var newItem in e.NewItems)
                {
                    Console.WriteLine($"Element '{newItem}' is added to the collection.");
                }
                break;

            case NotifyCollectionChangedAction.Remove:
                foreach (var oldItem in e.OldItems)
                {
                    Console.WriteLine($"Element '{oldItem}' is removed from the collection.");
                }
                break;

            // You can add other cases if needed for Replace, Move, or Reset
        }
    }
}