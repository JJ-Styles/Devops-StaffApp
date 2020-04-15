using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StaffApp.Data;
using StaffApp.Web.Services.Invoices;

namespace StaffApp.Web.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly StaffDb _context;
        //private readonly ILogger _logger;
        private readonly IInvoicesService _invoicesService;

        public InvoicesController(StaffDb context,
                                IInvoicesService invoicesService
                                //,ILogger logger
                                )
        {
            _context = context;
            _invoicesService = invoicesService;
            //_logger = logger;
        }

        // GET: Invoices/Index/5
        public async Task<IActionResult> Index()
        {
            var invoices = await _context.Invoices
                                         .Include(i => i.Staff)
                                         .Include(i => i.User)
                                         .Where(i => !i.Invoiced).ToListAsync();
            return View(invoices);
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _context.Orders
               .Include(o => o.Invoices)
               .Include(o => o.Products)
               .Include(o => o.Invoices.Staff)
               .Include(o => o.Invoices.User)
               .Where(m => m.InvoiceId == id);

            return View(await order.ToListAsync());
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices.FirstOrDefaultAsync(i => i.Id == id);

            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Invoiced, StaffAccountId, UserAccountId")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            //need to alter the staff account to whoever invoiced it

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            InvoicesDTO invoices = new InvoicesDTO
            {
                 Id = invoice.Id,
                 Invoiced = invoice.Invoiced,
                 StaffAccountId = invoice.StaffAccountId,
                 UserAccountId = invoice.UserAccountId
            };

            try
            {
                var response = await _invoicesService.PushInvoices(invoices);
            }
            catch (Exception e)
            {
                //_logger.LogWarning(e);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}