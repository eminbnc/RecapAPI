using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class OrderPayment : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public string Bank { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
