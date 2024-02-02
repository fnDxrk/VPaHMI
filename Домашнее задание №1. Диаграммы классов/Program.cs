using Homework_1.Account;
using Homework_1.EMail;
using Homework_1.SMS;

// Accounts
Account person1 = new Account(1400);

// SMS
SMSLowBalanceNotifyer sms1 = new SMSLowBalanceNotifyer("+77777777777", 300);
SMSLowBalanceNotifyer sms2 = new SMSLowBalanceNotifyer("+7800553535", 700);
SMSLowBalanceNotifyer sms3 = new SMSLowBalanceNotifyer("+73136663242", 1000);

// EMail
EMailBalanceChangedNotifyer email1 = new EMailBalanceChangedNotifyer("pochta.noname@gmail.com");

person1.AddNotify(sms1);
person1.AddNotify(email1);
person1.ChangeBalance(299);
person1.ChangeBalance(4000);
