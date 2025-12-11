using System.Text;
using ConsoleApp1;

class Program
{
    // static void ShowDeviceMessage(string message)
    // {
    //     Console.WriteLine($"[ОБРОБНИК ПОДІЇ]: {message}");
    // }
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("=============== ДЕМОНСТРАЦІЯ КОНСТРУКТОРІВ ТА ІЄРАРХІЇ ===============");
        Smartphone pixel = Smartphone.CreateFlagshipModel("Google Pixel 7 Pro", 8);
        
        Console.WriteLine("\nЛанцюжок виклику конструкторів:");
        DesktopComputer myPC = new DesktopComputer("Custom Gaming PC", 32, "Mid-Tower");
        myPC.RunDiagnostics();
        ISelfRepair selfRepair = (ISelfRepair)myPC;
        selfRepair.RunDiagnostics();
        // myPC.OnStatusChanged += ShowDeviceMessage;
        // myPC.OnStatusChanged += delegate(string message)
        // {
        //     Console.WriteLine($"[АНОНІМНИЙ ОБРОБНИК]: {message}");
        // };
        myPC.OnStatusChanged += message =>
        {
            Console.WriteLine($"[ЛЯМБДА-ОБРОБНИК]: {message}");
        };
        myPC.PowerOn();
        
        Console.WriteLine("\n=============== ДЕМОНСТРАЦІЯ FUNC ===============");
        Func<ComputingDevice, bool> isPowerfulCheck = device =>
        {
            return device.Ram > 16;
        };
        bool pcIsPowerful = isPowerfulCheck(myPC);
        bool pixelIsPowerful = isPowerfulCheck(pixel);
        
        Console.WriteLine($"Чи є 'myPC' потужним? ({myPC.Ram} ГБ): {pcIsPowerful}");
        Console.WriteLine($"Чи є 'pixel' потужним? ({pixel.Ram} ГБ): {pixelIsPowerful}");

        Console.WriteLine("\n=============== ДЕМОНСТРАЦІЯ ПОЛІМОРФІЗМУ ===============");
        ComputingDevice[] devices = new ComputingDevice[]
        {
            pixel,
            myPC,
            new Laptop("MacBook Pro", 16, 18.5, true)
        };

        foreach (var device in devices)
        {
            device.PowerOn();
            device.RunApplication("Visual Studio Code");
            Console.WriteLine("---");
        }

        Console.WriteLine("\n=============== ДЕМОНСТРАЦІЯ УПРАВЛІННЯ ПАМ'ЯТТЮ (IDisposable) ===============");
        using (var tempLaptop = new Laptop("Temp Laptop", 8, 10, false))
        {
            tempLaptop.RunApplication("Notepad");
        } 

        Console.WriteLine("\n=============== ДЕМОНСТРАЦІЯ РОБОТИ ЗБИРАЧА СМІТТЯ (GC) ===============");
        DemonstrateGC();
        
        DeviceGarage myGarage = new DeviceGarage();
        myGarage.AddDevice(myPC); 
        myGarage.AddDevice(pixel);
        
        Console.WriteLine("\n=============== ДЕМОНСТРАЦІЯ ІНДЕКСАТОРА ===============");
        
        ComputingDevice foundDevice = myGarage["Google Pixel 7 Pro"];

        if (foundDevice != null)
        {
            Console.WriteLine($"Знайдено пристрій за ім'ям: {foundDevice.Name}, у нього {foundDevice.Ram} ГБ ОЗП.");
        }
        else
        {
            Console.WriteLine("Пристрій з таким ім'ям не знайдено.");
        }
        
        ComputingDevice foundPC = myGarage["Custom Gaming PC"];
        if (foundPC != null)
        {
            Console.WriteLine($"Знайдено пристрій за ім'ям: {foundPC.Name}, у нього {foundPC.Ram} ГБ ОЗП.");
        }
        
        Console.WriteLine("\n=============== ДЕМОНСТРАЦІЯ FOREACH (IEnumerable) ===============");
        
        foreach (ComputingDevice device in myGarage)
        {
            Console.WriteLine($"Пристрій у гаражі: {device.Name} ({device.Ram} ГБ)");
        }
        
        myGarage.SortDevicesByRam();
        
        Console.WriteLine("\n=============== ВІДСОРТОВАНИЙ СПИСОК (IComparable) ===============");
        foreach (ComputingDevice device in myGarage)
        {
            Console.WriteLine($"Пристрій у гаражі: {device.Name} ({device.Ram} ГБ)");
        }

        Console.WriteLine("\n=============== ДЕМОНСТРАЦІЯ МЕТОДУ-РОЗШИРЕННЯ ===============");
        
        Console.WriteLine($"Чи є 'myPC' портативним?: {myPC.IsPortable()}"); // Має бути False
        Console.WriteLine($"Чи є 'pixel' портативним?: {pixel.IsPortable()}");
    }

    static void DemonstrateGC()
    {
        Console.WriteLine("Початковий об'єм пам'яті: " + GC.GetTotalMemory(false) + " байт");
        
        DesktopComputer forgottenPC = new DesktopComputer("Old Office PC", 4, "Small Form Factor");
        Console.WriteLine($"Об'єкт '{forgottenPC.Name}' створено. Покоління: {GC.GetGeneration(forgottenPC)}");
        Console.WriteLine("Пам'ять після створення об'єкта: " + GC.GetTotalMemory(false) + " байт");
        
        forgottenPC = null;

        Console.WriteLine("\nВикликаємо примусове збирання сміття...");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("Пам'ять після збирання сміття: " + GC.GetTotalMemory(true) + " байт\n");
    }
}