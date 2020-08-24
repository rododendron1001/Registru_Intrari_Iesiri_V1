using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Registru_Intrari_Iesiri.Models;
using Registru_Intrari_Iesiri.Services;

namespace Registru_Intrari_Iesiri.Controllers
{
    public class InOutRegisterEntriesController : Controller
    {
        private readonly IInOutRegisterService _service;

        public InOutRegisterEntriesController(IInOutRegisterService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: InOutRegisterEntries
        public async Task<IActionResult> Index()
        {
            var entries = await _service.GetEntriesAsync();

            return View(entries);
        }

        // GET: InOutRegisterEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inOutRegisterEntry = await _service.GetByIdAsync(id.Value);
                
            if (inOutRegisterEntry == null)
            {
                return NotFound();
            }

            return View(inOutRegisterEntry);
        }

        // GET: InOutRegisterEntries/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new InOutRegisterEntry()
            {
                DocNumber = await _service.GetNextDocumentNumber(),
                DocDate = DateTime.Today

            };

            return View(viewModel);
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
                var success = await _service.CreateEntryAsync(inOutRegisterEntry);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = "Something went wrong while creating in out register entry, please try again ...";
                }
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

            var inOutRegisterEntry = await _service.GetByIdAsync(id.Value);
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
                    var success = await _service.UpdateEntryAsync(inOutRegisterEntry);
                    if (success)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Something went wrong while updating in out register entry, please try again ...";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    var entry = await _service.GetByIdAsync(inOutRegisterEntry.Id);

                    if (entry is null)
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

            var entry = await _service.GetByIdAsync(id.Value);

            if (entry is null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: InOutRegisterEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _service.DeleteEntryAsync(id);
            if (!success)
            {
                return RedirectToAction(nameof(Delete), new { id });
            }

            return RedirectToAction(nameof(Index));
        }

       
    }
}
