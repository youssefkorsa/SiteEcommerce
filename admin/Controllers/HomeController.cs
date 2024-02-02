using admin.Models;
using admin.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace admin.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly ServiceCustomer _serviceCustomer= new ServiceCustomer();
        private readonly ServiceProduct _serviceProduct= new ServiceProduct();
        public static List<Purchase> purchases = new List<Purchase>();
        public readonly ServicePurchase _servicePurchase= new ServicePurchase();
        public readonly ServiceCartItem _serviceCartItem= new ServiceCartItem();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("/shop")]
        [HttpGet]
        public IActionResult Shop()
        {
            var products = _serviceProduct.GetProducts();
            return View(products);
        }

        [Route("/ProductDetails")]
        [HttpGet]
        public IActionResult ProductDetails(int id)
        {   
            var product=_serviceProduct.GetProduct(id);
            return View(product);
        }

        [Route("/About")]
        [HttpGet]
        public IActionResult About()
        {

            return View();
        }

        [Route("/History")]
        [HttpGet]
        public IActionResult History()
        {
            var total = new List<double>();
            var purchase = _servicePurchase.GetPurchases();
            foreach (var item in purchase)
            {
                total.Add(item.QuantityPurchase * item.Product.Price);

            }
            ViewBag.Total = total;


            return View("History", purchase);
        }

        [Route("/User")]
        [HttpGet]
        public IActionResult User()
        {
            return View();
        }

        [Route("/User")]
        [HttpPost]
        public IActionResult UserPost()
        {
            string userFirstName = Request.Form["UserFirstName"];
            string userLastName = Request.Form["UserLastName"];
            Customer newCustomer = new Customer(userFirstName, userLastName);
            _serviceCustomer.AddCustomer(newCustomer);
            return RedirectToAction("Shop");
        }


        [Route("/Cart")]
        [HttpGet]
        public IActionResult Cart()
        {
            return View(purchases);
        }

        [Route("/Cart")]
        [HttpPost]
        public IActionResult CartPost()
        {  
            int quantity= int.Parse(Request.Form["Quantity"]);
            var id = int.Parse(Request.Form["Id"]);
            var found = false;
            foreach(var item in purchases)
            {
                if(item.Product.Id == id)
                {
                    found = true;
                    item.QuantityPurchase += quantity;
                    break;
                }
                
            }
            if(!found)
            {
                var product = _serviceProduct.GetProduct(id);
                Purchase purchase = new Purchase(product, quantity);
                purchases.Add(purchase);
            }
            
            return RedirectToAction("cart");
        }


        [Route("/Checkout")]
        [HttpGet]
        public IActionResult Checkout()
        {
            

            var cart = new CartItem(purchases);
            _serviceCartItem.AddCartItem(cart);
            purchases = new List<Purchase>();
            return RedirectToAction("Shop");
        }

        [Route("/DeletePurchase")]
        [HttpGet]
        public IActionResult DeletePurchase(int id) 
        {
            foreach(var purchase in purchases)
            {
                if (purchase.Id == id)
                {
                    purchases.Remove(purchase);
                    break;
                }
                    
            }
            return RedirectToAction("cart");
        }



    }
}
