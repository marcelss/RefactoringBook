using Chapter01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Shared.Models.Chapter01;
using Xunit;

namespace Chapter01Tests
{
    public class Bill01Tests
    {
        public List<Play> Plays;
        public Invoice Invoice;

        [Fact]
        public void Bill01_New_Statement_ReturnsValidString()
        {
            //Arrange
            var expected = CleanText(@"Statement for BigCo
                                                Hamlet: $650.00 (55 seats)
                                                As You Like It: $580.00 (35 seats)
                                                Othello: $500.00(40 seats)
                                                Amount owed is $1,730.00
                                                You earned 47 credits");
            SetTestData();
            //Act
            var bill = new Bill01();
            var result = bill.Statement(Invoice, Plays);

            //Assert
            Assert.NotEmpty(result);
            
            Assert.Equal(expected, CleanText(result));
        }

        [Fact]
        public void Bill02_New_Statement_ReturnsValidString()
        {
            //Arrange
            var expected = CleanText(@"Statement for BigCo
                                                Hamlet: $650.00 (55 seats)
                                                As You Like It: $580.00 (35 seats)
                                                Othello: $500.00(40 seats)
                                                Amount owed is $1,730.00
                                                You earned 47 credits");
            SetTestData();
            //Act
            var bill = new Bill02();
            var result = bill.Statement(Invoice, Plays);

            //Assert
            Assert.NotEmpty(result);

            Assert.Equal(expected, CleanText(result));
        }

        private string CleanText(string input)
        {
            return Regex.Replace(input, @"(\r\n\s|\n|\r|\s)+", string.Empty);
        }

        public void SetTestData()
        {
            Plays = new List<Play>()
            {
                new Play("hamlet", "Hamlet", PlayType.Tragedy),
                new Play("as-like", "As You Like It", PlayType.Comedy),
                new Play("othello", "Othello", PlayType.Tragedy)
            };

            Invoice = new Invoice("BigCo");
            Invoice.AddPerformance(Plays.First(x => x.Id == "hamlet"), 55);
            Invoice.AddPerformance(Plays.First(x => x.Id == "as-like"), 35);
            Invoice.AddPerformance(Plays.First(x => x.Id == "othello"), 40);
        }
    }
}
