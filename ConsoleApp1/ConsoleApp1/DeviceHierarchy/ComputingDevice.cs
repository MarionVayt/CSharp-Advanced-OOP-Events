namespace ConsoleApp1;

// public delegate void DeviceStatusHandler(string message);

public abstract class ComputingDevice : IDisposable, IComparable
{
    protected string name;

    private int ram;
    
    public string Name => name;

    public int Ram
    {
        get {return ram;}
        set
        {
            if (value > 0)
            {
                ram = value;
            }
            else
            {
                ram = 4; 
                Console.WriteLine($"!! Некоректний об'єм ОЗП {value} ГБ. Встановлено {ram} ГБ.");
            }
        }
    }

    public ComputingDevice()
    {
        this.name = "Unknown Device";
        this.ram = 4;
        Console.WriteLine("[ComputingDevice] Викликано конструктор за замовчуванням.");
    }

    public ComputingDevice(string name, int year)
    {
        this.name = name;
        this.ram = year;
        Console.WriteLine($"[ComputingDevice] Викликано конструктор з параметрами для '{name}'.");
    }
    
    public event Action<string> OnStatusChanged;
    public virtual void PowerOn()
    {
        Console.WriteLine($"Пристрій '{Name}' ({Ram} ГБ ОЗП) вмикається.");
        
        OnStatusChanged?.Invoke($"Подія: Пристрій '{Name}' увімкнено.");
    }
    
    public abstract void RunApplication(string appname);
    
    private bool disposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Console.WriteLine($"[Dispose] Звільнення керованих ресурсів для {name}...");
            }
            Console.WriteLine($"[Dispose] Звільнення НЕкерованих ресурсів для {name}...");
            disposed = true;
        }
    }

    ~ComputingDevice()
    {
        Console.WriteLine($"~[DESTRUCTOR] Фіналізатор викликано для {name}!");
        Dispose(false);
    }

    public int CompareTo(object? obj)
    {
        if (obj is ComputingDevice otherDevice)
        {
            return this.Ram.CompareTo(otherDevice.Ram);
        }
        else
        {
            throw new ArgumentException("Об'єкт не є ComputingDevice");
        }
    }
}