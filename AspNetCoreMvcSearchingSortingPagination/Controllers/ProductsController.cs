using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMvcSearchingSortingPagination.Domain;

namespace AspNetCoreMvcSearchingSortingPagination.Controllers
{
    public class ProductsController : Controller
    {
        public ProductsController()
        {
            ProductManager.SetProducts();
        }
        public ActionResult Index(string sortBy, string sortOrder, string searchString)
        {
            var productLookup = ProductManager.GetProductLookup();
            foreach (var item in productLookup)
            {
                if (item.Text == searchString)
                    item.Selected = true;
                else
                    item.Selected = false;
            }
            ViewData["productLookup"] = productLookup;

            ViewData["sortOrderParm"] = sortOrder == null || sortOrder == "asc" ? "desc" : "asc";
            string sortByArg = string.IsNullOrEmpty(sortBy) || sortBy == "name" ? "name" : "category";
            bool sortByAscending = string.IsNullOrEmpty(sortOrder) || sortOrder == "asc" ? true : false;

            

            var products = ProductManager.GetProducts(searchString, sortByArg, sortByAscending);
            return View(products);
        }
    }
}
