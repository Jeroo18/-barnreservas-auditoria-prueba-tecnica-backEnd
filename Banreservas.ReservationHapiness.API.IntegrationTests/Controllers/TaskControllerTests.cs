using Banreservas.ReservationHapiness.API.IntegrationTests.Base;
using Banreservas.ReservationHapiness.Application.Features.Tasks.Queries.GetTasksList;
using System.Text.Json;

namespace Banreservas.ReservationHapiness.API.IntegrationTests.Controllers
{

    public class TaskControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public TaskControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/task/all");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<TaskListVm>>(responseString);

            Assert.IsType<List<TaskListVm>>(result);
            Assert.NotEmpty(result);
        }
    }
}
