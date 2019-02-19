using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {
        OrganizationEntities context = new OrganizationEntities();

        public string AddEmployee(EmployeeDetail employee)
        {
            var employeesList = context.EmployeeDetails.ToList();
            if (employeesList != null && employeesList.Count!=0)
            {
                employee.Id = employeesList[employeesList.Count - 1].Id + 1;
            }
            else
            {
                employee.Id = 1;
            }
            context.EmployeeDetails.Add(employee);
            context.SaveChanges();
  
            return "success";
        }

        public List<EmployeeDetail> DeleteEmployee(int id)
        {
            var employee = context.EmployeeDetails.Find(id);
            if (employee != null) {
                context.EmployeeDetails.Remove(employee);
                context.SaveChanges();
            }
            
            var employeesList = context.EmployeeDetails.ToList();
            return employeesList;
        }

        public EmployeeDetail RetreiveEmployeeByID(int id)
        {
            var employee = context.EmployeeDetails.Find(id);
            var result = new EmployeeDetail();
            if (employee != null) {
                result.Id = employee.Id;
                result.Name = employee.Name;
                result.Designation = employee.Designation;
            }
            return result;
        }

        public List<EmployeeDetail> RetreiveEmployees()
        {
            var employeesList = context.EmployeeDetails.ToList();
            return employeesList;
        }

        public List<EmployeeDetail> UpdateEmployee(EmployeeDetail employee)
        {
            var worker = context.EmployeeDetails.Find(employee.Id);
            if (worker != null)
            {
                worker.Name = employee.Name;
                worker.Designation = employee.Designation;
                context.SaveChanges();
            }
            var employeesList = context.EmployeeDetails.ToList();
            return employeesList;
        }
    }
}
