using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcSearchingSortingPagination.Domain
{
    public class ProductManager
    {
        private static List<Product> _products;
        public static void SetProducts()
        {
            _products = new List<Product>
            {
                new Product{ Id=new Guid(), Name ="Product1", Category = "Category3", Rate = 1000},
                new Product{ Id=new Guid(), Name ="Product2", Category = "Category3", Rate = 2000},
                new Product{ Id=new Guid(), Name ="Product3", Category = "Category3", Rate = 3000},

                new Product{ Id=new Guid(), Name ="Product4", Category = "Category2", Rate = 4000},
                new Product{ Id=new Guid(), Name ="Product5", Category = "Category2", Rate = 5000},
                new Product{ Id=new Guid(), Name ="Product6", Category = "Category2", Rate = 6000},

                new Product{ Id=new Guid(), Name ="Product7", Category = "Category1", Rate = 7000},
                new Product{ Id=new Guid(), Name ="Product8", Category = "Category1", Rate = 8000},
                new Product{ Id=new Guid(), Name ="Product9", Category = "Category1", Rate = 9000},
            };
        }
        public static List<SelectListItem> GetProductLookup()
        {
            return new List<SelectListItem>
            {
                new SelectListItem("Product1", "Product1"),
                new SelectListItem("Product2", "Product2"),
                new SelectListItem("Product3", "Product3"),
                new SelectListItem("Product4", "Product4"),
                new SelectListItem("Product5", "Product5"),
                new SelectListItem("Product6", "Product6"),
                new SelectListItem("Product7", "Product7"),
                new SelectListItem("Product8", "Product8"),
                new SelectListItem("Product9", "Product9"),
            };
        }
        public static List<Product> GetProducts(string name, string sortBy, bool sortByAscending)
        {
            var query = _products
                .Where(e => string.IsNullOrEmpty(name) ? true : e.Name == name).AsQueryable();

            if (sortBy == "name")
            {
                if (sortByAscending)
                    query = query.OrderBy(e => e.Name);
                else
                    query = query.OrderByDescending(e => e.Name);
            }
            else
            {
                if (sortByAscending)
                    query = query.OrderBy(e => e.Category);
                else
                    query = query.OrderByDescending(e => e.Category);
            }

            return query.ToList();
        }
    }
}

