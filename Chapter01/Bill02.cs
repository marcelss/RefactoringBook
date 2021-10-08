using Shared.Models.Chapter01;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Chapter01
{
    public class Bill02
    {
        public string Statement(Invoice invoice, List<Play> plays)
        {
            var totalAmount = 0;
            decimal volumeCredits = 0;
            var result = $"Statement for { invoice.Customer}\n";

            CultureInfo culture = new CultureInfo("en-US");

            foreach (var perf in invoice.Performances)
            {
                var play = plays.FirstOrDefault(x => x.Id == perf.Play.Id);

                if (play == null)
                    throw new Exception($"Play with identifier: {perf.Play.Id} was not found");

                var thisAmount = AmountFor(perf, play);

                // add volume credits
                volumeCredits += Math.Max(perf.Audience - 30, 0);
                // add extra credit for every ten comedy attendees
                if (PlayType.Comedy == play.Type) volumeCredits += Math.Floor((decimal)perf.Audience / 5);

                // print line for this order
                result += $"{ play.Name}: { (thisAmount / 100).ToString("C", culture)} ({ perf.Audience} seats)\n";
                totalAmount += thisAmount;
            }
            result += $"Amount owed is { (totalAmount / 100).ToString("C", culture)}\n";
            result += $"You earned {volumeCredits} credits\n";
            return result;
        }

        /// <summary>
        /// First refactor using Extract Function (134)
        /// </summary>
        /// <param name="perf"></param>
        /// <param name="play"></param>
        /// <returns></returns>
        public int AmountFor(Performance perf, Play play)
        {
            var thisAmount = 0;
            switch (play.Type)
            {
                case PlayType.Tragedy:
                    thisAmount = 40000;
                    if (perf.Audience > 30)
                    {
                        thisAmount += 1000 * (perf.Audience - 30);
                    }
                    break;
                case PlayType.Comedy:
                    thisAmount = 30000;
                    if (perf.Audience > 20)
                    {
                        thisAmount += 10000 + 500 * (perf.Audience - 20);
                    }
                    thisAmount += 300 * perf.Audience;
                    break;
                default:
                    throw new Exception($"unknown type: {play.Type}");
            }

            return thisAmount;
        }
    }
}
