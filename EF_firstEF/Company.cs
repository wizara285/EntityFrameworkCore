using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_firstEF
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string Name { get; set; } = null!;

        public List<Employee> Employees { get; set; } = new();

        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
    }
}
