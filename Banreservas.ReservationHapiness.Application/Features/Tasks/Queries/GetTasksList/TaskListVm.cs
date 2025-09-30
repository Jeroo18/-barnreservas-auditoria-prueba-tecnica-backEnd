using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banreservas.ReservationHapiness.Application.Features.Tasks.Queries.GetTasksList
{
    public class TaskListVm
    {
        public Guid TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string Tags { get; set; }
        public DateTime CompletedOn { get; set; }
        public string? CreatedBy { get; set; }
    }
}
