using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreReact.Data;
using CoreReact.Models;
using CoreReact.Models.ModelWrappers;
using CoreReact.Services;
using Microsoft.AspNetCore.Http;

namespace CoreReact.Controllers
{
    public class PlayerProfilesController : Controller
    {
        private readonly PlayerProfileDbContext _context;

        public PlayerProfilesController(PlayerProfileDbContext context)
        {
            _context = context;    
        }

        // GET: PlayerProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlayerProfile.ToListAsync());
        }

        // GET: PlayerProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerProfile = await _context.PlayerProfile.SingleOrDefaultAsync(m => m.Id == id);
            if (playerProfile == null)
            {
                return NotFound();
            }

            return View(playerProfile);
        }

        // GET: PlayerProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayerProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PlayerId,PpgInWin,PpgInLoss,ToPgInWin,ToPgInLoss")] PlayerProfile playerProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(playerProfile);
        }

        // GET: PlayerProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerProfile = await _context.PlayerProfile.SingleOrDefaultAsync(m => m.Id == id);
            if (playerProfile == null)
            {
                return NotFound();
            }
            return View(playerProfile);
        }

        // POST: PlayerProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PlayerId,PpgInWin,PpgInLoss,ToPgInWin,ToPgInLoss")] PlayerProfile playerProfile)
        {
            if (id != playerProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerProfileExists(playerProfile.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(playerProfile);
        }

        // GET: PlayerProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerProfile = await _context.PlayerProfile.SingleOrDefaultAsync(m => m.Id == id);
            if (playerProfile == null)
            {
                return NotFound();
            }

            return View(playerProfile);
        }

        // POST: PlayerProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerProfile = await _context.PlayerProfile.SingleOrDefaultAsync(m => m.Id == id);
            _context.PlayerProfile.Remove(playerProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PlayerProfileExists(int id)
        {
            return _context.PlayerProfile.Any(e => e.Id == id);
        }
        //CANNOT SEND PRIMITIVES LIKE STRINGS ANYMORE CAN ONLY SEND WRAPPER MODEL OBJECTS
        [HttpPost]
        public async Task<String> UpdateAverages([FromBody ] LogJsonWrapper playerStatWrapper)
        {   //parse id, and player stat averages from the json String. Search for the play in the db. context and update based on averages.

            PlayerLogStatsService statCalculatorService=new PlayerLogStatsService();
            int id = statCalculatorService.GetPlayerStatId(playerStatWrapper);
            var playerProfile = await _context.PlayerProfile.SingleOrDefaultAsync(m => m.PlayerId == id);
            if (playerProfile == null)
            {
                return "Nope";
            }
            _context.PlayerProfile.Attach(playerProfile);
            playerProfile = statCalculatorService.CalculateAndUpdateStats(playerProfile,playerStatWrapper);
            await _context.SaveChangesAsync();
            return "Success";
        }
    }
}
