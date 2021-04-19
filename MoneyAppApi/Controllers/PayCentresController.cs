using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneyApp.Data;
using MoneyApp.Models;

namespace MoneyApp.Controllers
{
    public class PayCentresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PayCentresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PayCentres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Centres.Include(m => m.Staff).ThenInclude(p => p.ApplicationUser).ToListAsync());
        }

        // GET: PayCentres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payCentre = await _context.Centres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payCentre == null)
            {
                return NotFound();
            }

            return View(payCentre);
        }

        // GET: PayCentres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PayCentres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CentreName,CentreAddress,CentreAccountNo,DateCreated,Capital,CentreTabNumber,CentrePhone,CentrePOSNumber,UpdateDate,UpdateBy")] PayCentre payCentre)
        {
            if (ModelState.IsValid)
            {
                payCentre.UpdateDate = DateTime.Now.ToString();
                _context.Add(payCentre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payCentre);
        }

        // GET: PayCentres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payCentre = await _context.Centres.FindAsync(id);
            if (payCentre == null)
            {
                return NotFound();
            }
            return View(payCentre);
        }

        // POST: PayCentres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CentreName,CentreAddress,CentreAccountNo,DateCreated,Capital,CentreTabNumber,CentrePhone,CentrePOSNumber,UpdateDate,UpdateBy")] PayCentre payCentre)
        {
            if (id != payCentre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    payCentre.UpdateDate = DateTime.Now.ToString();
                    _context.Update(payCentre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayCentreExists(payCentre.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(payCentre);
        }

        // GET: PayCentres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payCentre = await _context.Centres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payCentre == null)
            {
                return NotFound();
            }

            return View(payCentre);
        }

        // POST: PayCentres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payCentre = await _context.Centres.FindAsync(id);
            _context.Centres.Remove(payCentre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayCentreExists(int id)
        {
            return _context.Centres.Any(e => e.Id == id);
        }
    }
}
