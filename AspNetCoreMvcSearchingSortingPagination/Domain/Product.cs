using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcSearchingSortingPagination.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public string Category { get; set; }

    }
}
