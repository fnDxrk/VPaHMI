using CommunityToolkit.Mvvm.ComponentModel;

namespace Домашнее_задание__7.Class
{
    public partial class User : ObservableObject
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private Address _address;
        public Address Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }

        private string _website;
        public string Website
        {
            get { return _website; }
            set { SetProperty(ref _website, value); }
        }

        private Company _company;
        public Company Company
        {
            get { return _company; }
            set { SetProperty(ref _company, value); }
        }
    }
}
