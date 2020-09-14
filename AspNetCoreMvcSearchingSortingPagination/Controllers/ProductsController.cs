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
            //ViewData["SortOrderParm"] = "desc";
        }
        // GET: ProductsController
        public ActionResult Index(string sortBy, string sortOrder)
        {
            ViewData["sortOrderParm"] = sortOrder == null || sortOrder == "asc" ? "desc" : "asc";

            string sortByArg = string.IsNullOrEmpty(sortBy) || sortBy == "name" ? "name" : "category";
            bool sortByAscending = string.IsNullOrEmpty(sortOrder) || sortOrder == "asc" ? true : false;

            var products = ProductManager.GetProducts("", "", sortByArg, sortByAscending);
            return View(products);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
