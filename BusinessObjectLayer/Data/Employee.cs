using System;
using System.Collections.Generic;

namespace BusinessObjectLayer.Data
{
    public partial class Employee
    {
        public string EmployeeID { get; set; } = null!;
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? Dob { get; set; }
        public Guid JobId { get; set; }
        public Guid? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
        public virtual List<Evaluation> Evaluation { get; set; } = null!;
        public virtual Job Job { get; set; } = null!;
    }
}
