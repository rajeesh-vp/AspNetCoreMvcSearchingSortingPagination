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
        public ActionResult Index(string sortBy, string sortOrder, string changeSortOrder, string searchString, int? pageNo, string filterChanged)
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

            if (changeSortOrder == "yes")
                sortOrder = sortOrder == null || sortOrder == "asc" ? "desc" : "asc";
            
            ViewData["currentSortOrder"] = sortOrder;
            ViewData["currentSortBy"] = sortBy;

            string sortByArg = string.IsNullOrEmpty(sortBy) || sortBy == "name" ? "name" : "category";
            bool sortByAscending = string.IsNullOrEmpty(sortOrder) || sortOrder == "asc" ? true : false;

            pageNo = pageNo ?? 1;

            ViewData["currentFilter"] = searchString;

            var products = ProductManager.GetPagedList(searchString, sortByArg, sortByAscending, pageNo ?? 1, 3);
            return View(products);
        }        
    }
}
