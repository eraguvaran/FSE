using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
namespace TwitterClone_MVC_WebAPI
{
    public class ErrLog
    {
        public static void WriteLog(Exception ex,string controller,string action)
        {
            string errorContent = @"Erorr " + ex.Message + Environment.NewLine +
                "Controller " + controller + Environment.NewLine +
                "Action " + action + Environment.NewLine +
                "Date " + DateTime.Now;
            string path = ConfigurationManager.AppSettings["ErrLogPath"].ToString();
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(errorContent);
            }
        }
    }
}