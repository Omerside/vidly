using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // Define the variable that will hold the DB for our application
        private ApplicationDbContext _context;

        public CustomersController()
        {
            // Reference our DB to the variable previously defined inside of the default constructor.
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            // override Dispose to dispose our assigned DB reference
            _context.Dispose();
        }
        
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
            //return View(customers);
            // return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        }
        

        public ActionResult Details(int id)
        {
            
            var customerResult = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(customer => customer.Id == id);
            
            if (customerResult == null)
            {
                return HttpNotFound();
            } else
            {
               return View(customerResult);
            }

        }

        /* This is what I did before setting up a database with Customer objects
        private IEnumerable<Customer> GetCustomer()
        {
                    
            var customers = new List<Customer>
            {
                new Customer {Name = "Joe Shmoe", Id = 1},
                new Customer {Name = "Jane Shmane", Id = 2}
            };
            

            return customers;
        }
        */
    }
}