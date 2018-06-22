using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.Models
{
    public class TourEventsModel
    {
        public string TourName { get; set; }

        public string EventMonth { get; set; }

        public int EventDay { get; set; }

        public int EventYear { get; set; }

        public int Fee { get; set; }
    }
}
