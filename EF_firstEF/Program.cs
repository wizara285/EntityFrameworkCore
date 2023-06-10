
using EF_firstEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

public class Program
{
    public static void Main(string[] args)
    {
        using (ApplicationContext context = new ApplicationContext())
        {
            Position manager = new Position { Name = "Manager" };
            Position developer = new Position { Name = "Developer" };
            context.Positions.AddRange(manager, developer);

            City washington = new City { Name = "Washington" };
            context.Cities.Add(washington);

            Country usa = new Country { Name = "USA", Capital = washington };
            context.Countries.Add(usa);

            Company microsoft = new Company { Name = "Microsoft", Country = usa };
            Company google = new Company { Name = "Google", Country = usa };
            context.Companies.AddRange(microsoft, google);

            Employee tom = new Employee { Name = "Tom", Company = microsoft, Position = manager };
            Employee bob = new Employee { Name = "Bob", Company = google, Position = developer };
            Employee alice = new Employee { Name = "Alice", Company = microsoft, Position = developer };
            Employee kate = new Employee { Name = "Kate", Company = google, Position = manager };
            context.Employees.AddRange(tom, bob, alice, kate);

            context.SaveChanges();
        }

        using (ApplicationContext context = new ApplicationContext())
        {
            var employees = context.Employees.Include(p => p.Position).Include(c => c.Company).ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name} - {employee.Position.Name} from {employee.Company.Name}");
            }
        }

        //add
    }
}