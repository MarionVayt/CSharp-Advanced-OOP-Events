namespace ConsoleApp1;

public static class DeviceExtensions
{
    public static bool IsPortable(this ComputingDevice device)
    {
        return device is MobileDevice;
    }
}