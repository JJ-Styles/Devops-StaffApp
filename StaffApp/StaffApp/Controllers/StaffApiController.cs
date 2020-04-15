using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaffApp.Data;
using StaffApp.Web.Services.Orders;
using StaffApp.Web.Services.Invoices;
using StaffApp.Web.Services.ProductRequests;
using StaffApp.Web.Services.Accounts;
using StaffApp.Web.Services.Products;
using StaffApp.Web.Services.Reviews;

namespace StaffApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffApiController : ControllerBase
    {
        private readonly StaffDb _context;

        public StaffApiController(StaffDb context)
        {
            _context = context;
        }

        // pull out into api controllers
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

        [HttpPost]
        public async Task<IActionResult> AddInvoice([FromBody]ICollection<InvoicesDTO> invoices)
        {

            foreach (InvoicesDTO invoice in invoices)
            {
                if (!InvoiceExists(invoice.Id))
                {
                    await _context.AddAsync(invoice);
                }
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddProductRequests([FromBody]ICollection<ProductRequestDTO> productRequests)
        {

            foreach (ProductRequestDTO productRequest in productRequests)
            {
                if (!ProductRequestExists(productRequest.Id))
                {
                    await _context.AddAsync(productRequest);
                }
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAccounts([FromBody]ICollection<UserAccountsDTO> userAccounts)
        {

            foreach (UserAccountsDTO user in userAccounts)
            {
                if (!UserAccountExists(user.Id))
                {
                    await _context.AddAsync(user);
                }
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddStaffAccounts([FromBody]ICollection<StaffAccountsDTO> staffAccounts)
        {

            foreach (StaffAccountsDTO staff in staffAccounts)
            {
                if (!StaffAccountExists(staff.Id))
                {
                    await _context.AddAsync(staff);
                }
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPermissions([FromBody]ICollection<PermissionsDTO> permissions)
        {

            foreach (PermissionsDTO permis in permissions)
            {
                if (!PermissionExists(permis.Id))
                {
                    await _context.AddAsync(permis);
                }
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddProducts([FromBody]ICollection<ProductsDTO> products)
        {

            foreach (ProductsDTO product in products)
            {
                if (!ProductExists(product.Id))
                {
                    await _context.AddAsync(product);
                }
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddReviews([FromBody]ICollection<ReviewsDTO> reviews)
        {

            foreach (ReviewsDTO review in reviews)
            {
                if (!ReviewExists(review.Id))
                {
                    await _context.AddAsync(review);
                }
            }
            return Ok();
        }

        private bool ReviewExists(int id)
        {
            throw new NotImplementedException();
        }

        private bool ProductExists(object id)
        {
            throw new NotImplementedException();
        }

        private bool PermissionExists(int id)
        {
            throw new NotImplementedException();
        }

        private bool OrderExists(int id)
        {
            throw new NotImplementedException();
        }

        private bool InvoiceExists(int id)
        {
            throw new NotImplementedException();
        }

        private bool UserAccountExists(int id)
        {
            throw new NotImplementedException();
        }

        private bool StaffAccountExists(int id)
        {
            throw new NotImplementedException();
        }

        private bool ProductRequestExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
