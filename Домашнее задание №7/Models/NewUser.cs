using CommunityToolkit.Mvvm.ComponentModel;

namespace Домашнее_задание__7.Class
{
    public class NewUser: ObservableRecipient
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
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
}
}
