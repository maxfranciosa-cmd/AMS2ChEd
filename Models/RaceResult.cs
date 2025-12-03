using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS2ChEd.Models
{
    public class RacePosition
    {
        public int Position { get; set; }
        public string Driver { get; set; }
        public string Team { get; set; }
        public string Time { get; set; }
        public int PointsAwarded { get; set; }
    }


    public class RaceResult
    {
        public required IEnumerable<RacePosition> Classification { get; set; }
        public required IEnumerable<string> UpdatedStandings { get; set; }
    }
}
