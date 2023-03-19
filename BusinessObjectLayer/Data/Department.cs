using System;
using System.Collections.Generic;

namespace BusinessObjectLayer.Data
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
            Jobs = new HashSet<Job>();
        }

        public Guid DepartmentId { get; set; }
        public string? DepName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
