using Banreservas.ReservationHapiness.API.Utility;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Banreservas.ReservationHapiness.Application.Features.Tasks.Commands.CreateTask;
using Banreservas.ReservationHapiness.Application.Features.Tasks.Queries.GetTaskDetail;
using Banreservas.ReservationHapiness.Application.Features.Tasks.Queries.GetTasksList;
using Banreservas.ReservationHapiness.Application.Features.Tasks.Commands.UpdateTask;
using Banreservas.ReservationHapiness.Application.Features.Tasks.Commands.DeleteTask;
using IdentityModel;
using System.Security.Claims;

namespace Banreservas.ReservationHapiness.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TaskListVm>>> GetAllTask()
       {
            string userId = this.User.FindFirstValue(JwtClaimTypes.Email);
            var dtos = await _mediator.Send(new GetTasksListQuery() { UserId = userId } );
            return Ok(dtos);
        }

        [HttpGet("{taskId}", Name = "GetTaskById")]
        public async Task<ActionResult<TaskDetailVm>> GetTaskById(Guid taskId)
        {
            var getTaskDetailQuery = new GetTaskDetailQuery() { TaskId = taskId };
            return Ok(await _mediator.Send(getTaskDetailQuery));
        }


        [HttpPost(Name = "AddTask")]
        public async Task<ActionResult<CreateTaskCommandResponse>> Create([FromBody] CreateTaskCommand createTaskCommand)
        {
            var response = await _mediator.Send(createTaskCommand);
            return Ok(response);
        }     

        [HttpPut(Name = "UpdateTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateTaskCommand updateTaskCommand)
        {
            await _mediator.Send(updateTaskCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            //Guid taskId = Guid.Parse(id);
            var deleteTaskCommand = new DeleteTaskCommand() { TaskId = id };
            await _mediator.Send(deleteTaskCommand);
            return NoContent();
        }

        //[HttpGet("export", Name = "ExportTask")]
        //[FileResultContentType("text/csv")]
        //public async Task<FileResult> ExportTask()
        //{
        //    var fileDto = await _mediator.Send(new GetTaskExportQuery());

        //    return File(fileDto.Data, fileDto.ContentType, fileDto.TaskExportFileName);
        //}
    }
}
