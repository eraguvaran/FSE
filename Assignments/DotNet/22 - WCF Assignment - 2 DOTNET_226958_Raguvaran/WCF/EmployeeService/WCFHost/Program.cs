using System;
using System.ServiceModel;


namespace WCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(EmployeeService.EmployeeService))) {
                host.Open();
                Console.WriteLine("Connection opened");
                Console.ReadLine();

            }
        }
    }
}
