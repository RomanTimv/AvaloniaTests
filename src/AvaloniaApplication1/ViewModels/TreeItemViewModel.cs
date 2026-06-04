using System;
using System.Collections.Generic;
using Avalonia.Collections;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication1.ViewModels;

public class TreeItemViewModel : ObservableObject
{
    public TreeItemViewModel(string name, int iconIndex, IEnumerable<TreeItemViewModel> items)
    {
        _name = name;
        _iconIndex = iconIndex;
        Items = new(_itemList = new AvaloniaList<TreeItemViewModel>(items));
    }

    private readonly string _name;

    public string Name => $"{_name} ({_iconIndex})";
    
    private int _iconIndex;

    internal int IconIndex
    {
        get => _iconIndex;
        set
        {
            _iconIndex = value;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Image));
        }
    }
    
    public Bitmap Image => Icons[IconIndex];

    private readonly AvaloniaList<TreeItemViewModel> _itemList;
    
    public DataGridCollectionView Items { get; }
    
    public bool HasItems => _itemList.Count > 0;

    private static readonly Bitmap[] Icons =
    [
        new(AssetLoader.Open(new Uri("avares://AvaloniaApplication1/Assets/icon1.png"))),
        new(AssetLoader.Open(new Uri("avares://AvaloniaApplication1/Assets/icon2.png"))),
        new(AssetLoader.Open(new Uri("avares://AvaloniaApplication1/Assets/icon3.png"))),
    ];
}