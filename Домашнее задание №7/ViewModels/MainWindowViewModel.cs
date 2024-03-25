using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Домашнее_задание__7.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using static Домашнее_задание__7.Class.ObservableFactory;

namespace Домашнее_задание__7.ViewModels;

public partial class MainWindowViewModel : ObservableRecipient
{

    public NewUser NewUserData { get; } = new NewUser();

    private Log _log;

    private ObservableCollection<User> _userData;
    public ObservableCollection<User> UserData
    {
        get { return _userData; }
        set { SetProperty(ref _userData, value); }
    }

    private bool _isGridReadOnly = true;
    public bool IsGridReadOnly
    {
        get { return _isGridReadOnly; }
        set { SetProperty(ref _isGridReadOnly, value); }
    }

    private User _selectedUser;
    public User SelectedUser
    {
        get { return _selectedUser; }
        set { SetProperty(ref _selectedUser, value); }
    }

    public ICommand ToggleReadOnlyCommand { get; }
    public ICommand AddUserCommand { get; }

    private UserService _userService;

    private IObservable<CollectionChangedEventArgs<User>> _userDataChanges;
    public MainWindowViewModel()
    {
        _userService = new UserService();
        ToggleReadOnlyCommand = new RelayCommand(ToggleReadOnly);
        AddUserCommand = new RelayCommand(ExecuteAddUser);

        UserData = new ObservableCollection<User>();
        _log = new Log("/home/dxrk_/Documents/Study/VPaHMI/Домашнее задание №7/Logs/");

        LoadUsers();

        _userDataChanges = ObservableFactory.CreateObservable(UserData);
        _userDataChanges.Subscribe(OnUserDataChanged);
    }


    private async Task LoadUsers()
    {
        List<User> users = await _userService.GetUsers();
        if (users != null)
        {
            foreach (var user in users)
            {
                UserData.Add(user);
            }
        }
    }

    private void OnUserDataChanged(CollectionChangedEventArgs<User> args)
    {
        _log.LogUserDataChanges(args);
    }

    private void ToggleReadOnly()
    {
        IsGridReadOnly = !IsGridReadOnly;
    }

    private void ExecuteAddUser()
    {
        AddUser(NewUserData.FirstName, NewUserData.Email, NewUserData.Username, NewUserData.Phone, NewUserData.Website);

        NewUserData.FirstName = string.Empty;
        NewUserData.Email = string.Empty;
        NewUserData.Username = string.Empty;
        NewUserData.Phone = string.Empty;
        NewUserData.Website = string.Empty;
    }



    public void RemoveUser(object? user)
    {
        if (user is User users)
        {
            UserData.Remove(users);
        }
    }

    public void AddUser(string firstName, string email, string username, string phone, string website)
    {
        User newUser = new User
        {
            Name = firstName,
            Email = email,
            Username = username,
            Phone = phone,
            Website = website
        };
        UserData.Add(newUser);
    }
}


