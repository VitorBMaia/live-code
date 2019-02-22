using System;
using Case.Allocations.Api.Models;
using FluentAssertions;
using Xunit;

namespace Case.Allocations.Test
{
    public class AllocationTests    
    {
        private Allocation _allocation;

        public AllocationTests()
        {
            this._allocation = new Allocation();
        }

        [Fact(DisplayName = "Deve gerar o id da alocação quando criar uma nova alocação")]
        public void ShouldCreateTheAllocationIdWhenCreateANewAllocation()
        {
            this._allocation = new Allocation();

            this._allocation.Id.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "Deve calcular o período da alocação")]
        public void ShoulCalculateTheAllocationPeriod()
        {
            const int EXPECTED_PERIOD = 10;

            this._allocation.StartDate = new DateTime(2019, 03, 01);
            this._allocation.EndDate = this._allocation.StartDate.AddDays(EXPECTED_PERIOD);

            this._allocation.Period.Should().Be(EXPECTED_PERIOD);
        }

        [Theory(DisplayName = "Deve retornar o custo da alocação")]
        [InlineData(5600, 8, 10, 70)]
        public void ShouldReturnTheAllocationCost(decimal expected, int dailyWorkload, int allocationPeriod, decimal workHourlyCost)
        {
            var employee = new Employee {
                WorkHourlyCost = 70
        };
            this._allocation.Employee = employee;
            this._allocation.DailyWorkLoad = 8;
            this._allocation.StartDate = new DateTime(2019, 03, 01);
            this._allocation.EndDate = this._allocation.StartDate.AddDays(10);

            var allocationCost = this._allocation.CalculateAllocationCost();

            allocationCost.Should().Be(expected);
        }
    }

    
}
