using Avalonia.Controls;
using System.Collections.Generic;

namespace AvaloniaApplication1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Items =
        [
            new("1",
            [
                new("1.1"),
                new("1.2"),
                new("1.3")
            ]),
            new("2",
            [
                new("2.1"),
                new("2.2"),
                new("2.3")
            ])
        ];

        DataContext = this;
    }

    public List<TreeItemViewModel> Items { get; }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Items[1].IsExpanded = !Items[1].IsExpanded;
    }
}