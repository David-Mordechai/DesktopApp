using System.Collections.Generic;
using EmployeeManager.Core.Entities;

namespace EmployeeManager.Core.DataProvider
{
    public interface IJobRoleDataProvider
    {
        IEnumerable<JobRole> LoadJobRoles();
    }
}
