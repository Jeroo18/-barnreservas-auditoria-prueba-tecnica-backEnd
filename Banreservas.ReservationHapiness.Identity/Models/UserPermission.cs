using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banreservas.ReservationHapiness.Identity.Models
{
    public class UserPermission
    {
        public int Id { get; set; }
        public string UserProfileId { get; set; }
        public int? ProjectId { get; set; }
        public string Value { get; set; }
    }
}
