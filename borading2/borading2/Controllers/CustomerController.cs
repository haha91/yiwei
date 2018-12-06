using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using borading2.Models;

namespace borading2.Controllers
{
    public class CustomerController : Controller
    {
        private keyonbordingEntities4 db = new keyonbordingEntities4();
       
        // GET: Customer
        public ActionResult Index()
        {
            
            List<CustomerViewModel> customers = new List<CustomerViewModel>();
            var tempCustomers = db.Customers;
            foreach (var customer in tempCustomers)
            {
                customers.Add(new CustomerViewModel
                {
                    Id= customer.Id,
                    Name = customer.Name,
                    Address = customer.Address
                });
            }
           
           
            return View(customers);
        }

        public ActionResult CheckId(int id)
        {
           
            if (db.Customers.Find(id)!=null)
            {
                return Json("exist",JsonRequestBehavior.AllowGet);
            }

            return Json("pass", JsonRequestBehavior.AllowGet);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var customer = db.Customers.Find(id);
            var newCusotmerModel = new CustomerViewModel();
            newCusotmerModel.Id = customer.Id;
            newCusotmerModel.Name = customer.Name;
            newCusotmerModel.Address = customer.Address;
            
            return Json(newCusotmerModel,JsonRequestBehavior.AllowGet);
        }

        //public ActionResult fillCUsotmer(int id,string Cname,string address)
        
        //    var a = 1;
          //  return a;
        //}

    

      

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerViewModel customer)
        {
            //List<CustomerViewModel> customers = new List<CustomerViewModel>();
            //var tempCustomers = db.Customers;
            //foreach (var c in tempCustomers)
            //{
            //    customers.Add(new CustomerViewModel
            //    {
            //        Id = c.Id,
            //        Name = c.Name,
            //        Address = c.Address
            //    });
            //}
            //var count = customers.Count+1;

            int id = createId();

            if (ModelState.IsValid)
                {
               
                    var newCusotmer = new Customers
                    {
                        Id = id,
                        Name = customer.Name,
                        Address = customer.Address,
                    };
                    db.Customers.Add(newCusotmer);
                    db.SaveChanges();
                    return Json("success create", JsonRequestBehavior.AllowGet);

               
                   
                }
                // TODO: Add insert logic here

                return Json("data passing error");
            
          
        }

   
        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(CustomerViewModel customer)
        {
            Customers newCustomer = db.Customers.Find(customer.Id);
            try
            {   // TODO: Add update logic here
                if (newCustomer != null)
                {
                    newCustomer.Id = customer.Id;
                    newCustomer.Name = customer.Name;
                    newCustomer.Address = customer.Address;
                    db.SaveChanges();
                    return Json("success save");

                };

             
                return Json("unsave");

            }
            catch
            {
                return View();
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var customer = db.Customers.Find(id);
            try
            {
                if(customer != null)
                {
                    db.Customers.Attach(customer);
                    db.Customers.Remove(customer);
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
    }
}
