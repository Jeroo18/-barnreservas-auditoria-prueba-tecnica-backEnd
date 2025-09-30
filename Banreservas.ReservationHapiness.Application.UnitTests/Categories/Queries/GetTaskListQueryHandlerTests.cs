using AutoMapper;
using Banreservas.ReservationHapiness.Application.Interfaces.Persistence;
using Banreservas.ReservationHapiness.Application.Profiles;
using Banreservas.ReservationHapiness.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Banreservas.ReservationHapiness.Application.Features.Tasks.Queries.GetTasksList;

namespace Banreservas.ReservationHapiness.Application.UnitTests.Tasks.Queries
{
    public class GetTaskListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Banreservas.ReservationHapiness.Domain.Entities.Task>> _mockTaskRepository;

        public GetTaskListQueryHandlerTests()
        {
            _mockTaskRepository = RepositoryMocks.GetTaskRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetTaskListTest()
        {
            var handler = new GetTasksListQueryHandler(_mapper, _mockTaskRepository.Object);

            var result = await handler.Handle(new GetTasksListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<TaskListVm>>();

            result.Count.ShouldBe(4);
        }
    }
}
