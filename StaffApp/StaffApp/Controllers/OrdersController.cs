using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StaffApp.Data;

namespace StaffApp.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly StaffDb _context;

        public OrdersController(StaffDb context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = _context.Orders.Include(o => o.Invoices)
                                            .ThenInclude(i => i.Staff)
                                         .Include(o => o.Invoices.User)
                                         .Include(o => o.Products);
            return View(await orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Invoices)
                .Include(o => o.Products)
                .Include(o => o.Invoices.Staff)
                .Include(o => o.Invoices.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", order.InvoiceId);
            ViewData["ProductId"] = new SelectList(_context.Products, "id", "Description", order.ProductId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Quantity,Cost,InvoiceId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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

            //TODO: send updated order to orders api

            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", order.InvoiceId);
            ViewData["ProductId"] = new SelectList(_context.Products, "id", "Description", order.ProductId);
            return View(order);
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }

        // GET: Orders/ViewInvoice/5
        public async Task<IActionResult> ViewInvoice(int? invoiceId)
        {
            var order = await _context.Orders
                .Include(o => o.Invoices)
                .Include(o => o.Products)
                .Include(o => o.Invoices.Staff)
                .Include(o => o.Invoices.User)
                .FirstOrDefaultAsync(m => m.InvoiceId == invoiceId);

            return View(order);
        }
    }
}
