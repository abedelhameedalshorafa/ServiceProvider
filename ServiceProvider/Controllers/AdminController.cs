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
            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ViewBag.totalCustomers = _db.customers.Where(c => c.Role == Role.Customer && c.ForDelete==false).Count();
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
            }
        }

        ////////////////////////////////      Providers                 //////////////////////////////

        public IActionResult Providers(string show)
        {
            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    if (show == null)
                    {
                        var providers = _db.providers.ToList();
                        return View(providers);
                    }
                    else if (show == "Search")
                    {
                        var providersJson = HttpContext.Session.GetString("ProvidersSearch");
                        var providers = JsonConvert.DeserializeObject<List<Provider>>(providersJson) ?? new List<Provider>();

                        HttpContext.Session.Remove("ProvidersSearch");
                        return View(providers);
                    }
                    else
                    {
                        var providersJson = HttpContext.Session.GetString("ProvidersByItemId");
                        var providers = JsonConvert.DeserializeObject<List<Provider>>(providersJson) ?? new List<Provider>();

                        HttpContext.Session.Remove("ProvidersByItemId");
                        return View(providers);
                    }
                }
            }
        }

        public IActionResult ProviderSearch(string searchItem)
        {
            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
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
                            return RedirectToAction("Providers", new { show = "Search" });
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
            }
        }

        public IActionResult ApproveProvider(int id)
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    var provider = _db.providers.Find(id);

                    provider.IsActive = true;
                    _db.providers.Update(provider);
                    _db.SaveChanges();

                    TempData["success"] = "Approved Provider Successfully";
                    return RedirectToAction("Providers");
                }
            }
        }

        public IActionResult CancelProvider(int id)
        {
            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    var provider = _db.providers.Find(id);

                    provider.IsActive = false;
                    _db.providers.Update(provider);
                    _db.SaveChanges();

                    TempData["success"] = "Canceled Provider Successfully";
                    return RedirectToAction("Providers");
                }
            }

        }

        public IActionResult AddProvider()
        {
            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    var items = _db.serviceItems.ToList();
                    ViewBag.Items = items;
                    return View();
                }
            }
        }

        [HttpPost]
        public IActionResult AddProvider(Provider provider)
        {
            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
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
            }
        }

        ////////////////////////////////      Customers                 //////////////////////////////
        public IActionResult Customers(int? id)
        {
            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {

                    if (id == null)
                    {
                        var cusomers = _db.customers
                        .Include(c => c.Orders)
                        .Where(c => c.Role == Role.Customer && c.ForDelete==false)
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
                            .Where(c => customers.Select(cc => cc.ID).Contains(c.ID)&& c.ForDelete==false)
                            .ToList();

                        return View(customers);
                    }
                }
            }

        }

        public IActionResult DeleteCustomer(int id)
        {
            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {

                    var customerr = _db.customers.Find(id);

                    customerr.ForDelete = true;
                    _db.customers.Update(customerr);
                    _db.SaveChanges();

                    TempData["success"] = "Deleted Customer Successfully";
                    return RedirectToAction("Customers");
                }
            }
        }

        public IActionResult CustomerSearch(string searchItem)
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {

                    if (!string.IsNullOrEmpty(searchItem))
                    {
                        var customers = _db.customers
                            .Where(c => c.Role == Role.Customer && c.Name.ToLower().Contains(searchItem.ToLower()))
                            .ToList();

                        if (customers.Count > 0)
                        {
                            string customersJson = JsonConvert.SerializeObject(customers);
                            HttpContext.Session.SetString("CustomersSearch", customersJson);
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
            }
        }

        ////////////////////////////////      Services                 //////////////////////////////

        public IActionResult Services(int? id)
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
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

                        HttpContext.Session.Remove("ServicesSearch");

                        services = _db.services
                            .Include(c => c.ServiceItems)
                            .Where(c => services.Select(cc => cc.ID).Contains(c.ID))
                            .ToList();

                        return View(services);
                    }
                }
            }

        }

        [HttpGet]
        public IActionResult AddOrUpdateService(int? id)
        {
            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    var service = _db.services.Find(id);
                    return View(service);
                }
            }
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
                    return RedirectToAction("AddOrUpdateService", new { id = service.ID });
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
                    return RedirectToAction("AddOrUpdateService");
                }

                _db.services.Add(service);
                TempData["success"] = "Added Service Successfully.";
            }

            _db.SaveChanges();

            return RedirectToAction("Services");
        }

        public IActionResult ServiceSearch(string searchItem)
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {

                    if (!string.IsNullOrEmpty(searchItem))
                    {
                        var services = _db.services
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
                            return RedirectToAction("Services");
                        }
                    }
                    else
                    {
                        TempData["error"] = "Please Fill The Input For Search";
                        return RedirectToAction("Services");
                    }
                }
            }
        }

        public IActionResult ShowItems(int id)
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {

                    var items = _db.serviceItems
                .Where(i => i.serviceID == id)
                .ToList();

                    if (items.Count > 0)
                    {
                        string itemJson = JsonConvert.SerializeObject(items);
                        HttpContext.Session.SetString("ItemsByServiceID", itemJson);
                        TempData["success"] = "Exists, Here The items i this service";
                        return RedirectToAction("ServiceItems", new { show = "ByServiceId" });
                    }

                    else
                    {
                        TempData["error"] = "There Are No Items For This Service";
                        return RedirectToAction("Services");
                    }
                }
            }
        }


        ////////////////////////////////      ServicesItem                 //////////////////////////////


        public IActionResult ServiceItems(string show)
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {

                    if (show == null)
                    {
                        var serviceItems = _db.serviceItems
                        .Include(c => c.Service)
                        .Include(c => c.Providers)
                        .ToList();

                        return View(serviceItems);
                    }
                    else if (show == "Search")
                    {
                        var itemJson = HttpContext.Session.GetString("ItemsSearch");
                        var items = JsonConvert.DeserializeObject<List<ServiceItem>>(itemJson) ?? new List<ServiceItem>();

                        HttpContext.Session.Remove("ItemsSearch");

                        items = _db.serviceItems
                            .Include(c => c.Service)
                            .Include(c => c.Providers)
                            .Where(c => items.Select(cc => cc.ID).Contains(c.ID))
                            .ToList();

                        return View(items);
                    }
                    else
                    {
                        var itemJson = HttpContext.Session.GetString("ItemsByServiceID");
                        var items = JsonConvert.DeserializeObject<List<ServiceItem>>(itemJson) ?? new List<ServiceItem>();

                        HttpContext.Session.Remove("ItemsByServiceID");

                        items = _db.serviceItems
                            .Include(c => c.Service)
                            .Include(c => c.Providers)
                            .Where(c => items.Select(cc => cc.ID).Contains(c.ID))
                            .ToList();

                        return View(items);
                    }
                }
            }

        }

        [HttpGet]
        public IActionResult AddOrUpdateItem(int? id)
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {

                    var item = _db.serviceItems.Find(id);

                    ViewBag.Services = _db.services.ToList();

                    return View(item);
                }
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdateItem(ServiceItem item)
        {
            if (item.ImageFile != null)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "" + item.ImageFile.FileName;
                string path = Path.Combine(wwwRootPath + "/Images/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    item.ImageFile.CopyTo(fileStream);
                }

                item.UrlImage = "/Images/" + fileName;
                item.ImageFile = null;
            }

            bool isUpdate = (item.ID != 0);

            if (isUpdate)
            {
                bool nameExists = _db.serviceItems.Any(s => s.ID != item.ID && s.Name.ToLower() == item.Name.ToLower());

                if (nameExists)
                {
                    TempData["error"] = "The Name already exists. Try Another.";
                    return RedirectToAction("UpdateService", new { id = item.ID });
                }

                _db.serviceItems.Update(item);
                TempData["success"] = "Updated Service Successfully.";
            }
            else
            {
                bool nameExists = _db.serviceItems.Any(s => s.Name.ToLower() == item.Name.ToLower());

                if (nameExists)
                {
                    TempData["error"] = "The Name already exists. Try Another.";
                    return RedirectToAction("AddService");
                }

                _db.serviceItems.Add(item);
                TempData["success"] = "Added Service Successfully.";
            }

            _db.SaveChanges();

            return RedirectToAction("ServiceItems");
        }

        public IActionResult ItemSearch(string searchItem)
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    if (!string.IsNullOrEmpty(searchItem))
                    {
                        var items = _db.serviceItems
                            .Where(c => c.Name.ToLower().Contains(searchItem.ToLower()))
                            .ToList();

                        if (items.Count > 0)
                        {
                            string itemJson = JsonConvert.SerializeObject(items);
                            HttpContext.Session.SetString("ItemsSearch", itemJson);
                            TempData["success"] = "Exists, Here The Items You Search For Them";
                            return RedirectToAction("ServiceItems", new { show = "Search" });
                        }
                        else
                        {
                            TempData["error"] = "Not Exists, There Are No Items With This Name";
                            return RedirectToAction("ServiceItems");
                        }
                    }
                    else
                    {
                        TempData["error"] = "Please Fill The Input For Search";
                        return RedirectToAction("ServiceItems");
                    }
                }
            }
        }

        public IActionResult ShowProviders(int id)
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {

                    var providers = _db.providers
                .Where(p => p.serviceID == id)
                .ToList();

                    if (providers.Count > 0)
                    {
                        string providersJson = JsonConvert.SerializeObject(providers);
                        HttpContext.Session.SetString("ProvidersByItemId", providersJson);
                        TempData["success"] = "Here The Providers In this Item ";
                        return RedirectToAction("Providers", new { show = "ByItemId" });
                    }
                    else
                    {
                        TempData["error"] = "There Are No Providers For This Item";
                        return RedirectToAction("ServiceItems");
                    }
                }
            }
        }


        ////////////////////////////////      Orders                 //////////////////////////////


        public IActionResult Orders()
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    var orders = _db.orders
                        .Include(o => o.Provider)
                        .Include(o => o.Customer)
                        .ToList();

                    return View(orders);
                }
            }
        }


        ////////////////////////////////      FeedbackForWeb                 //////////////////////////////
        ///

        public IActionResult FeedbacksForWeb()
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {

                    var webfeedbacks = _db.feedbackForWebs
                        .Include(w => w.Customer)
                        .Where(w => w.Status != feedbackStatus.Archived)
                        .ToList();

                    return View(webfeedbacks);
                }
            }
        }

        public IActionResult ApproveWebFeedback(int id)
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    var feedback = _db.feedbackForWebs.Find(id);

                    feedback.Status = feedbackStatus.Accepted;
                    _db.feedbackForWebs.Update(feedback);
                    _db.SaveChanges();

                    TempData["success"] = "Feedback Approved";
                    return RedirectToAction("FeedbacksForWeb");
                }
            }
        }

        public IActionResult DeleteWebFeedback(int id)
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    var feedback = _db.feedbackForWebs.Find(id);

                    feedback.Status = feedbackStatus.Archived;
                    _db.feedbackForWebs.Update(feedback);
                    _db.SaveChanges();

                    TempData["success"] = "Feedback Deleted";
                    return RedirectToAction("FeedbacksForWeb");
                }
            }
        }


        ////////////////////////////////      FeedbacksForProviders                 //////////////////////////////
        ///

        public IActionResult FeedbacksForProviders()
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    var providerfeedbacks = _db.feedbackForProviders
                        .Include(p => p.Customer)
                        .Include(p => p.Provider)
                        .Where(w => w.Status != feedbackStatus.Archived)
                        .ToList();

                    return View(providerfeedbacks);
                }
            }
        }

        public IActionResult ApproveProviderFeedback(int id)
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    var feedback = _db.feedbackForProviders.Find(id);
                    feedback.Status = feedbackStatus.Accepted;
                    _db.feedbackForProviders.Update(feedback);
                    _db.SaveChanges();

                    TempData["success"] = "Feedback Approved";
                    return RedirectToAction("FeedbacksForProviders");
                }
            }
        }

        public IActionResult DeleteProviderFeedback(int id)
        {

            string? customerJson = HttpContext.Session.GetString("LiveCustomer");

            if (customerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);

                if (customer.Role != Role.Admin)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    var feedback = _db.feedbackForProviders.Find(id);

                    feedback.Status = feedbackStatus.Archived;
                    _db.feedbackForProviders.Update(feedback);
                    _db.SaveChanges();

                    TempData["success"] = "Feedback Deleted";
                    return RedirectToAction("FeedbacksForProviders");
                }
            }
        }
    }
}

