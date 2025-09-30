using AutoMapper;
using Banreservas.ReservationHapiness.Application.Interfaces.Persistence;
using Banreservas.ReservationHapiness.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace Banreservas.ReservationHapiness.Application.Features.Tasks.Queries.GetTasksList
{
    public class GetTasksListQueryHandler : IRequestHandler<GetTasksListQuery, List<TaskListVm>>
    {
        private readonly IAsyncRepository<Domain.Entities.Task> _taskRepository;
        private readonly IMapper _mapper;

        public GetTasksListQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Task> taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }
        public async Task<List<TaskListVm>> Handle(GetTasksListQuery request, CancellationToken cancellationToken)
        {
            var allTasks = (await _taskRepository.ListAllAsync()).OrderBy(x => x.TaskName).Where(x => x.CreatedBy == request.UserId);
            return _mapper.Map<List<TaskListVm>>(allTasks);
        }
    }
}
