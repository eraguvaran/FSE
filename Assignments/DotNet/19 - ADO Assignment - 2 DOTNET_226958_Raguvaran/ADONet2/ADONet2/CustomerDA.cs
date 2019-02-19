using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONet2
{
    public class CustomerDA
    {
        readonly SqlConnection conn;
        SqlCommand cmd;
        string strConn = "Data Source=DOTNET;Initial Catalog=FullStack;Integrated Security=True";
        public CustomerDA()
        {
            conn = new SqlConnection(strConn);
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
        }
        public int CreateCustomerTBL()
        {
            cmd.CommandText = "create_customertbl";
            int result;
            using (conn)
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public int InsertCustomerTBL(int CustId, string CustName, string CustAddress, string Dob, string Salary)
        {
            cmd.CommandText = "insert_customer";
            cmd.Parameters.Add(new SqlParameter("@CustId", CustId));
            cmd.Parameters.Add(new SqlParameter("@CustName", CustName));
            cmd.Parameters.Add(new SqlParameter("@CustAddress", CustAddress));
            cmd.Parameters.Add(new SqlParameter("@Dob", Dob));
            cmd.Parameters.Add(new SqlParameter("@Salary", Salary));
            int result;
            using (conn)
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }
        public List<Customer> GetAllCustomer()
        {
            var customers = new List<Customer>();
            cmd.CommandText = "fsd_getallcustomers";
            using (conn)
            {
                conn.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    customers.Add(new Customer
                    {
                       
                        CustId = (int)rdr["CustId"],
                        CustName = (string)rdr["CustName"],
                        CustAddress = (string)rdr["CustAddress"],
                        Dob= (string)rdr["Dob"],
                        Salary = (String)rdr["Salary"]
                        
                    });
                }
            }
            return customers;
        }
        public Customer SearchCustomer(string custId)
        {
            var cust = new Customer();
            cmd.CommandText = "fsd_searchcustomer";
            cmd.Parameters.Add(new SqlParameter("@custId", custId));
            using (conn)
            {
                conn.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cust.CustId = (int)rdr["CustId"];
                    cust.CustAddress = (string)rdr["CustAddress"];
                    cust.CustName = (string)rdr["CustName"];
                    cust.Dob = (string)rdr["Dob"];
                    cust.Salary = (string)rdr["Salary"];
                }
            }
            return cust;
        }

        public List<Customer> SearchCustomerByDate(DateTime dob   )
        {
            var lstcust = new List<Customer>();
            cmd.CommandText = "fsd-getcustomerbydate";
            cmd.Parameters.Add(new SqlParameter("@dob", dob));
            using (conn)
            {
                conn.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lstcust.Add(new Customer {
                        CustId = (int)rdr["CustId"],
                        CustAddress = (string)rdr["CustAddress"],
                        CustName = (string)rdr["CustName"],
                        Dob = (string)rdr["Dob"],
                        Salary = (string)rdr["Salary"]
                    });
                }
            }
            return lstcust;
        }
        public int DeleteCustomer(string custId)
        {
            int result;
            cmd.CommandText = "fsd_deletecustomer";
            cmd.Parameters.Add(new SqlParameter("@custId", custId));
            using (conn)
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }
    }
}
