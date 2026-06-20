using System;

interface ICommand
{
    void Execute();
}

class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light Turned On");
    }
}

class LightOnCommand : ICommand
{
    private Light light;

    public LightOnCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOn();
    }
}