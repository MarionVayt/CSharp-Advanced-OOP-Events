namespace ConsoleApp1;

public class DesktopComputer : StationaryDevice, IDiagnostic, ISelfRepair
{
    public string FormFactor {get; private set;}

    public DesktopComputer(string name, int ram, string formFactor) : base(name, ram)
    {
        this.FormFactor = formFactor;
        Console.WriteLine($"[DesktopComputer] Викликано конструктор для '{name}'.");
    }
    public override void RunApplication(string appName)
    {
        Console.WriteLine($"Настільний ПК '{name}' запускає програму '{appName}' на великому моніторі.");
    }

    public void RunDiagnostics()
    {
        Console.WriteLine("Запуск загальної діагностики...");
    }

    void ISelfRepair.RunDiagnostics()
    {
        Console.WriteLine("Запуск глибокого самовідновлення...");
    }
}