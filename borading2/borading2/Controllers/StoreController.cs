using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using borading2.Models;

namespace borading2.Controllers
{
    public class StoreController : Controller
    {
        private keyonbordingEntities4 db = new keyonbordingEntities4();

        // GET: Customer
        public ActionResult Index()
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


            return View(stores);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var store = db.Stores.Find(id);
            var NewStore = new StoreViewModel();
            NewStore.Id = store.Id;
            NewStore.Name = store.Name;
            NewStore.Address = store.Address;
        
            return Json(NewStore, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult fillCUsotmer(int id,string Cname,string address)

        //    var a = 1;
        //  return a;
        //}





        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(StoreViewModel store)
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

                var newStore = new Stores
                {
                    Id = id,
                    Name = store.Name,
                    Address = store.Address,
                };
                db.Stores.Add(newStore);
                db.SaveChanges();
                return Json("success create", JsonRequestBehavior.AllowGet);



            }
            // TODO: Add insert logic here

            return Json("data passing error");


        }


        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(StoreViewModel store)
        {
            Stores newStore = db.Stores.Find(store.Id);
            try
            {   // TODO: Add update logic here
                if (newStore != null)
                {
                    newStore.Id = store.Id;
                    newStore.Name = store.Name;
                    newStore.Address = store.Address;
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

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var store = db.Stores.Find(id);
            try
            {
                if (store != null)
                {
                    db.Stores.Attach(store);
                    db.Stores.Remove(store);
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
       
            return id;
        }
    }
}