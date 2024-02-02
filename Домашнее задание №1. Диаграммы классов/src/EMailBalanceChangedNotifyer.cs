namespace Homework_1.EMail;

using Homework_1.INotifyer;

public class EMailBalanceChangedNotifyer : INotifyer{
    private string _email;

    public EMailBalanceChangedNotifyer(string email) {
        _email = email;
    }
    public void Notify(int balance) {
        Console.WriteLine($"Email : {_email}");
        Console.WriteLine("EMailBalanceChangedNotifyer");
        Console.WriteLine($"{balance}\n");
    }
}