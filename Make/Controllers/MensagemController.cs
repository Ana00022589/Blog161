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
    public class MensagemController : Controller
    {
        private readonly MakeContext _context;

        public MensagemController(MakeContext context)
        {
            _context = context;
        }

        // GET: Mensagem
        public async Task<IActionResult> Index()
        {
            var makeContext = _context.Mensagem.Include(m => m.Comentarios).Include(m => m.Rimel);
            return View(await makeContext.ToListAsync());
        }

        // GET: Mensagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem
                .Include(m => m.Comentarios)
                .Include(m => m.Rimel)
                .FirstOrDefaultAsync(m => m.MensagemId == id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return View(mensagem);
        }

        // GET: Mensagem/Create
        public IActionResult Create()
        {
            ViewData["ComentarioId"] = new SelectList(_context.Comentario, "ComentarioId", "ComentarioId");
            ViewData["RimelId"] = new SelectList(_context.Rimel, "RimelId", "RimelId");
            return View();
        }

        // POST: Mensagem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MensagemId,Titulo,Descricao,Data,RimelId,ComentarioId")] Mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComentarioId"] = new SelectList(_context.Comentario, "ComentarioId", "ComentarioId", mensagem.ComentarioId);
            ViewData["RimelId"] = new SelectList(_context.Rimel, "RimelId", "RimelId", mensagem.RimelId);
            return View(mensagem);
        }

        // GET: Mensagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem.FindAsync(id);
            if (mensagem == null)
            {
                return NotFound();
            }
            ViewData["ComentarioId"] = new SelectList(_context.Comentario, "ComentarioId", "ComentarioId", mensagem.ComentarioId);
            ViewData["RimelId"] = new SelectList(_context.Rimel, "RimelId", "RimelId", mensagem.RimelId);
            return View(mensagem);
        }

        // POST: Mensagem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MensagemId,Titulo,Descricao,Data,RimelId,ComentarioId")] Mensagem mensagem)
        {
            if (id != mensagem.MensagemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensagemExists(mensagem.MensagemId))
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
            ViewData["ComentarioId"] = new SelectList(_context.Comentario, "ComentarioId", "ComentarioId", mensagem.ComentarioId);
            ViewData["RimelId"] = new SelectList(_context.Rimel, "RimelId", "RimelId", mensagem.RimelId);
            return View(mensagem);
        }

        // GET: Mensagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem
                .Include(m => m.Comentarios)
                .Include(m => m.Rimel)
                .FirstOrDefaultAsync(m => m.MensagemId == id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return View(mensagem);
        }

        // POST: Mensagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensagem = await _context.Mensagem.FindAsync(id);
            _context.Mensagem.Remove(mensagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensagemExists(int id)
        {
            return _context.Mensagem.Any(e => e.MensagemId == id);
        }
    }
}
