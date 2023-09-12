namespace ProductMgmt.Core
{
    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryCode { get; set; }
    }
}