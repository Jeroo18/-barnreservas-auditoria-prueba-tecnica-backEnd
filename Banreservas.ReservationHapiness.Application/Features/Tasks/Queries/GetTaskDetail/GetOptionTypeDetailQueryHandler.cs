using AutoMapper;
using Banreservas.ReservationHapiness.Application.Exceptions;
using Banreservas.ReservationHapiness.Application.Interfaces.Persistence;
using Banreservas.ReservationHapiness.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banreservas.ReservationHapiness.Application.Features.Tasks.Queries.GetTaskDetail
{
    public class GetTaskDetailQueryHandler : IRequestHandler<GetTaskDetailQuery, TaskDetailVm>
    {
        private readonly IAsyncRepository<Domain.Entities.Task> _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskDetailQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Task> taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }
        public async Task<TaskDetailVm> Handle(GetTaskDetailQuery request, CancellationToken cancellationToken)
        {
            var @Task = await _taskRepository.GetByIdAsync(request.TaskId);
            var taskDetailDto = _mapper.Map<TaskDetailVm>(@Task);

            return taskDetailDto;
        }
    }
}
