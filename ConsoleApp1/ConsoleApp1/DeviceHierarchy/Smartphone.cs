namespace ConsoleApp1;

public class Smartphone : MobileDevice, IChargeable
{
    private static readonly string DefaultOS;
    private int _batteryLevel;
    public int BatteryLevel => _batteryLevel;

    static Smartphone()
    {
        DefaultOS = "Android";
        Console.WriteLine($"\n[STATIC CONSTRUCTOR] Ініціалізація статичних полів для Smartphone. ОС за замовчуванням: {DefaultOS} ***");
    }

    private Smartphone(string name, int ram, double batteryLife) : base(name, ram, batteryLife)
    {
        Console.WriteLine($"[Smartphone] Викликано ПРИВАТНИЙ конструктор для '{name}'.");
        this._batteryLevel = 80;
    }

    public static Smartphone CreateFlagshipModel(string name, int ram)
    {
        Console.WriteLine("Створення флагманської моделі через фабричний метод.");
        return new Smartphone(name, ram, 20.0);
    }

    public override void RunApplication(string appName)
    {
        Console.WriteLine($"Смартфон '{name}' запускає мобільний додаток '{appName}'.");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Console.WriteLine($"[Dispose] Специфічне очищення для Smartphone '{name}'.");
        }
        base.Dispose(disposing);
    }

    public void StartCharge()
    {
        Console.WriteLine($"Зарядка смартфону {name} розпочата. Поточний рівень: {_batteryLevel}%");
        _batteryLevel = 100; 
        Console.WriteLine($"Смартфон {name} повністю заряджено.");
    }
}