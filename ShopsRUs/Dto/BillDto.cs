using System.Collections.Generic;
using System.Linq;
using ShopsRUs.Models;

namespace ShopsRUs.Dto
{
    public class BillDto
    {
        public long CustomerId { get; set; }
        public List<BillProductDto> Products { get; set; }

        public BillDto() { }

        public BillDto(long customerId, List<BillProductDto> products)
        {
            CustomerId = customerId;
            Products = products;
        }

        public Bill ToModel(Customer customer)
        {
            return new Bill(
                customer,
                Products.Sum(row => row.Price),
                Products.Select(dto => dto.ToModel()).ToList()
            );
        }
    }
}