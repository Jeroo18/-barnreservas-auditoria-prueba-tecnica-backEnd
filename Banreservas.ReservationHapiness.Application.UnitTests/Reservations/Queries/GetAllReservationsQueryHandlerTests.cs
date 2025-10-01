using AutoMapper;
using Banreservas.ReservationHapiness.Application.Features.Reservations.Mappings;
using Banreservas.ReservationHapiness.Application.Features.Reservations.Queries.GetAllReservations;
using Banreservas.ReservationHapiness.Application.Interfaces.Persistence;
using Banreservas.ReservationHapiness.Application.UnitTests.Mocks;
using Moq;
using Xunit;

namespace Banreservas.ReservationHapiness.Application.UnitTests.Reservations.Queries
{
    public class GetAllReservationsQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IReservationRepository> _mockReservationRepository;

        public GetAllReservationsQueryHandlerTests()
        {
            _mockReservationRepository = RepositoryMocks.GetReservationRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ReturnsAllReservations()
        {
            // Arrange
            var handler = new GetAllReservationsQueryHandler(_mockReservationRepository.Object, _mapper);
            var query = new GetAllReservationsQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Banreservas.ReservationHapiness.Application.Features.Reservations.DTOs.ReservationDto>>(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task Handle_CallsRepositoryListAllAsync()
        {
            // Arrange
            var handler = new GetAllReservationsQueryHandler(_mockReservationRepository.Object, _mapper);
            var query = new GetAllReservationsQuery();

            // Act
            await handler.Handle(query, CancellationToken.None);

            // Assert
            _mockReservationRepository.Verify(m => m.ListAllAsync(), Times.Once);
        }
    }
}
