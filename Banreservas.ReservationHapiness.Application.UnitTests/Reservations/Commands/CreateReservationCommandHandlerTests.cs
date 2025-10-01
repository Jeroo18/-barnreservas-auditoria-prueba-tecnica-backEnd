using AutoMapper;
using Banreservas.ReservationHapiness.Application.Features.Reservations.Commands.CreateReservation;
using Banreservas.ReservationHapiness.Application.Features.Reservations.Mappings;
using Banreservas.ReservationHapiness.Application.Interfaces.Persistence;
using Banreservas.ReservationHapiness.Application.UnitTests.Mocks;
using Banreservas.ReservationHapiness.Domain.Entities;
using Moq;
using Xunit;

namespace Banreservas.ReservationHapiness.Application.UnitTests.Reservations.Commands
{
    public class CreateReservationCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IReservationRepository> _mockReservationRepository;

        public CreateReservationCommandHandlerTests()
        {
            _mockReservationRepository = RepositoryMocks.GetReservationRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidReservation_AddsReservationToRepository()
        {
            // Arrange
            var handler = new CreateReservationCommandHandler(_mockReservationRepository.Object, _mapper);

            var command = new CreateReservationCommand
            {
                CustomerName = "Test Customer",
                CustomerEmail = "test@example.com",
                CustomerPhone = "809-555-9999",
                ReservationDate = DateTime.Now.AddDays(5),
                ReservationTime = "18:00:00",
                NumberOfGuests = 3,
                SpecialRequests = "Window seat please"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Id > 0);
            _mockReservationRepository.Verify(m => m.AddAsync(It.IsAny<Reservation>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ValidReservation_ReturnsCorrectId()
        {
            // Arrange
            var handler = new CreateReservationCommandHandler(_mockReservationRepository.Object, _mapper);

            var command = new CreateReservationCommand
            {
                CustomerName = "Another Customer",
                CustomerEmail = "another@example.com",
                ReservationDate = DateTime.Now.AddDays(7),
                ReservationTime = "19:30:00",
                NumberOfGuests = 6
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            _mockReservationRepository.Verify(m => m.AddAsync(It.Is<Reservation>(r =>
                r.CustomerName == "Another Customer" &&
                r.NumberOfGuests == 6)), Times.Once);
        }
    }
}
