using CloudDB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudDB.Domain.DTO
{
    public class ProductGetDTO
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
    }
}
