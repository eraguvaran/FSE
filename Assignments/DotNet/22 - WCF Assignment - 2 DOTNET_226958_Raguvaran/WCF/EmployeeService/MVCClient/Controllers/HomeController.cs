
using MVCClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCClient.Controllers
{
    public class HomeController : Controller
    {
        EmployeeServiceReference.EmployeeServiceClient ec = new EmployeeServiceReference.EmployeeServiceClient();
        EmployeeModel FindEmployeeResult;
        public ActionResult Index()
        {
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            foreach (var emp in ec.RetreiveEmployees()) {
                EmployeeModel employee = new EmployeeModel
                {
                    Id=emp.Id,
                    Name=emp.Name,
                    Designation=emp.Designation
                };
                employeeList.Add(employee);
            }

            return View(employeeList);
        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitEmployee(EmployeeModel employeedetail) {
            EmployeeServiceReference.EmployeeDetail serviceinput = new EmployeeServiceReference.EmployeeDetail {
                Name=employeedetail.Name,
                Designation=employeedetail.Designation
            };
            var result=ec.AddEmployee(serviceinput);
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            foreach (var emp in ec.RetreiveEmployees())
            {
                EmployeeModel employee = new EmployeeModel
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Designation = emp.Designation
                };
                employeeList.Add(employee);
            }
            return View("Index", employeeList);
        }

        public ActionResult DeleteEmployee( ) {
           
            return View();
        }

        public ActionResult SubmitDeleteEmployee(EmployeeModel employeedetail) {
            var  result = ec.DeleteEmployee(employeedetail.Id);
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            foreach (var emp in result)
            {
                EmployeeModel employee = new EmployeeModel
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Designation = emp.Designation
                };
                employeeList.Add(employee);
            }
            return View("Index", employeeList);
        }

        public ActionResult UpdateEmployee()
        {

            return View();
        }


        public ActionResult SubmitUpdateEmployee(EmployeeModel employeedetail)
        {
            EmployeeServiceReference.EmployeeDetail serviceinput = new EmployeeServiceReference.EmployeeDetail
            {
                Id = employeedetail.Id,
                Name = employeedetail.Name,
                Designation = employeedetail.Designation
            };
            var result = ec.UpdateEmployee(serviceinput);
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            foreach (var emp in result)
            {
                EmployeeModel employee = new EmployeeModel
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Designation = emp.Designation
                };
                employeeList.Add(employee);
            }
            return View("Index", employeeList);
        }

        public ActionResult FindEmployeeById() {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitFindEmployeeById(EmployeeModel employee)
        {
             var result = ec.RetreiveEmployeeByID(employee.Id);
             FindEmployeeResult = new EmployeeModel
            {
                Id = result.Id,
                Name = result.Name,
                Designation = result.Designation
            };
            return View("SubmitFindEmployeeById", FindEmployeeResult);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}