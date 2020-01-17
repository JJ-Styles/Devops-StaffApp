using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StaffApp.Data;
using StaffApp.Web.Services;

namespace StaffApp.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly StaffDb _context;
        private readonly IOrdersService _ordersSevice;
        private readonly ILogger _logger;

        public OrdersController(StaffDb context,
                                IOrdersService ordersService,
                                ILogger logger)
        {
            _context = context;
            _ordersSevice = ordersService;
            _logger = logger;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = _context.Orders.Include(o => o.Invoices)
                                            .ThenInclude(i => i.Staff)
                                         .Include(o => o.Invoices.User)
                                         .Include(o => o.Products);
            return View(await orders.Where(o => o.DispatchDate == null).ToListAsync());
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
                .FirstOrDefaultAsync(m => m.Id == id && m.DispatchDate == null);

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
            if (order == null || order.DispatchDate != null)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Quantity,Cost,Dispatched,InvoiceId")] OrdersDTO order)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(i => i.Id == order.InvoiceId);
            if (id != order.Id)
            {
                return NotFound();
            }
            else if (!invoice.Invoiced)
            {
                return View("NotInvoiced");
            }

            order.DispatchDate = DateTime.Now;

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

            try
            {
                var savedOrder = await _ordersSevice.PushOrder(order);
                if (savedOrder.Id != order.Id)
                {
                    throw new System.Exception("Orders do not match");
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning("Exception Occured using Orders Service " + e);
                order = null;
            }

            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "Id", "Id", order.InvoiceId);
            ViewData["ProductId"] = new SelectList(_context.Products, "id", "Description", order.ProductId);
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrders([FromBody]ICollection<OrdersDTO> orders)
        {

            foreach (OrdersDTO order in orders)
            {
                if (!OrderExists(order.Id))
                {
                    await _context.AddAsync(order);
                }
            }

            return Ok();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }

        // GET: Orders/ViewInvoice/5
        public async Task<IActionResult> ViewInvoice(int? invoiceId)
        {
            if (invoiceId == null)
            {
                return NotFound();
            }

            var order = _context.Orders
                .Include(o => o.Invoices)
                .Include(o => o.Products)
                .Include(o => o.Invoices.Staff)
                .Include(o => o.Invoices.User)
                .Where(m => m.InvoiceId == invoiceId);

            return View(await order.ToListAsync());
        }

        // GET: Orders/EditInvoice/5
        public async Task<IActionResult> EditInvoice(int? invoiceId)
        {
            if (invoiceId == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices.FirstOrDefaultAsync(i => i.Id == invoiceId);

            return View(invoice);
        }

        // POST: Orders/EditInvoice/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInvoice(int id, [Bind("Id, Invoiced, StaffAccountId, UserAccountId")] Invoice invoice)
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
                return RedirectToAction(nameof(Index));
            }

            //TODO: send updated invoice to invoice api


            return View(invoice);
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
