using System;

namespace Test
{
    public class WeatherStation
    {
        public delegate void MyDelHandler(string msg);

        public event MyDelHandler OnTemperatureAlertEvent;

        public void CheckTemperature(double temperature)
        {
            System.Console.WriteLine($"current temperature {temperature}");
            if (temperature > 30)
            {
                OnTemperatureAlertEvent?.Invoke("Temperature too high");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WeatherStation station = new WeatherStation();
            station.OnTemperatureAlertEvent += new WeatherStation.MyDelHandler(Display);
            station.OnTemperatureAlertEvent += CoolingDevice;

            station.CheckTemperature(45.0);
        }
        static void Display(string msg)
        {
            System.Console.WriteLine($"Displaying : {msg}");
        }
        static void CoolingDevice(string msg)
        {
            System.Console.WriteLine($"Cooling device showing : {msg}");
        }
    }
}