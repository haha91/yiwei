using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using borading2.Models;

namespace borading2.Controllers
{
    public class ProductSoldController : Controller
    {
        private keyonbordingEntities4 db = new keyonbordingEntities4();
        // GET: ProductSold
        public ActionResult Index()
        {

            List<ProductSoldViewModel> soldList = new List<ProductSoldViewModel>();
            var solds = db.ProductSold;

            foreach (var sold in solds)
            {

                soldList.Add(new ProductSoldViewModel
                {
                    Id = sold.Id,
                    ProductId = sold.Products.Id,
                    ProductName = sold.Products.Name,
                    CustomerId = sold.Customers.Id,
                    CustomerName = sold.Customers.Name,
                    StoreId = sold.Stores.Id,
                    StoreName = sold.Stores.Name,
                    soldDate = sold.DateSold.Value,


                });
            };



            return View(soldList);
        }

        public ActionResult Edit(int id)
        {
            var productSold = db.ProductSold.Find(id);
            var newProductSold = new ProductSoldViewModel();

            newProductSold.CustomerId = productSold.Customers.Id;
            newProductSold.CustomerName = productSold.Customers.Name;
            newProductSold.StoreId = productSold.Stores.Id;
            newProductSold.StoreName = productSold.Stores.Name;
            newProductSold.ProductId = productSold.Products.Id;
            newProductSold.ProductName = productSold.Products.Name;
            newProductSold.ProductList = getProductList();
            newProductSold.CustomerList = getCustomerList();
            newProductSold.StoreList = getStoreList();
            newProductSold.soldDate = productSold.DateSold.Value;


            return Json(newProductSold, JsonRequestBehavior.AllowGet);
        }

        public List<ProductVIewModel> getProductList()
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

            return newProductList;
        }

        public List<CustomerViewModel> getCustomerList()
        {
            List<CustomerViewModel> customers = new List<CustomerViewModel>();
            var tempCustomers = db.Customers;
            foreach (var customer in tempCustomers)
            {
                customers.Add(new CustomerViewModel
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Address = customer.Address
                });
            }

            return customers;

        }
        public List<StoreViewModel> getStoreList()
        {
            List<StoreViewModel> stores = new List<StoreViewModel>();
            var tempStores = db.Stores;
            foreach (var store in tempStores)
            {
                stores.Add(new StoreViewModel
                {
                    Id = store.Id,
                    Name = store.Name,
                    Address = store.Address
                });
            }
            return stores;

        }


        public ActionResult Save(ProductSoldViewModel productSold)
        {
            ProductSold newProduct = db.ProductSold.Find(productSold.Id);
            var i = productSold.ProductId;
            Products p = db.Products.Find(i);

            try
            {
                if (newProduct != null)
                {
                    newProduct.Id = productSold.Id;
                    newProduct.CustomerId = productSold.CustomerId;
                    newProduct.ProductId = productSold.ProductId;
                    newProduct.StoreId = productSold.StoreId;
                    newProduct.DateSold = productSold.soldDate;
                    db.SaveChanges();
                    return Json("success save");
                };
                return Json("Unfind");
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        [HttpPost]
        public ActionResult Create(ProductSoldViewModel productSold)
        {
            int id = createId();
            
                var newSold = new ProductSold
                {
                    Id = id,
                    CustomerId = productSold.CustomerId,
                    ProductId = productSold.ProductId,
                    StoreId = productSold.StoreId,
                    DateSold = productSold.soldDate
                };
                db.ProductSold.Add(newSold);
                db.SaveChanges();
                return Json("success create", JsonRequestBehavior.AllowGet);


        }

        public int createId()
        {
            Random rdn = new Random();
            int id = 0;
            Boolean exit = true;
            while (exit)
            {
                id = rdn.Next(1, 1000000);
                Products product = db.Products.Find(id);
                if (product == null)
                {
                    exit = false;
                }

            };
            Console.WriteLine(id);
            return id;
        }

        public ActionResult CreateInfo()
        {
            var soldInfo = new SoldInfoViewModel();
            soldInfo.CustomerList = getCustomerList();
            soldInfo.ProductList = getProductList();
            soldInfo.StoreList = getStoreList();

            return Json(soldInfo, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var soldProduct = db.ProductSold.Find(id);
            try
            {
                if (soldProduct != null)
                {
                    db.ProductSold.Attach(soldProduct);
                    db.ProductSold.Remove(soldProduct);
                    db.SaveChanges();
                    return Json("deleted sucess");

                }
                else
                {
                    return Json("unfinded");
                }


            }
            catch
            {
                return View();
            }
        }
    }
}