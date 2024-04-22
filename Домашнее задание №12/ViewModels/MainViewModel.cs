using System;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace hw_12.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<bool> InputValues { get; set; } = new ObservableCollection<bool>()
    {
        false,
        false,
        false,
        true
    };

    [ObservableProperty]
    public bool? _output = false;

    public MainViewModel()
    {
        /*Task.Run(() =>
        {
            Thread.Sleep(5000);
            Console.WriteLine("Changed..");
            InputValues.Clear();
            InputValues.Add(true);
        });*/
    }
}
