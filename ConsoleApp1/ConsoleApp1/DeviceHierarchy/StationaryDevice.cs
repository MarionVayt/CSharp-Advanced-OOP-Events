namespace ConsoleApp1;

public abstract class StationaryDevice : ComputingDevice
{
    public StationaryDevice(string name, int ram) : base(name, ram)
    {
        Console.WriteLine($"[StationaryDevice] Викликано конструктор для '{name}'.");
    }
}