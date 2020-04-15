namespace StaffApp.Web.Services.ProductRequests
{
    public class ProductRequestDTO : ServicesDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool Confirmed { get; set; }
    }
}