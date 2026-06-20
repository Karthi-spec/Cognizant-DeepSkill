using System;

interface IPaymentStrategy
{
    void Pay(int amount);
}

class CreditCardPayment : IPaymentStrategy
{
    public void Pay(int amount)
    {
        Console.WriteLine("Paid Rs." + amount + " using Credit Card");
    }
}

class PaymentContext
{
    private IPaymentStrategy strategy;

    public PaymentContext(IPaymentStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void MakePayment(int amount)
    {
        strategy.Pay(amount);
    }
}