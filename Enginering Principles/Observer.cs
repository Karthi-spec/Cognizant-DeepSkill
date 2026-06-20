using System;
using System.Collections.Generic;

interface IObserver
{
    void Update(double price);
}

class MobileApp : IObserver
{
    public void Update(double price)
    {
        Console.WriteLine("Price Updated: " + price);
    }
}