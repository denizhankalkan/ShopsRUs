using ShopsRUs.Dto;
using ShopsRUs.Types;

namespace ShopsRUs.Models
{
    public class BillProduct
    {
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public decimal Price { get; set; }

        public BillProduct() { }

        public BillProduct(string name, ProductType productType, decimal price)
        {
            Name = name;
            ProductType = productType;
            Price = price;
        }

        public BillProductDto ToDto()
        {
            return new BillProductDto(Name, ProductType, Price);
        }
    }
}