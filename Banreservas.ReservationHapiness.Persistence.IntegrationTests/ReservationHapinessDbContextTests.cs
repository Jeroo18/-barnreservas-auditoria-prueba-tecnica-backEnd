using Banreservas.ReservationHapiness.Application.Interfaces;
using Banreservas.ReservationHapiness.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace Banreservas.ReservationHapiness.Persistence.IntegrationTests
{
    public class ReservationHappinessDbContextTests
    {
        private readonly ReservationHappinessDbContext _dbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public ReservationHappinessDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ReservationHappinessDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _dbContext = new ReservationHappinessDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var task = new Domain.Entities.Task()
            {
                TaskId = Guid.NewGuid(),
                TaskName = "Test SurveyType",
                TaskDescription = "Esto es una tarea de prueba",
                CompletedOn = null,
                CreatedDate = DateTime.UtcNow,
                IsCompleted = false,
                DueDate = DateTime.UtcNow,
                CreatedBy = "scuevas@outlook.com"
                
            };

            _dbContext.Add<Domain.Entities.Task>(task);
            await _dbContext.SaveChangesAsync();

            task.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
