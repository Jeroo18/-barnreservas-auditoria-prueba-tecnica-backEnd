using System.ComponentModel.DataAnnotations;

namespace Banreservas.ReservationHapiness.Application.Features.Reservations.DTOs
{
    public class UpdateReservationDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string CustomerEmail { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Teléfono inválido")]
        public string? CustomerPhone { get; set; }

        [Required(ErrorMessage = "La fecha de reserva es requerida")]
        public DateTime ReservationDate { get; set; }

        [Required(ErrorMessage = "La hora de reserva es requerida")]
        public string ReservationTime { get; set; } = string.Empty;

        [Required(ErrorMessage = "El número de personas es requerido")]
        [Range(1, 20, ErrorMessage = "El número de personas debe estar entre 1 y 20")]
        public int NumberOfGuests { get; set; }

        [StringLength(500, ErrorMessage = "Las solicitudes especiales no pueden exceder 500 caracteres")]
        public string? SpecialRequests { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public int Status { get; set; }
    }
}