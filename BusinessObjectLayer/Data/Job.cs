using System;
using System.Collections.Generic;

namespace BusinessObjectLayer.Data
{
    public partial class Job
    {
        public Job()
        {
            Employees = new HashSet<Employee>();
        }

        public Guid JobId { get; set; }
        public string? Jobname { get; set; }
        public Guid? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
