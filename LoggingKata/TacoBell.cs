using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    class TacoBell : ITrackable
    {
        public TacoBell(string _Name, Point _Location)
        {
            Name = _Name;
            Location = _Location;
        }
        public string Name { get; set; }
        public Point Location { get; set; }
    }
    
}
