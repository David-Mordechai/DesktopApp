using System;

namespace EmployeeManager.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public DateTimeOffset EntryDate { get; set; }

        public int JobRoleId { get; set; }

        public bool IsCoffeeDrinker { get; set; }
    }
}
