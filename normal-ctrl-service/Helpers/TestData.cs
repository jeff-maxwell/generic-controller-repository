using System;
using RegularService.Models;
using RegularService.Services;

namespace RegularService.Helpers
{
    public class TestData
    {
        public static void SeedEmployees(DataContext context)
        {
            var emp1 = new Employee 
            {
                FirstName = "John",
                LastName = "Doe",
                Title = "The Boss",
                BirthDate = DateTime.Now.AddYears(-30),
                Address = "123 2nd Street",
                City = "New York",
                Region = "NY",
                PostalCode = "12345-1234",
                Country = "USA",
                Phone = "(405) 555-1212",
                HireDate = DateTime.Now.AddYears(-2)
            };
 
            context.Employees.Add(emp1);
 
            context.SaveChanges();
        }
    }
}