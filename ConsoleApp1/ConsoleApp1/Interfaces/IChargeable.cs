namespace ConsoleApp1;

public interface IChargeable
{
    int BatteryLevel { get; }
    void StartCharge();
}