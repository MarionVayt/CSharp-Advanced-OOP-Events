using System.Collections;
namespace ConsoleApp1;

public class DeviceGarage : IEnumerable
{
    private List<ComputingDevice> devices = new List<ComputingDevice>();

    public void AddDevice(ComputingDevice device)
    {
        devices.Add(device);
        Console.WriteLine($"[Garage] Додано пристрій: {device.Name}");
    }

    public ComputingDevice this[string name]
    {
        get
        {
            return devices.FirstOrDefault(d => d.Name == name);
        }
    }

    public IEnumerator GetEnumerator()
    {
        return devices.GetEnumerator();
    }
    public void SortDevicesByRam()
    {
        devices.Sort();
        Console.WriteLine("\n[Garage] Пристрої відсортовано за ОЗП.");
    }
}