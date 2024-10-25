using API_Reservas.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace API_Reservas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : Controller
    {

        private static List<Reserva> reservas = new List<Reserva>
        {
            new Reserva(1, "Juan Pérez", DateTime.Now.AddDays(1), 4, "Confirmada"),
            new Reserva(2, "Ana Lopez", DateTime.Now.AddDays(2), 2, "Pendiente"),
            new Reserva(3, "Carlos Diaz", DateTime.Now.AddDays(3), 3, "Cancelada"),
            new Reserva(4, "Maria Gonzales", DateTime.Now.AddDays(4), 5, "Confirmada")

        };

        [HttpGet]
        public ActionResult<IEnumerable<Reserva>> GetReservas()
        {
            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public ActionResult<Reserva> GetReserva(int id)
        {
            var reserva = reservas.FirstOrDefault(r => r.ID == id);

            if (reserva == null)
            {
                return NotFound($"La reserva con ID {id} no fue encontrada.");
            }

            return Ok(reserva);
        }

        [HttpPost]
        public ActionResult<Reserva> CrearReserva([FromBody] Reserva nuevaReserva)
        {
            // Asigna un ID automáticamente sumando 1 al último ID
            int nuevoId = reservas.Max(r => r.ID) + 1;
            nuevaReserva.ID = nuevoId;

            // Validar la reserva
            if (!nuevaReserva.ValidarEstado())
            {
                return BadRequest("El estado de la reserva no es válido.");
            }
            if (!nuevaReserva.ValidarNumeroPersonas())
            {
                return BadRequest("El número de personas debe estar entre 1 y 20.");
            }

            reservas.Add(nuevaReserva);

            return CreatedAtAction(nameof(GetReserva), new { id = nuevaReserva.ID }, nuevaReserva);
        }



    }
}
