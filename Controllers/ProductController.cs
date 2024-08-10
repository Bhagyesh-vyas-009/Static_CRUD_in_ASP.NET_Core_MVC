using Microsoft.AspNetCore.Mvc;
using Static_CRUD.Models;

namespace Static_CRUD.Controllers
{
    public class ProductController : Controller
    {
        public static List<ProductModel> products = new List<ProductModel>
        { 
            new ProductModel{ProductID=1,ProductName="Pen",ProductPrice=10,ProductCode="001",Description="Ball Pen",UserID=1},
            new ProductModel{ProductID=2,ProductName="Notebook",ProductPrice=50,ProductCode="011",Description="NoteBook",UserID=3},
            new ProductModel { ProductID = 3, ProductName = "Pen", ProductPrice = 10, ProductCode = "001", Description = "Ball Pen", UserID = 1 },
        };
        [Route("/")]
        public IActionResult ProductList()
        {
            return View(products);
        }


        public IActionResult ProductAddEdit(int id)
        {
            if (id > 0)
            {
                ProductModel product = products.Find(p => p.ProductID == id);
                return View(product);
            }
            return View();
        }
        
        public IActionResult ProductAdd(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                productModel.ProductID = products.Max(p => p.ProductID) + 1;
                products.Add(productModel);
                return RedirectToAction("ProductList", products);
            }
            else
            {
                return RedirectToAction("ProductAddEdit");
            }
        }

        public IActionResult ProductEdit(ProductModel pm)
        {
            if (ModelState.IsValid)
            {
                var id = pm.ProductID;
                ProductModel product = products.FirstOrDefault(p => p.ProductID == id);
                products.Remove(product);
                products.Add(pm);
                products = products.OrderBy(p => p.ProductID).ToList();
                return RedirectToAction("ProductList", products);
            }
            else
                return RedirectToAction("ProductAddEdit");
        }

        public IActionResult ProductDelete(int id)
        {
            ProductModel product = products.FirstOrDefault(p => p.ProductID == id);
            products.Remove(product);
            return RedirectToAction("ProductList", products);
        }
    }
}
