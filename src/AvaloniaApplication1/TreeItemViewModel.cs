using Avalonia.Collections;
using Eremex.AvaloniaUI.Controls.Common;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaApplication1;

public class TreeItemViewModel : ViewModelBase
{
    public TreeItemViewModel(string name, IEnumerable<TreeItemViewModel>? items = null)
    {
        Name = name;
        Items = new DataGridCollectionView(items?.ToList() ?? []);
    }

    public string Name { get; }

    public DataGridCollectionView Items { get; }

    public bool HasItems => Items.Count > 0;

    private bool _isExpanded;

    public bool IsExpanded
    {
        get => _isExpanded;
        set
        {
            _isExpanded = value;
            OnPropertyChanged();
        }
    }
}
