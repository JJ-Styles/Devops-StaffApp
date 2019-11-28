using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StaffApp.Data
{
    public class StaffDbInitialiser
    {
        public static async Task SeedTestData(StaffDb context,
                                              IServiceProvider services)
        {
            var invoices = new List<Invoice>
            {
                
            };
            invoices.ForEach(i => context.Invoices.Add(i));

            await context.SaveChangesAsync();

            var permissions = new List<Permission>
            {
                
            };
            permissions.ForEach(p => context.Permissions.Add(p));

            await context.SaveChangesAsync();

            var priceHistories = new List<PriceHistory>
            {
                
            };
            priceHistories.ForEach(p => context.PriceHistories.Add(p));

            await context.SaveChangesAsync();

            var productRequests = new List<ProductRequest>
            {

            };
            productRequests.ForEach(p => context.ProductRequests.Add(p));

            await context.SaveChangesAsync();

            var staffAccounts = new List<StaffAccount>
            {

            };
            staffAccounts.ForEach(s => context.StaffAccounts.Add(s));

            await context.SaveChangesAsync();

            var userAccounts = new List<UserAccount>
            {

            };
            userAccounts.ForEach(u => context.UserAccounts.Add(u));

            await context.SaveChangesAsync();
        }
    }
}
