using System;

namespace Case.Allocations.Api.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public int DailyWorkload { get; set; }
        public decimal WorkHourlyCost { get; set; }
    }
}