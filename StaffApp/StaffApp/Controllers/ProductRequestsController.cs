using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StaffApp.Data;
using StaffApp.Web.Models;
using StaffApp.Web.Services.ProductRequests;

namespace StaffApp.Web.Controllers
{
    public class ProductRequestsController : Controller
    {
        private readonly StaffDb _context;
        private readonly IProductRequestsService _productRequestsService;
        //private readonly ILogger _logger;

        public ProductRequestsController(StaffDb context,
                                         //ILogger logger,
                                         IProductRequestsService productRequestsService)
        {
            _context = context;
            _productRequestsService = productRequestsService;
            //_logger = logger;
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
            var product = _productRequestsService.GetProductRequestProducts(); //populate by getting the products from the 3rd party suppliers through product request api
            return View(product.Result);
        }

        // POST: ProductRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Quantity")] ProductRequestProductsDTO productRequest)
        {
            var product = _productRequestsService.GetProductRequestProducts();//Pull data from api again

            ProductRequest request = new ProductRequest
            {
                Confirmed = false,
                Quantity = productRequest.Quantity,
                ProductName = productRequest.Name,
                Price = product.Result.First(p => p.Name == productRequest.Name).Price
            };

            ProductRequestDTO requestAPI = new ProductRequestDTO
            {
                Confirmed = false,
                Quantity = productRequest.Quantity,
                ProductName = productRequest.Name,
                Price = product.Result.First(p => p.Name == productRequest.Name).Price
            };

            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
            }

            try
            {
                var response = _productRequestsService.PushProductRequest(requestAPI);
            }
            catch (Exception e)
            {
                //_logger.LogWarning(e);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProductRequestExists(int id)
        {
            return _context.ProductRequests.Any(e => e.Id == id);
        }
    }
}
