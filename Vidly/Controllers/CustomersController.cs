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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            } else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

                //This method works but is automated and can open security flaws
                //TryUpdateModel(customerInDb);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
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