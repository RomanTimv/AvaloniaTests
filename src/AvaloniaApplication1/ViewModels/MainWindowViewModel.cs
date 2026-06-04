using Avalonia.Collections;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        ChangeIconCommand = new RelayCommand(ChangeIconExecute, ChangeIconCanExecute);
    }
    
    public AvaloniaList<TreeItemViewModel> Items { get; } =
    [
        new("Item 1", 0,
        [
            new("Item 1.1", 0, []),
            new("Item 1.1", 0, []),
        ]),
        new("Item 2", 0,
        [
            new("Item 1.2", 0, []),
            new("Item 1.2", 0, []),
        ]),
    ];
    
    private TreeItemViewModel? _selectedItem;

    public TreeItemViewModel? SelectedItem
    {
        get => _selectedItem;
        set
        {
            SetProperty(ref _selectedItem, value);
            ChangeIconCommand.NotifyCanExecuteChanged();
        }
    }

    public IRelayCommand ChangeIconCommand { get; }

    private void ChangeIconExecute()
    {
        if (SelectedItem == null)
            return;

        var idx = SelectedItem.IconIndex + 1;
        if (idx > 2)
            idx = 0;
        SelectedItem.IconIndex = idx;
    }

    private bool ChangeIconCanExecute()
    {
        return SelectedItem != null;
    }
}