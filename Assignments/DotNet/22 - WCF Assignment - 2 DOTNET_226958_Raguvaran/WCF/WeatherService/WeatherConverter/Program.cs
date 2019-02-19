
using System;
using WeatherConverter.WCFHostedWindowsService;

namespace WeatherConverter
{
    class Program
    {
        static void Main(string[] args)
        {

            
            while (true)
            {

               WeatherServiceClient wc = new WeatherServiceClient();
                Console.WriteLine("Choose from the following opions");
                Console.WriteLine("1.celcius to farenheit");
                Console.WriteLine("2.farenheit to celcius");
                Console.WriteLine("3.Exit");
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    Console.Write("Please enter temperature in celcius:");
                    Console.WriteLine(wc.celciustofarenheit(Double.Parse(Console.ReadLine())));
                }
                else if (input == 2)
                {
                    Console.Write("Please enter temperature in farenheit:");
                    Console.WriteLine(wc.farenheittocelcius(Double.Parse(Console.ReadLine())));
                }
                else
                {
                    break;
                }
            }
        }
    }
}
