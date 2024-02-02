namespace Homework_1.SMS;

using Homework_1.INotifyer;

public class SMSLowBalanceNotifyer : INotifyer {

    private string _phone;
    private int _lowBalanceValue;

    public SMSLowBalanceNotifyer(string phone, int lowBalanceValue) {}
    public void Notify(int balance) {}
}