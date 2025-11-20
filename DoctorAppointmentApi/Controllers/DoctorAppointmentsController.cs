using DoctorAppointmentApi.Data;
using DoctorAppointmentApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorAppointmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DoctorAppointmentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DoctorAppointment>>> GetAll()
        {
            return await _context.DoctorAppointments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorAppointment>> Get(int id)
        {
            var appointment = await _context.DoctorAppointments.FindAsync(id);
            if (appointment == null)
                return NotFound();
            return appointment;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DoctorAppointment appointment)
        {
            _context.DoctorAppointments.Add(appointment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = appointment.Id }, appointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DoctorAppointment updatedAppointment)
        {
            if (id != updatedAppointment.Id)
                return BadRequest();

            var appointment = await _context.DoctorAppointments.FindAsync(id);
            if (appointment == null)
                return NotFound();

            appointment.PatientName = updatedAppointment.PatientName;
            appointment.DoctorName = updatedAppointment.DoctorName;
            appointment.AppointmentDate = updatedAppointment.AppointmentDate;
            appointment.Details = updatedAppointment.Details;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _context.DoctorAppointments.FindAsync(id);
            if (appointment == null)
                return NotFound();

            _context.DoctorAppointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
