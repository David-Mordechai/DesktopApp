using System.Collections.Generic;
using EmployeeManager.Core.Entities;

namespace EmployeeManager.Core.DataProvider
{
    public interface IEmployeeDataProvider
    {
        IEnumerable<Employee> LoadEmployees();

        void SaveEmployee(Employee employee);
    }
}
