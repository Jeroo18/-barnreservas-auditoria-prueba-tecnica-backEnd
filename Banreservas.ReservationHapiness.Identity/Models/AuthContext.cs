using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banreservas.ReservationHapiness.Identity.Models
{
    public class AuthContext
    {
        public List<SimpleClaim> Claims { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
