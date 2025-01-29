using System;

public class Computer
{
    public string CPU { get; set; }
    public int RAM { get; set; }
    public int Storage { get; set; }
    public string Type { get; set; }  

}

public interface IComputerBuilder
{
    IComputerBuilder AddCPU(string cpu);
    IComputerBuilder AddRAM(int ram);
    IComputerBuilder AddStorage(int storage);
    Computer Build();
}

public class WindowsComputerBuilder : IComputerBuilder
{
    private Computer _computer = new Computer();

    public WindowsComputerBuilder()
    {
        _computer.Type = "Windows";
    }

    public IComputerBuilder AddCPU(string cpu)
    {
        _computer.CPU = cpu;
        return this;
    }

    public IComputerBuilder AddRAM(int ram)
    {
        _computer.RAM = ram;
        return this;
    }

    public IComputerBuilder AddStorage(int storage)
    {
        _computer.Storage = storage;
        return this;
    }

    public Computer Build()
    {
        return _computer;
    }
}

public class MacComputerBuilder : IComputerBuilder
{
    private Computer _computer = new Computer();

    public MacComputerBuilder()
    {
        _computer.Type = "Mac";
    }

    public IComputerBuilder AddCPU(string cpu)
    {
        _computer.CPU = cpu;
        return this;
    }

    public IComputerBuilder AddRAM(int ram)
    {
        _computer.RAM = ram;
        return this;
    }

    public IComputerBuilder AddStorage(int storage)
    {
        _computer.Storage = storage;
        return this;
    }

    public Computer Build()
    {
        return _computer;
    }
}

public class ComputerFactory
{
    public static IComputerBuilder GetComputerBuilder(string type)
    {
        if (type.Equals("Mac"))
        {
            return new MacComputerBuilder();
        }
        else if (type.Equals("Windows"))
        {
            return new WindowsComputerBuilder();
        }
        else
        {
            throw new ArgumentException("Unknown computer-type");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        IComputerBuilder builder = ComputerFactory.GetComputerBuilder("Mac");

        Computer myComputer = builder
            .AddCPU("Apple M1")
            .AddRAM(16)
            .AddStorage(512)
            .Build();

        Console.WriteLine(myComputer.ToString());
    }
}