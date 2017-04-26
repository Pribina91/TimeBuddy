using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeBuddy.Models
{
    public class Times
    {
        public string LocalTime { get; set; }
        public string DefaultTime { get; set; }
        public string CulturelessTime { get; set; }
    }
}