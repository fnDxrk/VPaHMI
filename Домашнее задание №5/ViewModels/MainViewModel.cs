using System.Collections.ObjectModel;
using System.IO;
using Домашнее_задание__5.Class;

namespace Домашнее_задание__5.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<IExplorer> _items = new ObservableCollection<IExplorer>();

        public ObservableCollection<IExplorer> Items => _items;

        private string _currentPath;

        public MainViewModel()
        {
            _currentPath = Directory.GetCurrentDirectory();
            LoadItems();
        }

        public void LoadItems()
        {
            _items.Clear();

            string parentDirectory = Path.GetDirectoryName(_currentPath);
            if (parentDirectory != null)
            {
                _items.Add(new Class.Directoryies(parentDirectory, ".."));
            }
            else
            {
                _items.Add(new Class.Directoryies("Drives", ".."));
            }

            foreach (var directoryPath in Directory.GetDirectories(_currentPath))
            {
                string name = Path.GetFileName(directoryPath);
                _items.Add(new Class.Directoryies(directoryPath, name));
            }

            foreach (var filePath in Directory.GetFiles(_currentPath))
            {
                string name = Path.GetFileName(filePath);
                _items.Add(new Class.File(filePath, name));
            }
        }

        public void LoadDrives()
        {
            _items.Clear();

            foreach (var driveInfo in DriveInfo.GetDrives())
            {
                _items.Add(new Class.Drive(driveInfo.RootDirectory.FullName, driveInfo.Name));
            }
        }

        public void HandleItemClick(IExplorer item)
        {
            _currentPath = item.Path;
            if (item.Path == "Drives")
            {
                LoadDrives();
            }
            else
            {
                LoadItems();
            }
        }
    }
}
