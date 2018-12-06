using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using borading2.Models;
using System.Diagnostics;

namespace borading2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private keyonbordingEntities4 db = new keyonbordingEntities4();
        public ActionResult Index()
        {
            List<ProductVIewModel> newProductList = new List<ProductVIewModel>();
            var products = db.Products;
       
            foreach (var product in products)
            {
                newProductList.Add(new ProductVIewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price


                });
            }

            return View(newProductList);
        }

        [HttpPost]
        public ActionResult Create(ProductVIewModel product)
        {
            int id = createId();
           // if (ModelState.IsValid)
           // {
               
                var newproduct = new Products
                {
                    Id = id,
                    Name = product.Name,
                    Price = product.Price
                };
                db.Products.Add(newproduct);
                db.SaveChanges();
                return Json("success save", JsonRequestBehavior.AllowGet);
           // }
            //return Json("the model " +
              //  "is not right");
        }

        public ActionResult Edit(int id)
        {

            var product = db.Products.Find(id);

            var productViewModel = new ProductVIewModel();
            productViewModel.Id = product.Id;
            productViewModel.Name = product.Name;
            productViewModel.Price = product.Price;
            return Json(productViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public ActionResult Edit(ProductVIewModel product)
        {
            Products newproduct = db.Products.Find(product.Id);
            if (newproduct != null)
            {
                newproduct.Id = product.Id;
                newproduct.Name = product.Name;
                newproduct.Price = product.Price;
                db.SaveChanges();
            };

            return Json("success save");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            //db.ProductSolds.Any(x => x.ProductId == id);


            if (product != null)
            {//product 因为已经引用了所以可以直接使用
                if (!product.ProductSold.Any())
                {
                    db.Products.Attach(product);
                    db.Products.Remove(product);
                    db.SaveChanges();

                }
                else
                {
                    return Json("you can not delete this product becuase the products still at the productSold");
                }


            }
            else
            {
                return Json("can not find the Products");
            }
            return Json("success Deleted");
        }

        public int createId()
        {
            Random rdn = new Random();
            int id=0;
            Boolean exit = true;
            while (exit)
            {
                id = rdn.Next(1, 1000000);
                Products product = db.Products.Find(id);
                if(product == null)
                {
                    exit = false;
                }

            };
            Console.WriteLine(id);
            return id;
        }
    }

}
