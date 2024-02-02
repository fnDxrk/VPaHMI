namespace Homework_1.EMail;

using Homework_1.INotifyer;

public class EMailBalanceChangedNotifyer : INotifyer{
    private string _email;

    public EMailBalanceChangedNotifyer(string email) {}
    public void Notify(int balance) {}
}