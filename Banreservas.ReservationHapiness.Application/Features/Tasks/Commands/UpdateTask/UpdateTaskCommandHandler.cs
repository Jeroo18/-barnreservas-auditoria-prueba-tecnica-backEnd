using AutoMapper;
using Banreservas.ReservationHapiness.Application.Exceptions;
using Banreservas.ReservationHapiness.Application.Interfaces.Infrastructure;
using Banreservas.ReservationHapiness.Application.Interfaces.Persistence;
using Banreservas.ReservationHapiness.Application.Models.Mail;
using Banreservas.ReservationHapiness.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banreservas.ReservationHapiness.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly IAsyncRepository<Domain.Entities.Task> _taskRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<UpdateTaskCommand> _logger;

        public UpdateTaskCommandHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Task> taskRepository,
             IEmailService emailService
            , ILogger<UpdateTaskCommand> logger)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {

            var taskToUpdate = await _taskRepository.GetByIdAsync(request.TaskId);
            if (taskToUpdate == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Task), request.TaskId);
            }

            var validator = new UpdateTaskCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, taskToUpdate, typeof(UpdateTaskCommand), typeof(Domain.Entities.Task));

            await _taskRepository.UpdateAsync(taskToUpdate);
            try
            {
                //await _emailService.SendEmail(email);
                _logger.LogInformation($"Mailing about Task {taskToUpdate.TaskName} was create ok");

            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
                _logger.LogError($"Mailing about Optiontype {taskToUpdate.TaskId} failed due to an error with the mail service: {ex.Message}");
            }

            return Unit.Value;
        }
    }
}
