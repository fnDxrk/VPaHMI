namespace Homework_1.SMS;

using Homework_1.INotifyer;

public class SMSLowBalanceNotifyer : INotifyer {

    private string _phone;
    private decimal _lowBalanceValue;

    public SMSLowBalanceNotifyer(string phone, decimal lowBalanceValue) {
        _phone = phone;
        _lowBalanceValue = lowBalanceValue;
    }
    public void Notify(decimal balance) {
        Console.WriteLine($"Number : {_phone}");
        Console.WriteLine("SMSLowBalanceNotifyer");

        if (balance < _lowBalanceValue) {
            Console.WriteLine(balance);
        }

        Console.WriteLine("\n");
    }
}