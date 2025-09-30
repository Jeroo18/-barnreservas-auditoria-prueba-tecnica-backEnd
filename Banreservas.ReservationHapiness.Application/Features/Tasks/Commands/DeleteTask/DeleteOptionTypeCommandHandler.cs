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

namespace Banreservas.ReservationHapiness.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly IAsyncRepository<Domain.Entities.Task> _taskRepository;
        private readonly IMapper _mapper;

        public DeleteTaskCommandHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Task> taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskToDelete = await _taskRepository.GetByIdAsync(request.TaskId);

            if (taskToDelete == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Task), request.TaskId);
            }

            await _taskRepository.DeleteAsync(taskToDelete);

            return Unit.Value;
        }
    }
}
