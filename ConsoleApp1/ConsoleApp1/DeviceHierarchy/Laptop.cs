namespace ConsoleApp1;

public class Laptop : MobileDevice, IChargeable
{
    private int _batteryLevel;
    public int BatteryLevel => _batteryLevel;
    
    public bool HasBacklitKeyboard {get; private set;}
    public Laptop(string name, int ram, double batteryLife, bool hasBacklitKeyboard) : base(name, ram,  batteryLife)
    {
        Console.WriteLine($"[Laptop] Викликано конструктор для '{name}'.");
        this._batteryLevel = 80;
    }
    public override void RunApplication(string appName)
    {
        Console.WriteLine($"Настільний ПК '{name}' запускає програму '{appName}'");
    }
    
    public void StartCharge()
    {
        Console.WriteLine($"Зарядка ноутбука {name} розпочата. Поточний рівень: {_batteryLevel}%");
        _batteryLevel = 100; 
        Console.WriteLine($"Ноутбук {name} повністю заряджено.");
    }
}