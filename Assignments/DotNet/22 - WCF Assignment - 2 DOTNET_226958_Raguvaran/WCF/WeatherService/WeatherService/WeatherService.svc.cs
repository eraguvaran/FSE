using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WeatherService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WeatherService.svc or WeatherService.svc.cs at the Solution Explorer and start debugging.
    public class WeatherService : IWeatherService
    {
        //C:\WCF\WeatherService\WCFHostedWindowsService\bin\Debug\WCFHostedWindowsService.exe
        public double celciustofarenheit(double temp)
        {
            return ((temp * (9.0 / 5.0)) + 32);
        }

       

        public double farenheittocelcius(double temp)
        {
          
            return ((temp - 32) * (5.0 / 9.0));
        }

        public string getmessage()
        {
            return "HI";
        }
    }
}
