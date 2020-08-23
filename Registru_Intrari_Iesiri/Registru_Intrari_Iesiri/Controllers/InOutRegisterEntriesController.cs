using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Registru_Intrari_Iesiri.Models;

namespace Registru_Intrari_Iesiri.Controllers
{
    public class InOutRegisterEntriesController : Controller
    {
        private readonly DataContext _context;

        public InOutRegisterEntriesController(DataContext context)
        {
            _context = context;
        }

        // GET: InOutRegisterEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.InOutRegisterEntry.ToListAsync());
        }

        // GET: InOutRegisterEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inOutRegisterEntry = await _context.InOutRegisterEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inOutRegisterEntry == null)
            {
                return NotFound();
            }

            return View(inOutRegisterEntry);
        }

        // GET: InOutRegisterEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InOutRegisterEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DocNumber,DocDate,Description,Status,Resolution")] InOutRegisterEntry inOutRegisterEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inOutRegisterEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inOutRegisterEntry);

        }

        // GET: InOutRegisterEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inOutRegisterEntry = await _context.InOutRegisterEntry.FindAsync(id);
            if (inOutRegisterEntry == null)
            {
                return NotFound();
            }
            return View(inOutRegisterEntry);
        }

        // POST: InOutRegisterEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DocNumber,DocDate,Description,Status,Resolution")] InOutRegisterEntry inOutRegisterEntry)
        {
            if (id != inOutRegisterEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inOutRegisterEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InOutRegisterEntryExists(inOutRegisterEntry.Id))
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
            return View(inOutRegisterEntry);
        }

        // GET: InOutRegisterEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inOutRegisterEntry = await _context.InOutRegisterEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inOutRegisterEntry == null)
            {
                return NotFound();
            }

            return View(inOutRegisterEntry);
        }

        // POST: InOutRegisterEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inOutRegisterEntry = await _context.InOutRegisterEntry.FindAsync(id);
            _context.InOutRegisterEntry.Remove(inOutRegisterEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InOutRegisterEntryExists(int id)
        {
            return _context.InOutRegisterEntry.Any(e => e.Id == id);
        }
    }
}
