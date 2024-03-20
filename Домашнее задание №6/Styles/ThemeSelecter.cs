using System;

namespace Домашнее_задание__6.ViewModels
{
    // Light Theme : #436CDB #6B90EC
    // Dark Theme : #010F37 #2A3957

    public partial class MainWindowViewModel : ViewModelBase
    {
        public string? FirstBackground { get; set; }
        public string? SecondBackground { get; set; }

        public void SelectedTheme()
        {
            int tempString = DateTime.Now.ToString().Remove(0, 11).Remove(4).LastIndexOf(':');
            if (Convert.ToInt32(DateTime.Now.ToString().Remove(0, 11).Substring(0, tempString)) > 7 &&
                Convert.ToInt32(DateTime.Now.ToString().Remove(0, 11).Substring(0, tempString)) < 19)
            {
                FirstBackground = "#436CDB";
                SecondBackground = "#6B90EC";
            }
            else {
                FirstBackground = "#010F37";
                SecondBackground = "#2A3957";
            }
        }
    }
}