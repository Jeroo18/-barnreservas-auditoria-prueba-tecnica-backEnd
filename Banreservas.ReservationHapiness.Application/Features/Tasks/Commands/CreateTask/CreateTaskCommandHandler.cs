using AutoMapper;
using Banreservas.ReservationHapiness.Application.Interfaces.Infrastructure;
using Banreservas.ReservationHapiness.Application.Interfaces.Persistence;
using Banreservas.ReservationHapiness.Application.Models.Mail;
using Banreservas.ReservationHapiness.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banreservas.ReservationHapiness.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskCommandResponse>
    {
        private readonly IAsyncRepository<Domain.Entities.Task> _taskRepository;
        private readonly IMapper _mapper;
        //private readonly IEmailService _emailService;
        //private readonly ILogger<CreateTaskCommand> _logger;

        public CreateTaskCommandHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Task> taskRepository 
             // IEmailService emailService
            //, ILogger<CreateTaskCommand> logger
            )
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
           // _emailService = emailService;
           // _logger = logger;

        }

        public async Task<CreateTaskCommandResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var createTaskCommandResponse = new CreateTaskCommandResponse();

            var validator = new CreateTaskCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createTaskCommandResponse.Success = false;
                createTaskCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createTaskCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createTaskCommandResponse.Success)
            {
                var task = new Domain.Entities.Task()
                {
                    TaskName = request.TaskName,
                    TaskDescription = request.TaskDescription,
                    DueDate = request.DueDate,
                    IsCompleted = request.IsCompleted,
                    CompletedOn = request.CompletedOn,
                    Tags = request.Tags
                };

                task = await _taskRepository.AddAsync(task);
                createTaskCommandResponse.TaskDto = _mapper.Map<CreateTaskDto>(task);
            }
            try
            {
               // await _emailService.SendEmail(email);
               // _logger.LogInformation($"Mailing about Optiontype {createTaskCommandResponse.TaskDto.TaskId} was create ok");

            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
               // _logger.LogError($"Mailing about Optiontype {createTaskCommandResponse.TaskDto.TaskId} failed due to an error with the mail service: {ex.Message}");
            }

            return createTaskCommandResponse;
        }

    }
}
