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
    public class PagamentosCartaoController : Controller
    {
        private readonly MyDbContext _context;

        public PagamentosCartaoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: PagamentosCartao
        public async Task<IActionResult> Index()
        {
            return View(await _context.PagamentoComCartao.ToListAsync());
        }

        // GET: PagamentosCartao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoComCartao = await _context.PagamentoComCartao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagamentoComCartao == null)
            {
                return NotFound();
            }

            return View(pagamentoComCartao);
        }

        // GET: PagamentosCartao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PagamentosCartao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroDoCartao,Bandeira,Id,NomeDoCobrado,InformacoesAdicionais")] PagamentoComCartao pagamentoComCartao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentoComCartao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagamentoComCartao);
        }

        // GET: PagamentosCartao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoComCartao = await _context.PagamentoComCartao.FindAsync(id);
            if (pagamentoComCartao == null)
            {
                return NotFound();
            }
            return View(pagamentoComCartao);
        }

        // POST: PagamentosCartao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroDoCartao,Bandeira,Id,NomeDoCobrado,InformacoesAdicionais")] PagamentoComCartao pagamentoComCartao)
        {
            if (id != pagamentoComCartao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentoComCartao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoComCartaoExists(pagamentoComCartao.Id))
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
            return View(pagamentoComCartao);
        }

        // GET: PagamentosCartao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoComCartao = await _context.PagamentoComCartao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagamentoComCartao == null)
            {
                return NotFound();
            }

            return View(pagamentoComCartao);
        }

        // POST: PagamentosCartao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamentoComCartao = await _context.PagamentoComCartao.FindAsync(id);
            _context.PagamentoComCartao.Remove(pagamentoComCartao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoComCartaoExists(int id)
        {
            return _context.PagamentoComCartao.Any(e => e.Id == id);
        }
    }
}
