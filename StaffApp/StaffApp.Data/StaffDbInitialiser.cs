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
            var permissions = new List<Permissions>
            {
                new Permissions { CanAlterCustomers = true, CanAlterStaff = false, CanApproveDenyRequest = false, CanDeleteCustomers = true, CanHideReviews = true, CanOrder = false, CanOrderNewStock = true, CanSetResellPrice = true, CanViewCustomers = true, CanViewOrders = true},
                new Permissions { CanAlterCustomers = true, CanAlterStaff = false, CanApproveDenyRequest = false, CanDeleteCustomers = true, CanHideReviews = true, CanOrder = false, CanOrderNewStock = true, CanSetResellPrice = true, CanViewCustomers = true, CanViewOrders = false},
                new Permissions { CanAlterCustomers = true, CanAlterStaff = false, CanApproveDenyRequest = false, CanDeleteCustomers = true, CanHideReviews = true, CanOrder = false, CanOrderNewStock = true, CanSetResellPrice = true, CanViewCustomers = false, CanViewOrders = true},
                new Permissions { CanAlterCustomers = true, CanAlterStaff = false, CanApproveDenyRequest = false, CanDeleteCustomers = true, CanHideReviews = true, CanOrder = false, CanOrderNewStock = true, CanSetResellPrice = false, CanViewCustomers = true, CanViewOrders = true},
                new Permissions { CanAlterCustomers = true, CanAlterStaff = false, CanApproveDenyRequest = false, CanDeleteCustomers = true, CanHideReviews = true, CanOrder = false, CanOrderNewStock = false, CanSetResellPrice = true, CanViewCustomers = true, CanViewOrders = true},
                new Permissions { CanAlterCustomers = true, CanAlterStaff = false, CanApproveDenyRequest = false, CanDeleteCustomers = true, CanHideReviews = false, CanOrder = false, CanOrderNewStock = true, CanSetResellPrice = true, CanViewCustomers = true, CanViewOrders = true},
                new Permissions { CanAlterCustomers = true, CanAlterStaff = false, CanApproveDenyRequest = false, CanDeleteCustomers = false, CanHideReviews = true, CanOrder = false, CanOrderNewStock = true, CanSetResellPrice = true, CanViewCustomers = true, CanViewOrders = true},
                new Permissions { CanAlterCustomers = false, CanAlterStaff = false, CanApproveDenyRequest = false, CanDeleteCustomers = true, CanHideReviews = true, CanOrder = false, CanOrderNewStock = true, CanSetResellPrice = true, CanViewCustomers = true, CanViewOrders = true},
                new Permissions { CanAlterCustomers = false, CanAlterStaff = false, CanApproveDenyRequest = false, CanDeleteCustomers = false, CanHideReviews = false, CanOrder = true, CanOrderNewStock = false, CanSetResellPrice = false, CanViewCustomers = false, CanViewOrders = false}
            };
            permissions.ForEach(p => context.Permissions.Add(p));

            await context.SaveChangesAsync();

            var priceHistories = new List<PriceHistory>
            {
                new PriceHistory { Price = 2.25, EffectiveFrom = DateTime.Now},
                new PriceHistory { Price = 5.00, EffectiveFrom = DateTime.Now},
                new PriceHistory { Price = 5.48, EffectiveFrom = DateTime.Now},
                new PriceHistory { Price = 15.48, EffectiveFrom = DateTime.Now}
            };
            priceHistories.ForEach(p => context.PriceHistories.Add(p));

            await context.SaveChangesAsync();

            var products = new List<Product>
            {
                new Product { Description = "Poor quality fake faux leather cover loose enough to fit any mobile device.", Name = "Wrap It and Hope Cover", Price = priceHistories, StockLevel = 1 },
                new Product { Description = "Purchase you favourite chocolate and use the provided heating element to melt it into the perfect cover for your mobile device.", Name = "Chocolate Cover", Price = priceHistories, StockLevel = 0 },
                new Product { Description = "Lamely adapted used and dirty teatowel.  Guaranteed fewer than two holes.", Name = "Cloth Cover", Price = priceHistories, StockLevel = 6 },
                new Product { Description = "Especially toughen and harden sponge entirely encases your device to prevent any interaction.", Name = "Harden Sponge Case", Price = priceHistories, StockLevel = 2 },
                new Product { Description = "Place your device within the water-tight container, fill with water and enjoy the cushioned protection from bumps and bangs.", Name = "Water Bath Case", Price = priceHistories, StockLevel = 3 },
                new Product { Description = "Keep you smartphone handsfree with this large assembly that attaches to your rear window wiper (Hatchbacks only).", Name = "Smartphone Car Holder", Price = priceHistories, StockLevel = 8 },
                new Product { Description = "Keep your device on your arm with this general purpose sticky tape.", Name = "Sticky Tape Sport Armband", Price = priceHistories, StockLevel = 23 },
                new Product { Description = "Stengthen HB pencils guaranteed to leave a mark.", Name = "Real Pencil Stylus", Price = priceHistories, StockLevel = 5 },
                new Product { Description = "Coat your mobile device screen in a scratch resistant, opaque film.", Name = "Spray Paint Screen Protector", Price = priceHistories, StockLevel = 1 },
                new Product { Description = "For his or her sensory pleasure. Fits few known smartphones.", Name = "Rippled Screen Protector", Price = priceHistories, StockLevel = 5 },
                new Product { Description = "For an odour than lingers on your device.", Name = "Fish Scented Screen Protector", Price = priceHistories, StockLevel = 0 },
                new Product { Description = "Guaranteed not to conduct electical charge from your fingers.", Name = "Non-conductive Screen Protector", Price = priceHistories, StockLevel = 10 }
            };
            products.ForEach(p => context.Products.Add(p));

            await context.SaveChangesAsync();

            var productRequests = new List<ProductRequest>
            {
                new ProductRequest{ Price = 2.15, ProductName = "Real Pencil Stylus", Quantity = 8},
                new ProductRequest{ Price = 6.15, ProductName = "Spray Paint Screen Protector", Quantity = 1},
                new ProductRequest{ Price = 7.16, ProductName = "Non-conductive Screen Protector", Quantity = 6},
                new ProductRequest{ Price = 5.04, ProductName = "Fish Scented Screen Protector", Quantity = 4}
            };
            productRequests.ForEach(p => context.ProductRequests.Add(p));

            await context.SaveChangesAsync();

            var staffAccounts = new List<StaffAccount>
            {
                new StaffAccount{ Forename = "Samwise", Surname = "Gamgee", Permission = permissions[0]},
                new StaffAccount{ Forename = "Frodo", Surname = "Baggins", Permission = permissions[3]},
                new StaffAccount{ Forename = "Gandalf", Surname = "The Grey", Permission = permissions[1]},
                new StaffAccount{ Forename = "Aragorn", Surname = "Telcontar", Permission = permissions[5]},
                new StaffAccount{ Forename = "Legolas", Surname = "Greenleaf", Permission = permissions[4]},
                new StaffAccount{ Forename = "Gimli", Surname = "Son of Gloin", Permission = permissions[2]},
                new StaffAccount{ Forename = "Meriadoc", Surname = "Brandybuck", Permission = permissions[6]},
                new StaffAccount{ Forename = "Peregrin", Surname = "Took", Permission = permissions[7]}
            };
            staffAccounts.ForEach(s => context.StaffAccounts.Add(s));

            await context.SaveChangesAsync();

            var userAccounts = new List<UserAccount>
            {
                new UserAccount{ Forename = "Thorin", Surname = "Oakenshield", Email = "thorin.oakenshield@erebor.me", Permission = permissions [8]},
                new UserAccount{ Forename = "Fili", Surname = "Oakenshield", Email = "fili.oakenshield@erebor.me", Permission = permissions [8]},
                new UserAccount{ Forename = "Kili", Surname = "Oakenshield", Email = "kili.oakenshield@erebor.me", Permission = permissions [8]},
                new UserAccount{ Forename = "Balin", Surname = "Son of Fundin", Email = "balin.Fundin@erebor.me", Permission = permissions [8]},
                new UserAccount{ Forename = "Dwalin", Surname = "Son of Fundin", Email = "dwalin.Fundin@erebor.me", Permission = permissions [8]},
                new UserAccount{ Forename = "Oin", Surname = "Son of Groin", Email = "oin.groin@erebor.me", Permission = permissions [8]},
                new UserAccount{ Forename = "Dori", Surname = "Kingsman of Durin", Email = "dori.durin@erebor.me", Permission = permissions [8]},
                new UserAccount{ Forename = "Nori", Surname = "Kingsman of Durin", Email = "nori.durin@erebor.me", Permission = permissions [8]},
                new UserAccount{ Forename = "Bifur", Surname = "Dwarf of Khazad-dum", Email = "bifur.Khazad-dum@erebor.me", Permission = permissions [8]},
                new UserAccount{ Forename = "Gloin", Surname = "Son of Groin", Email = "gloin.groin@erebor.me", Permission = permissions [8]},
                new UserAccount{ Forename = "Bofur", Surname = "Dwarf of Khazad-dum", Email = "bofur.Khazad-dum@erebor.me", Permission = permissions [8]},
                new UserAccount{ Forename = "Bombur", Surname = "Dwarf of Khazad-dum", Email = "bombur.Khazad-dum@erebor.me", Permission = permissions [8]},
                new UserAccount{ Forename = "Ori", Surname = "Kingsman of Durin", Email = "ori.durin@erebor.me", Permission = permissions [8]},
                new UserAccount{ Forename = "Bilbo", Surname = "Baggins", Email = "bilbo.baggins@theshire.me", Permission = permissions [8]}
            };
            userAccounts.ForEach(u => context.UserAccounts.Add(u));

            await context.SaveChangesAsync();

            var orders = new List<Order>
            {
                new Order{ Products = products[0], Cost = 25.00, Quantity = 15},
                new Order{ Products = products[1], Cost = 15.15, Quantity = 7},
                new Order{ Products = products[2], Cost = 54.54, Quantity = 50},
                new Order{ Products = products[3], Cost = 68.46, Quantity = 70},
                new Order{ Products = products[4], Cost = 94.34, Quantity = 80}
            };
            orders.ForEach(o => context.Orders.Add(o));

            await context.SaveChangesAsync();

            var invoices = new List<Invoice>
            {
                new Invoice { Invoiced = false, Staff = staffAccounts[0]},
                new Invoice { Invoiced = true, Staff = staffAccounts[1]},
                new Invoice { Invoiced = false, Staff = staffAccounts[2]},
                new Invoice { Invoiced = true, Staff = staffAccounts[5]},
            };
            invoices.ForEach(i => context.Invoices.Add(i));

            await context.SaveChangesAsync();
        }
    }
}
