using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomer();

            return View(customers);
            //return View(customers);
            // return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        }
        

        public ActionResult Details(int id)
        {
            
            var customerResult = GetCustomer().SingleOrDefault(customer => customer.Id == id);
            
            if (customerResult == null)
            {
                return HttpNotFound();
            } else
            {
               return View(customerResult);
            }
            //id.ToString());

        }

        private IEnumerable<Customer> GetCustomer()
        {
            var customers = new List<Customer>
            {
                new Customer {Name = "Joe Shmoe", Id = 1},
                new Customer {Name = "Jane Shmane", Id = 2}
            };

            return customers;
        }
    }
}