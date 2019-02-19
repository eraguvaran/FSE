using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONet2
{
    public class CustomerDS
    {
        readonly SqlConnection conn;
        SqlCommand cmd;
        string strConn = "Data Source=DOTNET;Initial Catalog=FullStack;Integrated Security=True";
        public CustomerDS()
        {
            conn = new SqlConnection(strConn);
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
        }
        public List<Customer> GetAllCustomer()
        {
            var customers = new List<Customer>();
            cmd.CommandText = "fsd_getallcustomers";
            var daptr = new SqlDataAdapter();
            daptr.SelectCommand = cmd;
            conn.Open();
            var ds = new DataSet();
            daptr.Fill(ds);
            conn.Close();
            foreach (DataRow rdr in ds.Tables[0].Rows)
            {
                customers.Add(new Customer
                {

                    CustId = (int)rdr["CustId"],
                    CustName = (string)rdr["CustName"],
                    CustAddress = (string)rdr["CustAddress"],
                    Dob = (string)rdr["Dob"],
                    Salary = (String)rdr["Salary"]

                });
            }
            return customers;
        }
        public void UpdateCustomer(int CustId, string CustName, string CustAddress, string Dob, string Salary)
        {
            var tempds = new DataSet();
            cmd.CommandText = "fsd_getcustomer";
            cmd.Parameters.Add(new SqlParameter("@custId", CustId));
            var daptr = new SqlDataAdapter();
            daptr.SelectCommand = cmd;
                conn.Open();
            daptr.Fill(tempds);
            
            var sqlbulder = new SqlCommandBuilder(daptr);
            foreach (DataRow rdr in tempds.Tables[0].Rows)
            {
                rdr["CustId"] = CustId;
                rdr["CustName"] = CustName;
                rdr["CustAddress"] = CustAddress;
                rdr["Dob"] = Dob;
                rdr["Salary"] = Salary;
                tempds.Tables[0].ImportRow(rdr);
                tempds.Tables[0].AcceptChanges();
            }

           daptr.Update(tempds);
            conn.Close();
        }
        public void InsertCustomer(int CustId, string CustName, string CustAddress, string Dob, string Salary)
        {
            var ds = new DataSet();
            cmd.CommandText = "fsd_getcustomers";
            
            var daptr = new SqlDataAdapter();
             daptr.SelectCommand = cmd;
            conn.Open();
            daptr.Fill(ds);
            var newRow = ds.Tables[0].NewRow();
            newRow["CustId"] = CustId;
            newRow["CustName"] = CustName;
            newRow["CustAddress"] = CustAddress;
            newRow["Dob"] = Dob;
            newRow["Salary"] = Salary;
            ds.Tables[0].Rows.Add(newRow);
            ds.Tables[0].AcceptChanges();
            daptr.Update(ds);
            conn.Close();
        }
        public void DeleteCustomer(int CustId)
        {
            var ds = new DataSet();
            cmd.CommandText = "fsd_getcustomers";

            var daptr = new SqlDataAdapter();
            daptr.SelectCommand = cmd;
            conn.Open();
            daptr.Fill(ds);
            var delRow = ds.Tables[0].NewRow();
            foreach (DataRow rdr in ds.Tables[0].Rows)
            {
                if ((int)rdr["CustId"] == CustId)
                {
                    ds.Tables[0].Rows.Remove(rdr);
                    daptr.Update(ds);
                    break;
                }
            }

        }
    }
}
