namespace Homework_1.Account;

using Homework_1.INotifyer;

public class Account {
    private int _balance = 0;
    private List<INotifyer> _notifyers = new List<INotifyer>();

    public Account(){}

    public Account(int balance) {
        _balance = balance;
    }

    public void AddNotify(INotifyer notifyer) {
        _notifyers.Add(notifyer);
    }

    public void ChangeBalance(int value) {
        _balance = value;
        Notification();
    }

    public int Balance {
        get { return _balance;}
    }

    private void Notification() {
        foreach(INotifyer n in _notifyers) {
            n.Notify(Balance);
        }
    }
}