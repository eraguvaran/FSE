using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCClient.Models
{
    public class EmployeeDetail
    {
        public int _Id;
        public string _Name;
        public string _Designation;

        public int Id
        {
            get{ return _Id; }
            set {_Id = value; }
        }
        public string Name {
            get { return _Name;}
            set { _Name = value;}
        }
        public string Designation {
            get {return _Designation;}
            set { _Designation = value;}
        }
    }
}