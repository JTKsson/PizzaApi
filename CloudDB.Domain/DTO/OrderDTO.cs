using CloudDB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudDB.Domain.DTO
{
    public class OrderDTO
    {

        public class OrderCreateDTO
        {
            public ICollection<int> ProductIds { get; set; } = new List<int>();

        }

    }
}
