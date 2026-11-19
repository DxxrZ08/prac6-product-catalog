using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product or Product/Index?category=Electronics
        public ActionResult Index(string category)
        {
            List<Product> all = GetProducts();

            ViewBag.Categories = all.Select(p => p.Category).Distinct().OrderBy(c => c).ToList();
            ViewBag.SelectedCategory = category;

            List<Product> products = string.IsNullOrEmpty(category)
                ? all
                : all.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();

            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product product = GetProducts().FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Laptop",     Description = "HP laptop",      Price = 60000,      Category = "Electronics", InStock = true  },
                new Product { ProductId = 2, ProductName = "Mobile",     Description = "Samsung Note 9", Price = 75000,      Category = "Electronics", InStock = true  },
                new Product { ProductId = 3, ProductName = "Headphones", Description = "Boat",           Price = 12000,      Category = "Accessories", InStock = true  },
                new Product { ProductId = 4, ProductName = "Batmobile",  Description = "Vehicle",        Price = 1200000000, Category = "Supercar",    InStock = false },
                new Product { ProductId = 5, ProductName = "Jet",        Description = "NetJets",        Price = 420000000,  Category = "Aircraft",    InStock = false }
            };
        }
    }
}
