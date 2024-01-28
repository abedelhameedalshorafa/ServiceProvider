using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ServiceProvider.Context;
using ServiceProvider.Models;
using System.Security.Cryptography;
using static NuGet.Packaging.PackagingConstants;

namespace ServiceProvider.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ApplicationContext _db;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CustomerController(ApplicationContext db, IWebHostEnvironment environment)
        {
            _db = db;
            webHostEnvironment = environment;
        }


        ///////// Index Section ///////////////

        public IActionResult Index()
        {
            var serviceItems = _db.serviceItems
                .Include(si => si.Service)
                .Take(6)
                .ToList();

            return View(serviceItems);
        }


        ///////// About Section ///////////////

        public IActionResult About()
        {
            var webFeedbacks = _db.feedbackForWebs
                .Include(w => w.Customer)
                .Where(w => w.Status == feedbackStatus.Accepted)
                .ToList();

            return View(webFeedbacks);
        }


        public IActionResult Contact()
        {
            return View();
        }

        ///////// Service and serviceItems Sections ///////////////

        public IActionResult Services()
        {
            var services = _db.services
                .Include(s => s.ServiceItems)
                .ToList();

            return View(services);
        }


        [ActionName("ServiceItems")]
        public IActionResult GetServiceItemsByServiceId(int id)
        {
            var serviceItems = _db.serviceItems
                .Include(s => s.Service)
                .Include(s => s.Providers)
                .Where(s => s.serviceID == id)
                .ToList();

            return View(serviceItems);
        }

        [ActionName("AllServiceItems")]
        public IActionResult GetAllServiceItems()
        {
            var serviceItems = _db.serviceItems
                .Include(s => s.Service)
                .Include(s => s.Providers)
                .ToList();

            return View(serviceItems);
        }


        [ActionName("ItemDetails")]
        public IActionResult ServiceItemDetails(int ID)
        {
            var serviceItem = _db.serviceItems
                .Include(s => s.Service)
                .FirstOrDefault(s => s.ID == ID);

            return View(serviceItem);
        }

        ///// providerShowing Section/////


        [ActionName("ShowProviders")]
        public IActionResult GetProvidersByItemID(int id)
        {
            var providers = _db.providers
                .Include(p => p.ServiceItem)
                .Where(p => p.serviceID == id && p.IsSubscriptionActive == true && p.IsActive == true)
                .ToList();

            return View(providers);
        }

        public IActionResult ProviderDetails(int id)
        {
            var provider = _db.providers
                .Include(p => p.FeedbackForProviders.Where(f => f.Status == feedbackStatus.Accepted))
                .ThenInclude(f => f.Customer)
                .SingleOrDefault(p => p.ID == id);

            return View(provider);
        }



        ///// Orders Section/////

        public IActionResult AddToOrders(int ID)//where he go after add to orders
        {
            TempData.Remove("ReturnUrl");
            string? customerJson = HttpContext.Session.GetString("LiveCustomer");
            if (customerJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("AddToOrders", "Customer", new { id = ID });
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);
                if (customer is not null)
                {
                    var order = new Order();
                    order.Date = DateTime.Now;
                    order.customerID = customer.ID;
                    order.providerID = ID;
                    _db.orders.Add(order);
                    _db.SaveChanges();
                    TempData["success"] = "Added order successfully";
                    return RedirectToAction("Orders");
                }
                return RedirectToAction("Orders");
            }

        }

        public IActionResult Orders()
        {
            TempData.Remove("ReturnUrl");
            string? customerJson = HttpContext.Session.GetString("LiveCustomer");
            if (customerJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("Orders", "Customer");
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);
                if (customer is not null)
                {
                    var orders = _db.orders
                    .Include(o => o.Customer)
                    .Include(o => o.Provider)
                    .Where(o => o.customerID == customer.ID && o.status != orderStatus.Archived)//from Session
                    .ToList();
                    // here the status of order must be editted
                    return View(orders);
                }
                return View();
            }

        }

        public IActionResult DeleteOrder(int id)
        {
            var order = _db.orders.Find(id);
            if (order.status == orderStatus.Pending)
            {
                order.status = orderStatus.Archived;
                _db.orders.Update(order);
                _db.SaveChanges();

                TempData["success"] = "Order Deleted Sccessfully And Deleted From Provider Also  ";
                return RedirectToAction("Orders");
            }
            else
            {
                TempData["error"] = "Sorry , You Can't Delete Order Because The provider Aproved It ";
                return RedirectToAction("Orders");
            }
        }


        ///////////// for profile ///////////////////////

        [ActionName("CustomerProfile")]
        public IActionResult Profile()
        {
            TempData.Remove("ReturnUrl");
            string? customerJson = HttpContext.Session.GetString("LiveCustomer");
            if (customerJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("Profile", "Customer");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var customerFromSession = JsonConvert.DeserializeObject<Customer>(customerJson);
                if (customerFromSession is not null)
                {
                    var customer = _db.customers.Find(customerFromSession.ID);
                    return View(customer);
                }
                return View();
            }
        }

        [HttpPost]
        [ActionName("CustomerProfile")]
        public IActionResult Profile(Customer customer)
        {

            if (customer.ImageFile != null)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "" +
                customer.ImageFile.FileName;
                string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    customer.ImageFile.CopyTo(fileStream);
                }
                customer.ImageUrl = "/Images/" + fileName;
            }


            _db.customers.Update(customer);
            _db.SaveChanges();
            TempData["success"] = "Update Profile successfully";
            return View(customer);
        }



        ///////////// for providers page///////////////////////


        public IActionResult Subscriptions()
        {
            string? providerJson = HttpContext.Session.GetString("LiveProvider");
            if (providerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var provider = JsonConvert.DeserializeObject<Provider>(providerJson);
                if (provider is not null && provider.IsActive)
                {
                    var subscriptions = _db.subscriptions
                    .Include(s => s.Provider)
                    .Where(s => s.providerID == provider.ID && s.flagfordelete == false)
                    .ToList();
                    return View(subscriptions);
                }
                TempData["error"] = "Must Accepted By Admin";
                return RedirectToAction("Index");
            }
        }

        public IActionResult DeleteSubscription(int id)
        {
            var subscription = _db.subscriptions.Find(id);
            if (subscription is not null)
            {
                subscription.flagfordelete = true;

                _db.subscriptions.Update(subscription);
                _db.SaveChanges();
                TempData["success"] = "remove subscription successfully";
                return RedirectToAction("Subscriptions");
            }

            TempData["error"] = "remove subscription failed";
            return RedirectToAction("Subscriptions");

        }

        [ActionName("PaySubscription")]
        public IActionResult SubscriptionForPaying()
        {
            string? providerJson = HttpContext.Session.GetString("LiveProvider");
            if (providerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
                return View();
        }


        [ActionName("PaySubscription")]
        [HttpPost]
        public IActionResult SubscriptionForPaying(Subscription subscription)
        {
            string? providerJson = HttpContext.Session.GetString("LiveProvider");
            var provider = JsonConvert.DeserializeObject<Provider>(providerJson);
            if (provider is not null && provider.IsActive)
            {
                subscription.providerID = provider.ID;//// from session
                subscription.paymentDate = DateTime.Now;
                subscription.paymentAmount = subscription.numberOfMonths * provider.MonthlyPrice;
                var payments = _db.payments.ToList();
                foreach (var item in payments)
                {
                    if (item.cardNo == subscription.cardNumber && item.Password == subscription.cardPassword)
                    {
                        if (!provider.IsSubscriptionActive)
                        {
                            provider.SubscriptionStartDate = DateTime.Now;
                            provider.SubscriptionEndDate = provider.SubscriptionStartDate.AddMonths(subscription.numberOfMonths);
                            provider.IsSubscriptionActive = true;
                        }
                        else
                        {
                            provider.SubscriptionEndDate = provider.SubscriptionEndDate.AddMonths(subscription.numberOfMonths);
                        }


                        subscription.startDate = provider.SubscriptionStartDate;
                        subscription.endDate = provider.SubscriptionEndDate;

                        _db.subscriptions.Add(subscription);
                        _db.providers.Update(provider);
                        _db.SaveChanges();

                        string updatedProviderJson = JsonConvert.SerializeObject(provider, new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

                        HttpContext.Session.SetString("LiveProvider", updatedProviderJson);

                        TempData["success"] = "Payment processed successfully";
                        return RedirectToAction("Subscriptions");
                    }
                    else
                    {
                        TempData["error"] = "Payment does't work";
                        return View();
                    }
                }

            }

            TempData["error"] = "Must Accepted By Admin To Pay Subscriptions";
            return RedirectToAction("Index");
        }


        [ActionName("Orders")]
        [HttpGet("Customer/Orders/{id}")]
        public IActionResult OrdersForProviders(int id)
        {
            string? providerJson = HttpContext.Session.GetString("LiveProvider");
            if (providerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var provider = JsonConvert.DeserializeObject<Provider>(providerJson);
                if (provider is not null && provider.IsActive)
                {
                    if (provider.IsSubscriptionActive)
                    {
                        var orders = _db.orders
                        .Include(o => o.Customer)
                        .Include(o => o.Provider)
                        .Where(o => o.providerID == provider.ID && o.status != orderStatus.Archived)
                        .ToList();
                        // here the status of order must be editted
                        return View(orders);
                    }
                    else
                    {
                        TempData["error"] = "Must Pay To Receive Orders";
                        return RedirectToAction("PaySubscription");
                    }
                }
                else
                {
                    TempData["error"] = "Must Accepted By Admin To Have Orders";
                    return RedirectToAction("Index");
                }

            }

        }

        public IActionResult AcceptOrder(int id)
        {
            string? providerJson = HttpContext.Session.GetString("LiveProvider");
            if (providerJson == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var order = _db.orders.SingleOrDefault(o => o.ID == id);
                order.status = orderStatus.Accepted;

                _db.orders.Update(order);
                _db.SaveChanges();
                TempData["success"] = "Accept Order successfully";
                return RedirectToAction("Orders", new { id = 1 });



            }

        }
        //delete order

        [ActionName("ProviderProfile")]
        public IActionResult Profilee()
        {

            string? providerJson = HttpContext.Session.GetString("LiveProvider");
            if (providerJson == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var providerFromSession = JsonConvert.DeserializeObject<Provider>(providerJson);
                var provider = _db.providers
                    .Include(p => p.ServiceItem)
                    .SingleOrDefault(p => p.ID == providerFromSession.ID);
                return View(provider);
            }
        }

        [ActionName("ProviderProfile")]
        [HttpPost]

        public IActionResult Profile(Provider provider)
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
            }


            _db.providers.Update(provider);
            _db.SaveChanges();
            return View(provider);
        }





        //here stopped complete tommorow the views must be editing


        ///////////// for logout///////////////////////
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LiveCustomer");
            HttpContext.Session.Remove("LiveProvider");

            TempData["success"] = "Logout Successfully";
            return RedirectToAction("Index");
        }



        ///////////// for feedbacks///////////////////////
        public IActionResult AddFeedbackForWeb()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFeedbackForWeb(string feedback)//rate
        {

            TempData.Remove("ReturnUrl");
            string? customerJson = HttpContext.Session.GetString("LiveCustomer");
            if (customerJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("About", "Customer");
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);
                var feedBackForWeb = new FeedbackForWeb();
                feedBackForWeb.customerID = customer.ID;
                feedBackForWeb.Text = feedback;
                _db.feedbackForWebs.Add(feedBackForWeb);
                _db.SaveChanges();
                TempData["success"] = "Added FeedBack successfully";
                return RedirectToAction("About");
            }
        }




        public IActionResult AddFeedbackForprovider()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFeedbackForProvider(string feedback, int ID)
        {

            TempData.Remove("ReturnUrl");
            string? customerJson = HttpContext.Session.GetString("LiveCustomer");
            if (customerJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("ProviderDetails", "Customer", new { id = ID });
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var customer = JsonConvert.DeserializeObject<Customer>(customerJson);
                var feedBackForProvider = new FeedbackForProvider();
                feedBackForProvider.customerID = customer.ID;
                feedBackForProvider.Text = feedback;
                feedBackForProvider.providerID = ID;
                _db.feedbackForProviders.Add(feedBackForProvider);
                _db.SaveChanges();
                TempData["success"] = "Added FeedBack successfully";
                return RedirectToAction("About");
            }
        }
    }
}
