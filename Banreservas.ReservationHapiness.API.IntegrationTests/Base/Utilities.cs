using Banreservas.ReservationHapiness.Domain.Entities;
using Banreservas.ReservationHapiness.Persistence;
using System;
using Task = Banreservas.ReservationHapiness.Domain.Entities.Task;

namespace Banreservas.ReservationHapiness.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(ReservationHappinessDbContext context)
        {
            var taskId1Guid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var taskId2Guid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var taskId3Guid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var taskId4Guid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var tasks = new List<Task>
            {
                new Task
                {
                    TaskId = taskId1Guid,
                    TaskName = "Concerts"
                },
                new Task
                {
                    TaskId = taskId2Guid,
                    TaskName = "Musicals"
                },
                new Task
                {
                    TaskId = taskId3Guid,
                    TaskName = "Conferences"
                },
                 new Task
                {
                    TaskId = taskId4Guid,
                    TaskName = "Plays"
                }
            };

            context.SaveChanges();
        }
    }
}
