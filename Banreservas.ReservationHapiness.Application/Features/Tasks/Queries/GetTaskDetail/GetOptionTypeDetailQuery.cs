using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banreservas.ReservationHapiness.Application.Features.Tasks.Queries.GetTaskDetail
{
    public class GetTaskDetailQuery : IRequest<TaskDetailVm>
    {
        public Guid TaskId { get; set; }
    }
}
