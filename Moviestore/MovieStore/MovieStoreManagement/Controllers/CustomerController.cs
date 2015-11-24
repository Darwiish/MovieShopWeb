﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStoreGateWay;
using MovieStoreMVCDto;

namespace MovieStoreManagement.Controllers
{
    public class CustomerController : Controller
    {
        Facade fac = new Facade();
        public ActionResult Index()
        {
            return View(fac.GetCustomerGateway().ReadAll());
        }

         
         public ActionResult Orders(int Id)
         {
             return RedirectToAction("Index","Order", new { id = Id});
         }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer cus, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                fac.GetCustomerGateway().Add(cus);
                return RedirectToAction("Index");
            }
                return View();
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cus = fac.GetCustomerGateway().Get(id);
            return View(cus);
        }

        // POST: Customer/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer cus, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                fac.GetCustomerGateway().Edit(cus);
                return RedirectToAction("Index");
            }
            
                return View();
            
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cus = fac.GetCustomerGateway().Get(id);
            return View(cus);
        }

        // POST: Customer/Delete
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                fac.GetCustomerGateway().Delete(id);
                return RedirectToAction("Index");
            }
                return View();
            
        }
    }
}
