using System;

namespace PurchaseApp.API.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public ShippingInformationDto ShippingInformation { get; set; }
    }
}
