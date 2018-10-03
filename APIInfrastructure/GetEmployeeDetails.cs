using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleEntityFramework;
using APIModels;
using System.Data.Entity;

namespace APIInfrastructure
{
    public class GetEmployeeDetails : IGettingEmployees
    {
      
        EmployeeEntities employeeRepo = new EmployeeEntities();
        public IList<EmployeeDTOcs> GetAllEmployees()
        {
            try
            {
                var employee = (from e in employeeRepo.EmployeeInfoes
                                join ed in employeeRepo.EmplyoeeDepartments on e.EmpId equals ed.EmpId
                                join d in employeeRepo.DepartmentMasters on ed.DeptId equals d.DepartmentId
                                select new EmployeeDTOcs()
                                {
                                    EmployeeId = e.EmpId,
                                    EmployeeName = e.EmpFullName,
                                    EmployeeAddress = e.EmpAddress,
                                    // Department =  e.DepartmentMasters.Where(i => i.EmployeeInfoes.Any(j => j.EmpId == e.EmpId)).FirstOrDefault().DepartmentName
                                    Department = d.DepartmentName,
                                    DepartmentId = d.DepartmentId
                                }).ToList();

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public EmployeeDTOcs GetEmployeeById(long Id)
        {
            var employee = from e in employeeRepo.EmployeeInfoes
                           join ed in employeeRepo.EmplyoeeDepartments on e.EmpId equals ed.EmpId
                           join d in employeeRepo.DepartmentMasters on ed.DeptId equals d.DepartmentId
                           where e.EmpId == Id
                           select new EmployeeDTOcs()
                           {
                               EmployeeId = e.EmpId,
                               EmployeeName = e.EmpFullName,
                               EmployeeAddress = e.EmpAddress,
                               // Department =  e.DepartmentMasters.Where(i => i.EmployeeInfoes.Any(j => j.EmpId == e.EmpId)).FirstOrDefault().DepartmentName
                               Department = d.DepartmentName,
                               DepartmentId = d.DepartmentId
                           };


            var selectedEmployee = employee.FirstOrDefault();
            selectedEmployee.Departments = GetAllDepartments();
            return selectedEmployee;
        }

        public IList<DepartmentDTO> GetAllDepartments()
        {
            var dept = (from d in employeeRepo.DepartmentMasters
                        select new DepartmentDTO()
                        {
                            Departmentid = d.DepartmentId,
                            DepartmentName = d.DepartmentName
                        }).ToList();

            return dept;
        }

        public EmployeeDTOcs UpdateEmployee(Employee emp)
        {
            var updatedEmployee = employeeRepo.EmplyoeeDepartments.Find(emp.EmployeeId);
            if (updatedEmployee != null)
            {
                updatedEmployee.DeptId = emp.DepartmentId;
            }
            //employeeRepo.EmplyoeeDepartments.Add(updatedEmployee);
            //employeeRepo.Entry(updatedEmployee).State = EntityState.Modified;
            employeeRepo.SaveChanges();

            var updateex = GetEmployeeById(updatedEmployee.EmpId);
            

            return updateex;

        }

       
    }
}
