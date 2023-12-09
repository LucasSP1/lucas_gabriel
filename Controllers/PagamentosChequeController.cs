#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lucas_gabriel.Models;

namespace lucas_gabriel.Controllers
{
    public class PagamentosChequeController : Controller
    {
        private readonly MyDbContext _context;

        public PagamentosChequeController(MyDbContext context)
        {
            _context = context;
        }

        // GET: PagamentosCheque
        public async Task<IActionResult> Index()
        {
            return View(await _context.PagamentoComCheque.ToListAsync());
        }

        // GET: PagamentosCheque/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoComCheque = await _context.PagamentoComCheque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagamentoComCheque == null)
            {
                return NotFound();
            }

            return View(pagamentoComCheque);
        }

        // GET: PagamentosCheque/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PagamentosCheque/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeDoBanco,Id,NomeDoCobrado,InformacoesAdicionais")] PagamentoComCheque pagamentoComCheque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentoComCheque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagamentoComCheque);
        }

        // GET: PagamentosCheque/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoComCheque = await _context.PagamentoComCheque.FindAsync(id);
            if (pagamentoComCheque == null)
            {
                return NotFound();
            }
            return View(pagamentoComCheque);
        }

        // POST: PagamentosCheque/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NomeDoBanco,Id,NomeDoCobrado,InformacoesAdicionais")] PagamentoComCheque pagamentoComCheque)
        {
            if (id != pagamentoComCheque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentoComCheque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoComChequeExists(pagamentoComCheque.Id))
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
            return View(pagamentoComCheque);
        }

        // GET: PagamentosCheque/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoComCheque = await _context.PagamentoComCheque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagamentoComCheque == null)
            {
                return NotFound();
            }

            return View(pagamentoComCheque);
        }

        // POST: PagamentosCheque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamentoComCheque = await _context.PagamentoComCheque.FindAsync(id);
            _context.PagamentoComCheque.Remove(pagamentoComCheque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoComChequeExists(int id)
        {
            return _context.PagamentoComCheque.Any(e => e.Id == id);
        }
    }
}