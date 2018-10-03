using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleEntityFramework;
using APIModels;
using APIInfrastructure;

namespace APISampleProject.Controllers
{
    [BasicAuthentication]
    public class EmployeeController : ApiController
    {
        //IList<Employee> employees = new List<Employee> 
        //{
        //     new Employee()
        //        {
        //            EmployeeId = 1, EmployeeName = "Mukesh Kumar", EmployeeAddress = "New Delhi", Department = "IT"
        //        },
        //        new Employee()
        //        {
        //            EmployeeId = 2, EmployeeName = "Banky Chamber", EmployeeAddress = "London", Department = "HR"
        //        },
        //        new Employee()
        //        {
        //            EmployeeId = 3, EmployeeName = "Rahul Rathor", EmployeeAddress = "Laxmi Nagar", Department = "IT"
        //        },
        //        new Employee()
        //        {
        //            EmployeeId = 4, EmployeeName = "YaduVeer Singh", EmployeeAddress = "Goa", Department = "Sales"
        //        },
        //        new Employee()
        //        {
        //            EmployeeId = 5, EmployeeName = "Manish Sharma", EmployeeAddress = "New Delhi", Department = "HR"
        //        }
        //};

        // EmployeeEntities employeeRepo = new EmployeeEntities();
        private readonly IGettingEmployees _getEmployees;
        public EmployeeController(IGettingEmployees getEmployees)
        {
            _getEmployees = getEmployees;
        }


        public IList<EmployeeDTOcs> GetEmployees()
        {
            var employee = _getEmployees.GetAllEmployees();

            return employee.ToList();
        }


        public EmployeeDTOcs GetEmployeeById(int Id)
        {
            var employee = _getEmployees.GetEmployeeById(Id);

            return employee;
        }
        [HttpPut]
        public EmployeeDTOcs UpdateEmployee(Employee emp)
        {
            var employee = _getEmployees.UpdateEmployee(emp);

            return employee;
        }
        //public EmployeeDTOcs GetEmployeeById(int Id)
        //{
        //    //var employee = from e in employeeRepo.EmployeeInfoes
        //    //                join ed in employeeRepo.EmplyoeeDepartments on e.EmpId equals ed.EmpId
        //    //                join d in employeeRepo.DepartmentMasters on ed.DeptId equals d.DepartmentId
        //    //                where e.EmpId == Id
        //    //               select new EmployeeDTOcs()
        //    //               {
        //    //                   EmployeeId = e.EmpId,
        //    //                   EmployeeName = e.EmpFullName,
        //    //                   EmployeeAddress = e.EmpAddress,
        //    //                   // Department =  e.DepartmentMasters.Where(i => i.EmployeeInfoes.Any(j => j.EmpId == e.EmpId)).FirstOrDefault().DepartmentName
        //    //                   Department = d.DepartmentName,
        //    //                   Departments = new DepartmentDTO()
        //    //                   {
        //    //                       Departmentid = d.DepartmentId,
        //    //                       DepartmentName = d.DepartmentName
        //    //                   }
        //    //               };

        //    //var selectedEmployee = employee.FirstOrDefault();
        //    //return selectedEmployee;

        //    //return employeeRepo.EmployeeInfoes.FirstOrDefault(x => x.EmpId == Id);
        //}

        //public IList<DepartmentDTO> GetAllDepartments()
        //{
        //    var dept = (from d in employeeRepo.DepartmentMasters
        //               select new DepartmentDTO()
        //               {
        //                   Departmentid = d.DepartmentId,
        //                   DepartmentName = d.DepartmentName
        //               }).ToList();

        //    return dept;
        //}
    }
}
