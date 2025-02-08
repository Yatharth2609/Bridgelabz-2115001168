using System;

public class Device
{
    public string DeviceId { get; set; }
    public string Status { get; set; }

    public Device(string deviceId, string status)
    {
        DeviceId = deviceId;
        Status = status;
    }

    public virtual void DisplayStatus()
    {
        Console.WriteLine($"Device ID: {DeviceId}, Status: {Status}");
    }
}

public class Thermostat : Device
{
    public double TemperatureSetting { get; set; }

    public Thermostat(string deviceId, string status, double temperatureSetting) : base(deviceId, status)
    {
        TemperatureSetting = temperatureSetting;
    }

    public override void DisplayStatus()
    {
        base.DisplayStatus();
        Console.WriteLine($"Temperature Setting: {TemperatureSetting}°C");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Device thermostat = new Thermostat("TH123", "On", 22.5);
        thermostat.DisplayStatus();
    }
}