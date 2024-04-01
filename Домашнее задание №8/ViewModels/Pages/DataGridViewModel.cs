using Домашнее_задание__8.Class;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Домашнее_задание__8.ViewModels.Pages
{
    public class DataGridViewModel : BaseViewModel
    {
        private ObservableCollection<User> _dataGrid;
        public ObservableCollection<User> DataGrid
        {
            get { return _dataGrid; }
            set { SetProperty(ref _dataGrid, value); }
        }

        private UserService _userService;


        public DataGridViewModel()
        {
            _userService = new UserService();
            DataGrid = new ObservableCollection<User>();
            LoadUsers();
        }

        private async Task LoadUsers()
        {
            List<User> users = await _userService.GetUsers();
            if (users != null)
            {
                foreach (var user in users)
                {
                    DataGrid.Add(user);
                }
            }
        }
    }
}
