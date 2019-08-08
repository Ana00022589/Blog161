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
    public class mensagemController : Controller
    {
        private readonly MakeContext _context;

        public mensagemController(MakeContext context)
        {
            _context = context;
        }

        // GET: mensagem
        public async Task<IActionResult> Index()
        {
            return View(await _context.mensagem.ToListAsync());
        }

        // GET: mensagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.mensagem
                .FirstOrDefaultAsync(m => m.mensagemId == id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return View(mensagem);
        }

        // GET: mensagem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: mensagem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mensagemId,Titulo,Descricao,data,Categoria")] mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mensagem);
        }

        // GET: mensagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.mensagem.FindAsync(id);
            if (mensagem == null)
            {
                return NotFound();
            }
            return View(mensagem);
        }

        // POST: mensagem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("mensagemId,Titulo,Descricao,data,Categoria")] mensagem mensagem)
        {
            if (id != mensagem.mensagemId)
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
                    if (!mensagemExists(mensagem.mensagemId))
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
            return View(mensagem);
        }

        // GET: mensagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.mensagem
                .FirstOrDefaultAsync(m => m.mensagemId == id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return View(mensagem);
        }

        // POST: mensagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensagem = await _context.mensagem.FindAsync(id);
            _context.mensagem.Remove(mensagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool mensagemExists(int id)
        {
            return _context.mensagem.Any(e => e.mensagemId == id);
        }
    }
}
