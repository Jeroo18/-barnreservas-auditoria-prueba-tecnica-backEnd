using AutoMapper;
using Banreservas.ReservationHapiness.Application.Interfaces.Persistence;
using Banreservas.ReservationHapiness.Application.Profiles;
using Banreservas.ReservationHapiness.Application.UnitTests.Mocks;
using Banreservas.ReservationHapiness.Domain.Entities;
using Moq;
using Shouldly;
using Banreservas.ReservationHapiness.Application.Features.Tasks.Commands.CreateTask;
using NUnit.Framework.Internal;

namespace GBanreservas.ReservationHapiness.Application.UnitTests.Tasks.Commands
{
    public class CreateTaskTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Banreservas.ReservationHapiness.Domain.Entities.Task>> _mockTaskRepository;

        public CreateTaskTests()
        {
            _mockTaskRepository = RepositoryMocks.GetTaskRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async System.Threading.Tasks.Task Handle_ValidTask_AddedToTasksRepo()
        {
            var handler = new CreateTaskCommandHandler(_mapper, _mockTaskRepository.Object);

            await handler.Handle(new CreateTaskCommand() { 
                TaskName = "Test",
                TaskDescription = "Test",
                DueDate = DateTime.Now,
                IsCompleted = false,
                CompletedOn = null,
                Tags = "Test"
            }, CancellationToken.None);

            var allTasks = await _mockTaskRepository.Object.ListAllAsync();
            allTasks.Count.ShouldBe(5);
        }
    }
}
