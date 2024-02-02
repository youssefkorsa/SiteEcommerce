using admin.Service;
using admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace admin.Controllers
{
    [Route("Admin")]

    public class AdminController : Controller
    {

        private readonly ServiceProduct _serviceProduct;
        private readonly ServiceCustomer _serviceCustomer;
        private readonly ServiceCartItem _serviceCartItem;
        private readonly ServicePurchase _servicePurchase;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminController(IWebHostEnvironment webHostEnvironment)
        {
            _serviceProduct = new ServiceProduct();
            _serviceCustomer = new ServiceCustomer();
            _serviceCartItem = new ServiceCartItem();
            _servicePurchase = new ServicePurchase();
            _webHostEnvironment = webHostEnvironment;

        }

        
        [Route("AddProduct")]
        [HttpGet]
        public IActionResult AddProduct()
        {
            
            return View();
        }

        [Route("AddProduct")]
        [HttpPost]
        public IActionResult AddProductPost(IFormFile ProductImage)
        {
            string folder = "";
            if (ProductImage != null)
            {
                folder = "ProductImages/" + Guid.NewGuid() + ProductImage.FileName;
                string serverFolder = Path.Combine(Path.Combine(_webHostEnvironment.WebRootPath), folder);
                ProductImage.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }
            string name= Request.Form["ProductName"];
            string description= Request.Form["ProductDescription"];
            double price = Convert.ToDouble(Request.Form["ProductPrice"]);           
            string category = Request.Form["ProductCategory"];
            int quantityStock = int.Parse(Request.Form["QuantityInStock"]);
            Product newProduct =new  Product(name, description, price, category, quantityStock, folder);
            _serviceProduct.AddProduct(newProduct);
            return RedirectToAction("ListProducts");
        }
        
        [Route("ListProducts")]
        [HttpGet]
        public IActionResult ListProducts()
        {
           var products= _serviceProduct.GetProducts();

            return View(products);
        }


        [Route("ListCustomers")]
        [HttpGet]
        public IActionResult ListCustomers()
        {
            var customers = _serviceCustomer.GetCustomers();

            return View(customers);
        }

        [Route("History")]
        [HttpGet]
        public IActionResult History()
        {
            var total=new List<double>();
            var purchases = _servicePurchase.GetPurchases();
            foreach (var item in purchases)
            {
                total.Add(item.QuantityPurchase*item.Product.Price);

            }
            ViewBag.Total = total;
            return View("History",purchases);
        }

    }
}
