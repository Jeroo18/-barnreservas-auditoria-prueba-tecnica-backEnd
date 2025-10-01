using AutoMapper;
using Banreservas.ReservationHapiness.Application.Features.Reservations.Mappings;
using Banreservas.ReservationHapiness.Application.Features.Reservations.Queries.GetReservationById;
using Banreservas.ReservationHapiness.Application.Interfaces.Persistence;
using Banreservas.ReservationHapiness.Application.UnitTests.Mocks;
using Moq;
using Xunit;

namespace Banreservas.ReservationHapiness.Application.UnitTests.Reservations.Queries
{
    public class GetReservationByIdQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IReservationRepository> _mockReservationRepository;

        public GetReservationByIdQueryHandlerTests()
        {
            _mockReservationRepository = RepositoryMocks.GetReservationRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidId_ReturnsReservation()
        {
            // Arrange
            var handler = new GetReservationByIdQueryHandler(_mockReservationRepository.Object, _mapper);
            var query = new GetReservationByIdQuery { Id = 1 };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("John Doe", result.CustomerName);
        }

        [Fact]
        public async Task Handle_InvalidId_ThrowsNotFoundException()
        {
            // Arrange
            var handler = new GetReservationByIdQueryHandler(_mockReservationRepository.Object, _mapper);
            var query = new GetReservationByIdQuery { Id = 999 };

            // Act & Assert
            await Assert.ThrowsAsync<Banreservas.ReservationHapiness.Application.Exceptions.NotFoundException>(
                async () => await handler.Handle(query, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_CallsRepositoryGetByIdAsync()
        {
            // Arrange
            var handler = new GetReservationByIdQueryHandler(_mockReservationRepository.Object, _mapper);
            var query = new GetReservationByIdQuery { Id = 1 };

            // Act
            await handler.Handle(query, CancellationToken.None);

            // Assert
            _mockReservationRepository.Verify(m => m.GetByIdAsync(1), Times.Once);
        }
    }
}
