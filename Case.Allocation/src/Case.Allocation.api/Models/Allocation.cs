using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case.Allocations.Api.Models
{
    public class Allocation
    {
        public Allocation()
        {
            this.Id = Guid.NewGuid();   
        }

        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Employee Employee { get; set; }
        public int DailyWorkLoad { get; set; }
        //usando expression body
        public int Period => this.CalculePeriod();
        
        private int CalculePeriod()
        {
            var period = this.EndDate - this.StartDate;
            return period.Days;
        }

        public decimal CalculateAllocationCost()
        {
            var allocationCost = this.Period * this.DailyWorkLoad * this.Employee.WorkHourlyCost;
            return allocationCost;
        }
    }
}
