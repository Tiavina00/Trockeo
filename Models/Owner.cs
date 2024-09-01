using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trockeo.Models
{
    public class Owner
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
        public bool Admin { get; set; }
        public bool Moderator { get; set; }
        public bool Client { get; set; }
    }
}
