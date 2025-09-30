using Banreservas.ReservationHapiness.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banreservas.ReservationHapiness.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandResponse : BaseResponse
    {
        public CreateTaskCommandResponse() : base()
        {

        }

        public CreateTaskDto TaskDto { get; set; } = default!;
    }
}
