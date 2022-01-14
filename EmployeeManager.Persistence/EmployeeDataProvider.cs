using System;
using System.Collections.Generic;
using System.Diagnostics;
using EmployeeManager.Core.DataProvider;
using EmployeeManager.Core.Entities;

namespace EmployeeManager.Persistence
{
    public class EmployeeDataProvider : IEmployeeDataProvider
    {
        public IEnumerable<Employee> LoadEmployees()
        {
            return new List<Employee>
            {
                new()
                {
                    Id = 1,
                    FirstName = "Julia",
                    EntryDate = new DateTime(2019, 10, 1),
                    IsCoffeeDrinker = true,
                    JobRoleId = 3
                },
                new()
                {
                    Id = 2,
                    FirstName = "Thomas",
                    EntryDate = new DateTime(2015, 9, 23),
                    IsCoffeeDrinker = true,
                    JobRoleId = 1
                },
                new()
                {
                    Id = 3,
                    FirstName = "Anna",
                    EntryDate = new DateTime(2020, 1, 1),
                    IsCoffeeDrinker = false,
                    JobRoleId = 2
                },
                new()
                {
                    Id = 4,
                    FirstName = "Sara",
                    EntryDate = new DateTime(2013, 5, 15),
                    IsCoffeeDrinker = false,
                    JobRoleId = 4
                },
                new()
                {
                    Id = 5,
                    FirstName = "Miguel",
                    EntryDate = new DateTime(2014, 11, 17),
                    IsCoffeeDrinker = true,
                    JobRoleId = 1
                }
            };
        }

        public void SaveEmployee(Employee employee)
        {
            Debug.WriteLine($"Employee saved: {employee.FirstName}");
        }
    }
}