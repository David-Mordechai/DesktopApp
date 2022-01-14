using System.Collections.Generic;
using EmployeeManager.Core.DataProvider;
using EmployeeManager.Core.Entities;

namespace EmployeeManager.Persistence
{
    public class JobRoleDataProvider : IJobRoleDataProvider
    {
        public IEnumerable<JobRole> LoadJobRoles()
        {
            return new List<JobRole>
            {
                new() { Id = 1, RoleName = "Software developer" },
                new() { Id = 2, RoleName = "Administrator" },
                new() { Id = 3, RoleName = "Marketing specialist" },
                new() { Id = 4, RoleName = "CEO" },
            };
        }
    }
}
