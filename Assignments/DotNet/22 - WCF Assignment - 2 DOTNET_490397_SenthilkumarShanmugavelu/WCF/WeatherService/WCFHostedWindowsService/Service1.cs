using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WCFHostedWindowsService
{
    public partial class Service1 : ServiceBase
    {
        ServiceHost obj;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            string strAdrHTTP = "http://localhost:50833/WeatherService.svc";
            obj = new ServiceHost(typeof(WeatherService.WeatherService));
            BasicHttpBinding httpb = new BasicHttpBinding();
            obj.AddServiceEndpoint(typeof(WeatherService.IWeatherService), httpb, strAdrHTTP);
            //obj.AddServiceEndpoint(typeof(IMetadataExchange),
            //MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            obj.Open();
        }

        protected override void OnStop()
        {
            obj.Close();
        }
    }
}
