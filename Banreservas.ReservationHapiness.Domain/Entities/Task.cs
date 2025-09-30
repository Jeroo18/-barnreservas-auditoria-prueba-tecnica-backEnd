using Banreservas.ReservationHapiness.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banreservas.ReservationHapiness.Domain.Entities
{
    public class Task : AuditableEntity
    {
        public Guid TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string Tags { get; set; }
        public Nullable<DateTime> CompletedOn { get; set; }

    }
}
