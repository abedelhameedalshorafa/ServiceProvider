using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ServiceProvider.Context;
using ServiceProvider.Models;
using System;

namespace ServiceProvider.Controllers
{
    public class LoginController : Controller
    {

        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ApplicationContext _db;

        public LoginController(ApplicationContext db, IWebHostEnvironment environment)
        {
            _db = db;
            webHostEnvironment = environment;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var providers = _db.providers.ToList();
            var customers = _db.customers.ToList();

            foreach (var provider in providers)
            {
                if (provider.Email.ToLower() == email.ToLower() && provider.Password == password)
                {
                    string userJson = JsonConvert.SerializeObject(provider);
                    HttpContext.Session.SetString("LiveProvider", userJson);
                    if (DateTime.Now > provider.SubscriptionEndDate)
                    {
                        if(provider.IsActive)
                        {
                            provider.IsSubscriptionActive = false;
                            _db.providers.Update(provider);
                            _db.SaveChanges();

                            TempData["error"] = "Must Pay For New Subscriptions";
                            return RedirectToAction("PaySubscription", "Customer");
                        }
                        else
                        {
                            TempData["error"] = "Must Accepted By Admin ";
                            return RedirectToAction("Index","Customer");
                        }
                        
                    }
                    else
                    {
                        return RedirectToAction("Index", "Customer");
                    }

                }
            }

            foreach (var customer in customers)
            {
                if (customer.Email.ToLower() == email.ToLower() && customer.Password == password)
                {
                    string userJson = JsonConvert.SerializeObject(customer);
                    HttpContext.Session.SetString("LiveCustomer", userJson);
                    TempData["success "] = "Logged In Succesfully";
                    if (customer.Role == Role.Admin)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (customer.Role == Role.Customer)
                    {
                        // Check if there is a return URL in TempData
                        var returnUrl = TempData["ReturnUrl"] as string;
                        // Redirect to the return URL or the default /Customer/Index
                        return Redirect(string.IsNullOrEmpty(returnUrl) ? "/Customer/Index" : returnUrl);
                    }
                }
            }

            ModelState.AddModelError("InvalidUser", "Invalid email or password.");
            return View();
        }


        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            var customers = _db.customers.ToList();
            bool check = false;

            foreach (var c in customers)
            {
                if (c.Email == customer.Email)
                {
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                
                _db.customers.Add(customer);
                _db.SaveChanges();

                string customerJson = JsonConvert.SerializeObject(customer);
                HttpContext.Session.SetString("LiveCustomer", customerJson);

                TempData["success"] = "Added Customer And Login Successfully";
                return RedirectToAction("Index", "Customer");
            }

            ModelState.AddModelError("InvalidUser", "This Email exists Try Another\"");
            return RedirectToAction("Login");
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
            foreach(var p in providers)
            {
                if (p.Email == provider.Email)
                    check = true;

            }
            if(!check)
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

                _db.providers.Add(provider);
                _db.SaveChanges();

                string providerJson = JsonConvert.SerializeObject(provider);
                HttpContext.Session.SetString("LiveProvider", providerJson);

                TempData["success"] = "Added provider And Login Successfully But YOu Can't Recive Order or Pay for Subscription Unless The Admin Approves You ";

                return RedirectToAction("Index", "Customer");
            }

            ModelState.AddModelError("InvalidUser", "This Email exists Try Another");
            return RedirectToAction("Login");
        }
    }
}
