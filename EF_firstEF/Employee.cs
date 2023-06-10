using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_firstEF
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;

        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        public int PositionId { get; set; }
        public Position Position { get; set; } = null!;
    }
}
