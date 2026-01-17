using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data.Contexts;
using WebApplication2.Data.Entities;

namespace WebApplication2.Controllers;

[ApiController]
[Route("api/[controller]")]

public class DoctorController : ControllerBase
{
    private readonly AppDbContext _context;
    public DoctorController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult GetDoctors()
    {
        var doctors = _context.Doctors.ToList();
        return Ok(doctors);
    }
    [HttpPost]
    public IActionResult AddDoctor([FromBody] Doctor doctor)
    {
        if (string.IsNullOrWhiteSpace(doctor.Name) || string.IsNullOrWhiteSpace(doctor.Specialty))
        {
            return BadRequest("Doctor data is null.");
        }
        _context.Doctors.Add(doctor);
        _context.SaveChanges();
        return Ok(doctor);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteDoctor(int id)
    {
        var doctor = _context.Doctors.Find(id);
        if (doctor == null)
        {
            return NotFound();
        }
        _context.Doctors.Remove(doctor);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateDoctor(int id, [FromBody] Doctor updatedDoctor)
    {
        var doctor = _context.Doctors.Find(id);
        if (doctor == null)
        {
            return NotFound();
        }
        doctor.Name = updatedDoctor.Name;
        doctor.Specialty = updatedDoctor.Specialty;
        _context.SaveChanges();
        return Ok(updatedDoctor);
    }
    [HttpGet("{id}")]
    public IActionResult GetDoctorById(int id)
    {
        var doctor = _context.Doctors.Find(id);
        if (doctor == null)
        {
            return NotFound();
        }
        return Ok(doctor);
    }
    [HttpGet("Name/{name}")]
    public IActionResult GetDoctorByName(string name)
    {
        var doctor = _context.Doctors.FirstOrDefault(d => d.Name.Trim().ToLower()==name.Trim().ToLower());
        if (doctor == null)
        {
            return NotFound();
        }
        return Ok(doctor);
    }

}
