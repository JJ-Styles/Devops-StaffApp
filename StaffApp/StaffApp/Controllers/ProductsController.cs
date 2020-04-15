using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StaffApp.Data;
using StaffApp.Web.Services.Products;

namespace StaffApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly StaffDb _context;
        private readonly IProductsService _productsService;
        //private readonly ILogger _logger;

        public ProductsController(StaffDb context,
                                  //ILogger logger,
                                  IProductsService productsService)
        {
            _context = context;
            _productsService = productsService;
            //_logger = logger;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = _context.Products;
            return View(await products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.PriceHistories.Include(p => p.product).OrderByDescending(p => p.EffectiveFrom).Where(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(await product.ToListAsync());
        }

        // GET: Products/CreateNewPrice/5
        public async Task<IActionResult> CreateNewPrice(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.PriceHistories.Include(p => p.product).OrderByDescending(p => p.EffectiveFrom).Where(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(await product.FirstOrDefaultAsync());
        }

        // POST: Products/CreateNewPrice/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNewPrice(int productId, [Bind("ProductId, Price")] PriceHistory newPrice)
        {
            if (productId != newPrice.ProductId)
            {
                return NotFound();
            }
            newPrice.EffectiveFrom = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(newPrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(newPrice.ProductId))
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

            PriceHistoriesDTO priceHistories = new PriceHistoriesDTO
            {
                Id = newPrice.Id,
                Price = newPrice.Price,
            };

            try
            {
                var response = await _productsService.PushPrice(priceHistories);
            }
            catch(Exception e)
            {
                //_logger.LogWarning(e);
            }

            return View(newPrice);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.id == id);
        }
    }
}
