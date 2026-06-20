using System;

class Logger
{
    private static Logger instance;

    private Logger() { }

    public static Logger GetLogger()
    {
        if (instance == null)
            instance = new Logger();

        return instance;
    }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

class Program
{
    static void Main()
    {
        Logger a = Logger.GetLogger();
        Logger b = Logger.GetLogger();

        a.Log("Application Started");
        Console.WriteLine(a == b ? "Only one object created" : "Multiple objects created");
    }
}