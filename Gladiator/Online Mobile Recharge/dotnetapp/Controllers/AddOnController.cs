using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Data;
using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/admin")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    // POST: api/admin/addAddon
    [HttpPost("addAddon")]
    public IActionResult AddAddon([FromBody] Addon addon)
    {
        if (addon == null)
        {
            return BadRequest("Invalid data");
        }

        _context.Addons.Add(addon);
        _context.SaveChanges();

        return Ok("Addon added successfully");
    }

    // GET: api/admin/getAddon
    [HttpGet("getAddon")]
    public IActionResult GetAddons()
    {
        var addons = _context.Addons.ToList();
        return Ok(addons);
    }

    // PUT: api/admin/editAddon/{addonId}
    [HttpPut("editAddon/{addonId}")]
    public IActionResult EditAddon(long addonId, [FromBody] Addon updatedAddon)
    {
        var existingAddon = _context.Addons.Find(addonId);

        if (existingAddon == null)
        {
            return NotFound("Addon not found");
        }

        // Update properties based on your requirements
        existingAddon.AddonName = updatedAddon.AddonName;
        existingAddon.AddonPrice = updatedAddon.AddonPrice;
        existingAddon.AddonDetails = updatedAddon.AddonDetails;
        existingAddon.AddonValidity = updatedAddon.AddonValidity;

        _context.SaveChanges();

        return Ok("Addon updated successfully");
    }

    // DELETE: api/admin/deleteAddon/{addonId}
    [HttpDelete("deleteAddon/{addonId}")]
    public IActionResult DeleteAddon(long addonId)
    {
        var addon = _context.Addons.Find(addonId);

        if (addon == null)
        {
            return NotFound("Addon not found");
        }

        _context.Addons.Remove(addon);
        _context.SaveChanges();

        return Ok("Addon deleted successfully");
    }
}
