using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banreservas.ReservationHapiness.Application.Features.Tasks.Queries.GetTasksList
{
    public class GetTasksListQuery : IRequest<List<TaskListVm>>
    {
        public string UserId { get; set; }
    }
}
