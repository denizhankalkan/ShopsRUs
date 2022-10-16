using ShopsRUs.Models;
using ShopsRUs.Types;

namespace ShopsRUs.Dto
{
    public class BillProductDto
    {
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public decimal Price { get; set; }

        public BillProductDto() { }

        public BillProductDto(string name, ProductType productType, decimal price)
        {
            Name = name;
            ProductType = productType;
            Price = price;
        }

        public BillProduct ToModel()
        {
            return new BillProduct(Name, ProductType, Price);
        }
    }
}