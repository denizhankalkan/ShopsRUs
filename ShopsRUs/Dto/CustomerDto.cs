using System;
using ShopsRUs.Models;
using ShopsRUs.Types;

namespace ShopsRUs.Dto
{
    public class CustomerDto
    {
        public long Id { get; set; }
        public CustomerType CustomerType { get; set; }
        public DateTime RegisteredAt { get; set; }

        public CustomerDto() { }

        public CustomerDto(long id, CustomerType customerType, DateTime registeredAt)
        {
            Id = id;
            CustomerType = customerType;
            RegisteredAt = registeredAt;
        }
    }
}