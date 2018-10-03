using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIModels
{
    public class Employee
    {
        public int EmployeeId
        {
            get; set;
        }

        public string EmployeeName
        {
            get; set;
        }

        public string EmployeeAddress
        {
            get; set;
        }

        public string Department
        {
            get; set;
        }

        public int DepartmentId
        {
            get; set;
        }

    }
}