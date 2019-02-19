using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONet2
{
    class Program
    {
        static void Main(string[] args)
        {
            var serchstr = "1";
            var custDA = new CustomerDA();
            var fetchedCust = custDA.SearchCustomer(serchstr);
        }
        static void FetchCustomerByDob(string dob)
        {
            var custDA = new CustomerDA();
            var fetchedCust = custDA.SearchCustomerByDate(Convert.ToDateTime(dob));
        }
    }
}
