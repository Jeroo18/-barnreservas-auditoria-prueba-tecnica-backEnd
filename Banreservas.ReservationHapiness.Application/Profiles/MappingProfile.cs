using AutoMapper;
using Banreservas.ReservationHapiness.Application.Features.Tasks.Commands.CreateTask;
using Banreservas.ReservationHapiness.Application.Features.Tasks.Commands.DeleteTask;
using Banreservas.ReservationHapiness.Application.Features.Tasks.Commands.UpdateTask;
using Banreservas.ReservationHapiness.Application.Features.Tasks.Queries.GetTaskDetail;
using Banreservas.ReservationHapiness.Application.Features.Tasks.Queries.GetTasksList;
using Banreservas.ReservationHapiness.Domain.Entities;

namespace Banreservas.ReservationHapiness.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            // Mapping for Task
            CreateMap<Domain.Entities.Task, TaskListVm>().ReverseMap();
            CreateMap<Domain.Entities.Task, TaskDetailVm>().ReverseMap();
            CreateMap<Domain.Entities.Task, CreateTaskCommand>().ReverseMap();
            CreateMap<Domain.Entities.Task, UpdateTaskCommand>().ReverseMap();
            CreateMap<Domain.Entities.Task, DeleteTaskCommand>().ReverseMap();
            CreateMap<Domain.Entities.Task, CreateTaskDto>().ReverseMap();
            //CreateMap<Domain.Entities.Task, TaskExportDto>().ReverseMap();

        }
    }
}
