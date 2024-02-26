using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Домашнее_задание__4.Class;

namespace Домашнее_задание__4.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void TappedListBox(object? sender, TappedEventArgs e)
    {
        if (e.Source is not IDataContextProvider provider) return;

        if (provider.DataContext is not Directoryies directory) return;

        if (DataContext is not ViewModels.MainViewModel viewModel) return;

        viewModel.HandleItemClick(directory);
    }

}
