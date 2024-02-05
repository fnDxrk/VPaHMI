namespace Homework_1.Account;

using Homework_1.INotifyer;

public class Account {
    private decimal _balance = 0;
    private List<INotifyer> _notifyers = new List<INotifyer>();

    public Account(){}

    public Account(decimal balance) {
        _balance = balance;
    }

    public void AddNotify(INotifyer notifyer) {
        _notifyers.Add(notifyer);
    }

    public void ChangeBalance(decimal value) {
        _balance = value;
        Notification();
    }

    public decimal Balance {
        get { return _balance;}
    }

    private void Notification() {
        foreach(INotifyer n in _notifyers) {
            n.Notify(Balance);
        }
    }
}