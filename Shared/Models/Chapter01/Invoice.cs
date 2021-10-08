using System;
using System.Collections.Generic;

namespace Shared.Models.Chapter01
{
    public class Invoice
    {
        public string Customer { get; set; }
        public List<Performance> Performances { get; set; }
    }
}
