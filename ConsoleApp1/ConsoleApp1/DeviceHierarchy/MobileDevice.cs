namespace ConsoleApp1;

public abstract class MobileDevice : ComputingDevice
{
    protected double batterylife;
    public MobileDevice(string name, int ram, double batterylife) : base(name, ram)
    {
        this.batterylife = batterylife;
        Console.WriteLine(($"[MobileDevice] Викликано конструктор для '{name}'."));
    }

    public override void PowerOn()
    {
        base.PowerOn();
        Console.WriteLine($"    Час роботи від батареї: {this.batterylife} годин.");
    }
}