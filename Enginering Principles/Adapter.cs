using System;

interface IPaymentProcessor
{
    void ProcessPayment(double amount);
}

class PayPalGateway
{
    public void MakePayment(double amount)
    {
        Console.WriteLine("Paid Rs." + amount);
    }
}

class PaymentAdapter : IPaymentProcessor
{
    private PayPalGateway gateway = new PayPalGateway();

    public void ProcessPayment(double amount)
    {
        gateway.MakePayment(amount);
    }
}