using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjectLayer.Data
{
    public partial class Evaluation
    {
        public int Id { get; set; }


     
        public string EmployeeId { get; set; } = null!;
        public string? Performance { get; set; }

        public virtual Employee? Employee { get; set; }
        public int socialv { get; set; }
        public int collaboration { get; set; }
        public int LeaderShip { get; set; }
    }
}
