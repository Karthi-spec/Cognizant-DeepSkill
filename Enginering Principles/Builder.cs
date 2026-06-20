using System;

class Computer
{
    public string Cpu;
    public int Ram;
    public int Storage;
}

class ComputerBuilder
{
    private Computer computer = new Computer();

    public ComputerBuilder SetCpu(string cpu){ computer.Cpu = cpu; return this; }
    public ComputerBuilder SetRam(int ram){ computer.Ram = ram; return this; }
    public ComputerBuilder SetStorage(int storage){ computer.Storage = storage; return this; }

    public Computer Build(){ return computer; }
}