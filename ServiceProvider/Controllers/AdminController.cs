using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.DotNet.Scaffolding.Shared;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ServiceProvider.Context;
using ServiceProvider.Models;
using System.ComponentModel.Design;

namespace ServiceProvider.Controllers
{
    public class AdminController : Controller
    {

        private readonly ApplicationContext _db;
        private readonly IWebHostEnvironment webHostEnvironment;
        public AdminController(ApplicationContext db, IWebHostEnvironment environment)
        {
            _db = db;
            webHostEnvironment = environment;
        }

        public IActionResult Index()
        {
            ViewBag.totalCustomers = _db.customers.Where(c => c.Role == Role.Customer).Count();
            ViewBag.totalProviders = _db.providers.Count();
            ViewBag.totalProvidersNotAccept = _db.providers.Where(p => p.IsActive == false).Count();
            ViewBag.totalOrders = _db.orders.Where(o => o.status != orderStatus.Archived).Count();
            ViewBag.totalOrdersPending = _db.orders.Where(o => o.status == orderStatus.Pending).Count();
            ViewBag.todayOrders = _db.orders.Where(o => o.Date.Date == DateTime.Today).Count();
            ViewBag.totalRevenue = _db.subscriptions.Sum(s => s.paymentAmount);
            ViewBag.todayRevenue = _db.subscriptions.Where(s => s.paymentDate.Date == DateTime.Today).Sum(s => s.paymentAmount);

            var orders = _db.orders
                .Include(o => o.Provider)
                .Include(o => o.Customer)
                .Where(o => o.Date.Date == DateTime.Today)
                .ToList();

            return View(orders);
        }

        ////////////////////////////////      Providers                 //////////////////////////////

        public IActionResult Providers(int? id)
        {

            if (id == null)
            {
                var providers = _db.providers.ToList();
                return View(providers);
            }
            else
            {
                var providersJson = HttpContext.Session.GetString("ProvidersSearch");
                var providers = JsonConvert.DeserializeObject<List<Provider>>(providersJson) ?? new List<Provider>();

                HttpContext.Session.Remove("ProvidersSearch");
                return View(providers);
            }

        }

        public IActionResult ProviderSearch(string searchItem)
        {
            if (!string.IsNullOrEmpty(searchItem))
            {
                var providers = _db.providers
                    .Where(p => p.Name.ToLower().Contains(searchItem.ToLower()))
                    .ToList();

                if (providers.Count > 0)
                {
                    string providersJson = JsonConvert.SerializeObject(providers);
                    HttpContext.Session.SetString("ProvidersSearch", providersJson);
                    TempData["success"] = "Exists, Here The Providers You Search For Them";
                    return RedirectToAction("Providers", new { id = 1 });
                }
                else
                {
                    TempData["error"] = "Not Exists, There Are No Providers With This Name";
                    return RedirectToAction("Providers");
                }
            }
            else
            {
                TempData["error"] = "Please Fill The Input For Search";
                return RedirectToAction("Providers");
            }
        }

        public IActionResult ApproveProvider(int id)
        {
            var provider = _db.providers.Find(id);

            provider.IsActive = true;
            _db.providers.Update(provider);
            _db.SaveChanges();

            TempData["success"] = "Approved Provider Successfully";
            return RedirectToAction("Providers");
        }

        public IActionResult CancelProvider(int id)
        {
            var provider = _db.providers.Find(id);

            provider.IsActive = false;
            _db.providers.Update(provider);
            _db.SaveChanges();

            TempData["success"] = "Canceled Provider Successfully";
            return RedirectToAction("Providers");

        }

        public IActionResult AddProvider()
        {
            var items = _db.serviceItems.ToList();
            ViewBag.Items = items;
            return View();
        }

        [HttpPost]
        public IActionResult AddProvider(Provider provider)
        {
            var providers = _db.providers.ToList();
            bool check = false;
            foreach (var p in providers)
            {
                if (p.Email == provider.Email)
                    check = true;

            }
            if (!check)
            {
                if (provider.ImageFile != null)
                {
                    string wwwRootPath = webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "" +
                    provider.ImageFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        provider.ImageFile.CopyTo(fileStream);
                    }
                    provider.ImageUrl = "/Images/" + fileName;
                    provider.ImageFile = null;
                }

                provider.SubscriptionStartDate = DateTime.Now;
                provider.SubscriptionEndDate = DateTime.Now;
                provider.IsActive = true;

                _db.providers.Add(provider);
                _db.SaveChanges();



                TempData["success"] = "Added provider Successfully ";

                return RedirectToAction("Providers");
            }

            TempData["error"] = "The Email is Exists Try Another ";
            return RedirectToAction("AddProvider");
        }

        ////////////////////////////////      Customers                 //////////////////////////////
        public IActionResult Customers(int? id)
        {

            if (id == null)
            {
                var cusomers = _db.customers
                .Include(c => c.Orders)
                .Where(c => c.Role == Role.Customer)
                .ToList();

                return View(cusomers);
            }
            else
            {
                var customersJson = HttpContext.Session.GetString("CustomersSearch");
                var customers = JsonConvert.DeserializeObject<List<Customer>>(customersJson) ?? new List<Customer>();

                HttpContext.Session.Remove("CustomersSearch");

                customers = _db.customers
                    .Include(c => c.Orders)
                    .Where(c => customers.Select(cc => cc.ID).Contains(c.ID))
                    .ToList();

                return View(customers);
            }

        }

        public IActionResult DeleteCustomer(int id)
        {
            var customer = _db.customers.Find(id);

            _db.customers.RemoveRange(customer);
            _db.SaveChanges();

            TempData["success"] = "Deleted Customer Successfully";
            return RedirectToAction("Customers");
        }

        public IActionResult CustomerSearch(string searchItem)
        {
            if (!string.IsNullOrEmpty(searchItem))
            {
                var customers = _db.customers
                    .Where(c => c.Role == Role.Customer && c.Name.ToLower().Contains(searchItem.ToLower()))
                    .ToList();

                if (customers.Count > 0)
                {
                    string customerJson = JsonConvert.SerializeObject(customers);
                    HttpContext.Session.SetString("CustomersSearch", customerJson);
                    TempData["success"] = "Exists, Here The Customers You Search For Them";
                    return RedirectToAction("Customers", new { id = 1 });
                }
                else
                {
                    TempData["error"] = "Not Exists, There Are No customers With This Name";
                    return RedirectToAction("Customers");
                }
            }
            else
            {
                TempData["error"] = "Please Fill The Input For Search";
                return RedirectToAction("Customers");
            }
        }

        ////////////////////////////////      Services                 //////////////////////////////

        public IActionResult Services(int? id)
        {

            if (id == null)
            {
                var services = _db.services
                    .Include(s => s.ServiceItems)
                    .ToList();

                return View(services);
            }
            else
            {
                var servicesJson = HttpContext.Session.GetString("ServicesSearch");
                var services = JsonConvert.DeserializeObject<List<Service>>(servicesJson) ?? new List<Service>();

                HttpContext.Session.Remove("CustomersSearch");

                services = _db.services
                    .Include(c => c.ServiceItems)
                    .Where(c => services.Select(cc => cc.ID).Contains(c.ID))
                    .ToList();

                return View(services);
            }
            
        }

        [HttpGet]
        public IActionResult AddOrUpdateService(int? id)
        {
            var service = _db.services.Find(id);
            return View(service);
        }

        [HttpPost]
        public IActionResult AddOrUpdateService(Service service)
        {
            if (service.ImageFile != null)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "" + service.ImageFile.FileName;
                string path = Path.Combine(wwwRootPath + "/Images/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    service.ImageFile.CopyTo(fileStream);
                }

                service.ImageUrl = "/Images/" + fileName;
                service.ImageFile = null;
            }

            bool isUpdate = (service.ID != 0);

            if (isUpdate)
            {
                bool nameExists = _db.services.Any(s => s.ID != service.ID && s.Name.ToLower() == service.Name.ToLower());

                if (nameExists)
                {
                    TempData["error"] = "The Name already exists. Try Another.";
                    return RedirectToAction("UpdateService", new { id = service.ID });
                }

                _db.services.Update(service);
                TempData["success"] = "Updated Service Successfully.";
            }
            else
            {
                bool nameExists = _db.services.Any(s => s.Name.ToLower() == service.Name.ToLower());

                if (nameExists)
                {
                    TempData["error"] = "The Name already exists. Try Another.";
                    return RedirectToAction("AddService");
                }

                _db.services.Add(service);
                TempData["success"] = "Added Service Successfully.";
            }

            _db.SaveChanges();

            return RedirectToAction("Services");
        }

        public IActionResult ServiceSearch(string searchItem)
        {
            if (!string.IsNullOrEmpty(searchItem))
            {
                var services = _db.serviceItems
                    .Where(c => c.Name.ToLower().Contains(searchItem.ToLower()))
                    .ToList();

                if (services.Count > 0)
                {
                    string serviceJson = JsonConvert.SerializeObject(services);
                    HttpContext.Session.SetString("ServicesSearch", serviceJson);
                    TempData["success"] = "Exists, Here The Services You Search For Them";
                    return RedirectToAction("Services", new { id = 1 });
                }
                else
                {
                    TempData["error"] = "Not Exists, There Are No Services With This Name";
                    return RedirectToAction("Customers");
                }
            }
            else
            {
                TempData["error"] = "Please Fill The Input For Search";
                return RedirectToAction("Customers");
            }
        }





        private bool ContainsInOrder(string source, string search)
        {
            int sourceIndex = 0;
            foreach (char c in search)
            {
                int indexInSource = source.IndexOf(c, sourceIndex);
                if (indexInSource == -1)
                {
                    return false;
                }
                sourceIndex = indexInSource + 1;
            }
            return true;
        }
    }
}

