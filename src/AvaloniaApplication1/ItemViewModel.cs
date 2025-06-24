using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication1;

public class ItemViewModel : ObservableObject
{
    public ItemViewModel(string name, ObservableCollection<ItemViewModel>? items = null)
    {
        Name = name;
        Items = items ?? [];
        Items.CollectionChanged += ItemsOnCollectionChanged;
    }

    private void ItemsOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        OnPropertyChanged(nameof(HasItems));
    }

    public string Name { get; }

    public ObservableCollection<ItemViewModel> Items { get; }
    
    public bool HasItems => Items.Count > 0;
}
