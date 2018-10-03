using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIModels;
using SampleEntityFramework;

namespace APIInfrastructure
{
    public interface IGettingEmployees
    {
        IList<EmployeeDTOcs> GetAllEmployees();
        EmployeeDTOcs GetEmployeeById(long Id);
        EmployeeDTOcs UpdateEmployee(Employee emp);
    }
}
