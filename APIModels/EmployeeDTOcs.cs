using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIModels
{
    public class EmployeeDTOcs
    {
        public long EmployeeId
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

        public IList<DepartmentDTO> Departments
        {
            get; set;
        }
    }
}