using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StaffApp.Data;
using StaffApp.Web.Models;

namespace StaffApp.Web.Controllers
{
    public class ProductRequestsController : Controller
    {
        private readonly StaffDb _context;

        public ProductRequestsController(StaffDb context)
        {
            _context = context;
        }

        // GET: ProductRequests
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductRequests.ToListAsync());
        }

        // GET: ProductRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productRequest = await _context.ProductRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productRequest == null)
            {
                return NotFound();
            }

            return View(productRequest);
        }

        // GET: ProductRequests/Create
        public IActionResult Create()
        {
            var product = new List<ProductFromRequest> 
            { 
                new ProductFromRequest {Name = "Wrap It and Hope Cover", Price = 2.25},
                new ProductFromRequest {Name = "Non-conductive Screen Protector", Price = 5.00},
                new ProductFromRequest {Name = "Fish Scented Screen Protector", Price = 5.48},
                new ProductFromRequest {Name = "Rippled Screen Protector", Price = 15.48},
                new ProductFromRequest {Name = "Spray Paint Screen Protector", Price = 8.95},
                new ProductFromRequest {Name = "Real Pencil Stylus", Price = 10.53},
                new ProductFromRequest {Name = "Sticky Tape Sport Armband", Price = 15.40},
                new ProductFromRequest {Name = "Smartphone Car Holder", Price = 1.95},
                new ProductFromRequest {Name = "Water Bath Case", Price = 6.84},
                new ProductFromRequest {Name = "Harden Sponge Case", Price = 20.55},
                new ProductFromRequest {Name = "Cloth Cover", Price = 2.22},
                new ProductFromRequest {Name = "Chocolate Cover", Price = 3.45}   
            }; //populate by getting the products from the 3rd party suppliers through product request api

            var productRequest = new ProductRequestViewModel
            {
                Product = product
            };

            return View(productRequest);
        }

        // POST: ProductRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,Quantity")] ProductRequestViewModel productRequest)
        {
            var product = new List<ProductFromRequest>
            {
                new ProductFromRequest {Name = "Wrap It and Hope Cover", Price = 2.25},
                new ProductFromRequest {Name = "Non-conductive Screen Protector", Price = 5.00},
                new ProductFromRequest {Name = "Fish Scented Screen Protector", Price = 5.48},
                new ProductFromRequest {Name = "Rippled Screen Protector", Price = 15.48},
                new ProductFromRequest {Name = "Spray Paint Screen Protector", Price = 8.95},
                new ProductFromRequest {Name = "Real Pencil Stylus", Price = 10.53},
                new ProductFromRequest {Name = "Sticky Tape Sport Armband", Price = 15.40},
                new ProductFromRequest {Name = "Smartphone Car Holder", Price = 1.95},
                new ProductFromRequest {Name = "Water Bath Case", Price = 6.84},
                new ProductFromRequest {Name = "Harden Sponge Case", Price = 20.55},
                new ProductFromRequest {Name = "Cloth Cover", Price = 2.22},
                new ProductFromRequest {Name = "Chocolate Cover", Price = 3.45}
            }; //Pull data from api again

            ProductRequest request = new ProductRequest
            {
                Confirmed = false,
                Quantity = productRequest.Quantity,
                ProductName = productRequest.ProductName,
                Price = product.FirstOrDefault(p => p.Name == productRequest.ProductName).Price
            };

            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //TODO: send new request to Product Request Api

            return View(request);
        }

        private bool ProductRequestExists(int id)
        {
            return _context.ProductRequests.Any(e => e.Id == id);
        }
    }
}
