using System.Collections.ObjectModel;
using Avalonia.Controls;

namespace AvaloniaApplication1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Items =
        [
            new ItemViewModel("111"),
            new ItemViewModel("222"),
            new ItemViewModel("333"),
        ];
        
        DataContext = this;
    }

    public ObservableCollection<ItemViewModel> Items { get; }
}