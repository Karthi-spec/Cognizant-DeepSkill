using System;

interface INotifier { void Send(); }

class EmailNotifier : INotifier
{
    public void Send() => Console.WriteLine("Email Sent");
}

class SmsNotifier : INotifier
{
    private INotifier notifier;

    public SmsNotifier(INotifier notifier)
    {
        this.notifier = notifier;
    }

    public void Send()
    {
        notifier.Send();
        Console.WriteLine("SMS Sent");
    }
}