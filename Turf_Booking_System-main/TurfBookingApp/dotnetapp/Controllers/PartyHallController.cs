using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class PartyHallController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PartyHallController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var partyHalls = _dbContext.PartyHalls.ToList();
            return View(partyHalls);
        }

        public IActionResult Delete(int partyHallId)
        {
            var partyHall = _dbContext.PartyHalls.FirstOrDefault(p => p.PartyHallID == partyHallId);
            if (partyHall == null)
            {
                return NotFound();
            }

            return View(partyHall);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int partyHallId)
        {
            var partyHall = _dbContext.PartyHalls.FirstOrDefault(p => p.PartyHallID == partyHallId);
            if (partyHall == null)
            {
                return NotFound();
            }

            _dbContext.PartyHalls.Remove(partyHall);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
   public IActionResult Search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                // Handle case where name is null or empty
                return RedirectToAction(nameof(Index));
            }

            var partyHall = _dbContext.PartyHalls.FirstOrDefault(p => p.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));

            if (partyHall == null)
            {
                // Handle case where no party hall with the specified name is found
                TempData["Message"] = $"Party hall '{name}' not found.";
                return RedirectToAction(nameof(Index));
            }

            return View(nameof(Index), new List<PartyHall> { partyHall });
        }
    }
}