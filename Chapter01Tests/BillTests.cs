using Chapter01;
using System;
using System.Collections.Generic;
using System.Reflection;
using Shared.Models.Chapter01;
using Xunit;

namespace Chapter01Tests
{
    public class BillTests
    {
        public List<Play> Plays;
        public List<Invoice> Invoices;
        public BillTests()
        {

        }
        [Fact]
        public void Test1()
        {
            //Arrange

            //Act
            var bill = new Bill();
            bill.
            //Assert
        }

        public void SetData()
        {
            Plays = new List<Play>()
            {
                new Play()
                {

                }
            }
        }
    }
}
