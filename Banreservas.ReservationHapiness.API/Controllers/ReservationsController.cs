using Banreservas.ReservationHapiness.Application.Features.Reservations.Commands.CreateReservation;
using Banreservas.ReservationHapiness.Application.Features.Reservations.Commands.DeleteReservation;
using Banreservas.ReservationHapiness.Application.Features.Reservations.Commands.UpdateReservation;
using Banreservas.ReservationHapiness.Application.Features.Reservations.DTOs;
using Banreservas.ReservationHapiness.Application.Features.Reservations.Queries.GetAllReservations;
using Banreservas.ReservationHapiness.Application.Features.Reservations.Queries.GetReservationById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Banreservas.ReservationHapiness.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene todas las reservas (público)
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ReservationDto>>> GetAll()
        {
            var reservations = await _mediator.Send(new GetAllReservationsQuery());
            return Ok(reservations);
        }

        /// <summary>
        /// Obtiene una reserva por ID (público)
        /// </summary>
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReservationDto>> GetById(int id)
        {
            var reservation = await _mediator.Send(new GetReservationByIdQuery { Id = id });
            return Ok(reservation);
        }

        /// <summary>
        /// Crea una nueva reserva (requiere autenticación)
        /// </summary>
        [HttpPost]
        [Authorize]
       // [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ReservationDto>> Create([FromBody] CreateReservationCommand command)
        {
            var reservation = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservation);
        }

        /// <summary>
        /// Actualiza una reserva existente (requiere autenticación)
        /// </summary>
        [HttpPut("{id}")]
        [Authorize]
        //[AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateReservationCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del comando");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Elimina una reserva (requiere autenticación)
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        //[AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteReservationCommand { Id = id });
            return NoContent();
        }
    }
}