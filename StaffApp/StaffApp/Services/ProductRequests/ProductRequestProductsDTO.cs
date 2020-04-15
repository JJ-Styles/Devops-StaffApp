namespace StaffApp.Web.Services.ProductRequests
{
    public class ProductRequestProductsDTO : ServicesDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}