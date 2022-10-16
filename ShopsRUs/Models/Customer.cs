using System;
using ShopsRUs.Dto;
using ShopsRUs.Types;

namespace ShopsRUs.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public CustomerType CustomerType { get; set; }
        public DateTime RegisteredAt { get; set; }

        public Customer() { }

        public Customer(long id, CustomerType customerType, DateTime registeredAt)
        {
            Id = id;
            CustomerType = customerType;
            RegisteredAt = registeredAt;
        }

        public CustomerDto ToDto()
        {
            return new CustomerDto(Id, CustomerType, RegisteredAt);
        }
    }
}