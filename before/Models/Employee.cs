using System;

namespace RegularService.Models
{
    public class Employee : People
    {
        public string Title { get; set; }
        public DateTime HireDate { get; set; }
    }
}