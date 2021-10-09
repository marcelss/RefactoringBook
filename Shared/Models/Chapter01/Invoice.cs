using System;
using System.Collections.Generic;

namespace Shared.Models.Chapter01
{
    public class Invoice
    {
        public string Customer { get; set; }
        public List<Performance> Performances { get; set; }

        public Invoice()
        {
            Performances = new List<Performance>();
        }

        public Invoice(string customer)
        {
            Customer = customer;
            Performances = new List<Performance>();
        }

        public Invoice(string customer, Performance performance)
        {
            Customer = customer;
            Performances = new List<Performance>()
            {
                performance
            };
        }

        public void AddPerformance(Play play, int audience)
        {
            if (Performances.Exists(x => x.Play.Id == play.Id))
                return;
            
            Performances.Add(new Performance(play, audience));
        }
    }
}
