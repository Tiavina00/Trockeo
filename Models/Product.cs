using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trockeo.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string State { get; set; }
        public Owner Owner { get; set; }
        public DateTime EnteredDate { get; set; }
        public Picture Picture { get; set; }
    }
}
