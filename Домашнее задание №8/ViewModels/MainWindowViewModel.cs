using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Домашнее_задание__8.ViewModels.Pages;

namespace Домашнее_задание__8.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]private object content;
    [ObservableProperty]private ObservableCollection<BaseViewModel> vmbaseCollection;
    public RelayCommand<object> SwitchViewCommand { get; }
    public MainWindowViewModel() {
        vmbaseCollection = new ObservableCollection<BaseViewModel>
        {
            new DataGridViewModel(),
            new TreeViewModel()
        };

        Content = null;
        SwitchViewCommand = new RelayCommand<object>(SwitchView);
    }

    private void SwitchView(object parameter)
    {
        if (parameter is BaseViewModel selectedViewModel)
        {
            Content = selectedViewModel;
        }
    }


}
