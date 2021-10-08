using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Chapter01
{
    public class Play
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public PlayType Type { get; set; }

        public Play(string id, string name, PlayType playType)
        {
            Id = id;
            Name = name;
            Type = playType;
        }
    }
}
