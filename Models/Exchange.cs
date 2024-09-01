using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trockeo.Models
{
    public class Exchange
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }

}
