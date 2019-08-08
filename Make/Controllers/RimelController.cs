using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Make.Models;

namespace Make.Controllers
{
    public class RimelController : Controller
    {
        private readonly MakeContext _context;

        public RimelController(MakeContext context)
        {
            _context = context;
        }

        // GET: Rimel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rimel.ToListAsync());
        }

        // GET: Rimel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rimel = await _context.Rimel
                .FirstOrDefaultAsync(m => m.RimelID == id);
            if (rimel == null)
            {
                return NotFound();
            }

            return View(rimel);
        }

        // GET: Rimel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rimel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RimelID,Descricao")] Rimel rimel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rimel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rimel);
        }

        // GET: Rimel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rimel = await _context.Rimel.FindAsync(id);
            if (rimel == null)
            {
                return NotFound();
            }
            return View(rimel);
        }

        // POST: Rimel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RimelID,Descricao")] Rimel rimel)
        {
            if (id != rimel.RimelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rimel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RimelExists(rimel.RimelID))
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
            return View(rimel);
        }

        // GET: Rimel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rimel = await _context.Rimel
                .FirstOrDefaultAsync(m => m.RimelID == id);
            if (rimel == null)
            {
                return NotFound();
            }

            return View(rimel);
        }

        // POST: Rimel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rimel = await _context.Rimel.FindAsync(id);
            _context.Rimel.Remove(rimel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RimelExists(int id)
        {
            return _context.Rimel.Any(e => e.RimelID == id);
        }
    }
}
