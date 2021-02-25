using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserAddress:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string AddressDetail { get; set; }
        public string AddressName { get; set; }
    }
}
