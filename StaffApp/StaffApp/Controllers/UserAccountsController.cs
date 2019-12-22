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
    public class UserAccountsController : Controller
    {
        private readonly StaffDb _context;

        public UserAccountsController(StaffDb context)
        {
            _context = context;
        }

        // GET: UserAccounts
        public async Task<IActionResult> Index()
        {
            var staffDb = _context.UserAccounts.Include(u => u.Permission)
                .Where(u => u.Active)
                .OrderBy(u => u.Surname);
            return View(await staffDb.ToListAsync());
        }

        // GET: UserAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccounts
                .Include(u => u.Permission)
                .FirstOrDefaultAsync(m => m.Id == id && m.Active);
            if (userAccount == null)
            {
                return NotFound();
            }

            return View(userAccount);
        }

        // GET: UserAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }
            ViewData["PermissionsId"] = new SelectList(_context.Permissions, "Id", "Id", userAccount.PermissionsId);
            //ViewData["PermissionsId"] = _context.Permissions.FirstOrDefaultAsync(p => p.Id == 9);
            return View(userAccount);
        }

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Surname,Forename,Email,PermissionsId,Active")] UserAccount userAccount)
        {
            if (id != userAccount.Id)
            {
                return NotFound();
            }

            if(userAccount.PermissionsId != 9 && userAccount.PermissionsId != 10)
            {
                return View("IncorrectPermission");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccountExists(userAccount.Id))
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
            ViewData["PermissionsId"] = new SelectList(_context.Permissions, "Id", "Id", userAccount.PermissionsId);
            return View(userAccount);
        }

        // GET: UserAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccounts
                .Include(u => u.Permission)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return View(userAccount);
        }

        // POST: UserAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAccount = await _context.UserAccounts.FindAsync(id);

            userAccount.Forename = "#####";
            userAccount.Surname = "#######";
            userAccount.Email = "########";
            userAccount.Active = false;

            _context.UserAccounts.Update(userAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAccountExists(int id)
        {
            return _context.UserAccounts.Any(e => e.Id == id);
        }

        // GET: UserAcoounts/CustomerOrders/5
        public async Task<IActionResult> CustomerOrders(int id)
        {
            var orders = await _context.Orders
                .Include(o => o.Products)
                .Include(o => o.Invoices)
                .ThenInclude(o => o.Staff)
                .Where(o => o.Invoices.UserAccountId == id)
                .ToListAsync();

            if(orders.Count() == 0)
            {
                return View("NoOrders");
            }

            return View(orders);
        }

        // GET: UserAccounts/CustomerReviews/5
        public async Task<IActionResult> CustomerReviews(int id)
        {
            var reviews = await _context.Reviews
                .Include(r => r.Products)
                .Where(r => r.UserAccountId == id)
                .ToListAsync();

            if(reviews.Count() == 0)
            {
                return View("NoReviews");
            }

            return View(reviews);
        }

        // GET: UserAccounts/EditReview/5
        public async Task<IActionResult> EditReview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            ViewData["UserAccountId"] = new SelectList(_context.UserAccounts, "Id", "Id", review.UserAccountId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", review.ProductId);
            return View(review);
        }

        // POST: UserAccounts/EditReview/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReview(int id, [Bind("Id,Rating,Description,Hidden,ProductId,UserAccountId")] Reviews review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccountExists(review.Id))
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
            ViewData["UserAccountId"] = new SelectList(_context.UserAccounts, "Id", "Id", review.UserAccountId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", review.ProductId);
            return View(review);
        }
    }
}
