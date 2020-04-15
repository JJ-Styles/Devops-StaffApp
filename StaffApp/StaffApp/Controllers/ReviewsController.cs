using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StaffApp.Data;
using StaffApp.Web.Services.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffApp.Web.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly StaffDb _context;
        private readonly IReviewsService _reviews;
        //private readonly ILogger _logger;

        public ReviewsController(StaffDb context,
                                 //ILogger logger,
                                 IReviewsService reviews)
        {
            _context = context;
            _reviews = reviews;
            //_logger = logger;
        }

        // GET: UserAccounts/CustomerReviews/5
        public async Task<IActionResult> Details(int UserId)
        {
            var reviews = await _context.Reviews
                .Include(r => r.Products)
                .Where(r => r.UserAccountId == UserId)
                .ToListAsync();

            if (reviews.Count() == 0)
            {
                return View("NoReviews");
            }

            return View(reviews);
        }

        // GET: UserAccounts/EditReview/5
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rating,Description,Hidden,ProductId,UserAccountId")] Reviews review)
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
                    if (!ReviewExists(review.Id))
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

            ReviewsDTO reviews = new ReviewsDTO
            {
                 Id = review.Id,
                 Description = review.Description,
                 Hidden = review.Hidden,
                 ProductId = review.ProductId,
                 Rating = review.Rating,
                 UserAccountId = review.UserAccountId
            };

            try
            {
                var response = await _reviews.PushReview(reviews); 
            }
            catch (Exception e)
            {
                //_logger.LogWarning(e);
            }

            ViewData["UserAccountId"] = new SelectList(_context.UserAccounts, "Id", "Id", review.UserAccountId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", review.ProductId);
            return View(review);
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
