using Banreservas.ReservationHapiness.Application.Interfaces.Persistence;
using Banreservas.ReservationHapiness.Domain.Entities;
using Moq;

namespace Banreservas.ReservationHapiness.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IReservationRepository> GetReservationRepository()
        {
            var reservations = new List<Reservation>
            {
                new Reservation
                {
                    Id = 1,
                    CustomerName = "John Doe",
                    CustomerEmail = "john@example.com",
                    CustomerPhone = "809-555-1234",
                    ReservationDate = DateTime.Now.AddDays(1),
                    ReservationTime = new TimeSpan(19, 0, 0),
                    NumberOfGuests = 4,
                    Status = ReservationStatus.Confirmed
                },
                new Reservation
                {
                    Id = 2,
                    CustomerName = "Jane Smith",
                    CustomerEmail = "jane@example.com",
                    CustomerPhone = "809-555-5678",
                    ReservationDate = DateTime.Now.AddDays(2),
                    ReservationTime = new TimeSpan(20, 30, 0),
                    NumberOfGuests = 2,
                    Status = ReservationStatus.Pending
                }
            };

            var mockReservationRepository = new Mock<IReservationRepository>();
            mockReservationRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(reservations);

            mockReservationRepository.Setup(repo => repo.AddAsync(It.IsAny<Reservation>())).ReturnsAsync(
                (Reservation reservation) =>
                {
                    reservation.Id = reservations.Count + 1;
                    reservations.Add(reservation);
                    return reservation;
                });

            mockReservationRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(
                (int id) => reservations.FirstOrDefault(r => r.Id == id));

            return mockReservationRepository;
        }
    }
}
