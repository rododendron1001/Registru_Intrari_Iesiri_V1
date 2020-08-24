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
    public class CustomersController : Controller
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var entries = await _service.GetEntriesAsync();

            return View(entries);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _service.GetByIdAsync(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var success = await _service.CreateEntryAsync(customer);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = "Something went wrong while creating customer entry, please try again ...";
                }
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _service.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var success = await _service.UpdateEntryAsync(customer);
                    if (success)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Something went wrong while updating customers, please try again ...";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    var entry = await _service.GetByIdAsync(customer.Id);

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
            return View(customer);
        }

        // GET: Customers/Delete/5
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

        // POST: Customers/Delete/5
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
