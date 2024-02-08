using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Домашнее_задание__2;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void ClickButton(object sender, RoutedEventArgs args) {
        if (sender is Button button) 
            Rectangle.Background = button.Background;
    }
}