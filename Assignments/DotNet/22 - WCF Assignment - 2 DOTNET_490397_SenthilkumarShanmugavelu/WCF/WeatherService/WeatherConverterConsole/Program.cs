using System;
namespace WeatherConverterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //http://localhost:50831/WeatherService.svc
            while (true)
            {
                Console.WriteLine("Choose from the following opions");
                Console.WriteLine("1.celcius to farenheit");
                Console.WriteLine("2.farenheit to celcius");
                Console.WriteLine("3.Exit");
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                }
                else if (input == 2)
                {
                }
                else
                {
                    break;
                }
            }
        }
    }
}