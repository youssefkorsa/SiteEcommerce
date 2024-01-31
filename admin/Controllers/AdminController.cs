using admin.Service;
using admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace admin.Controllers
{
    [Route("Admin")]

    public class AdminController : Controller
    {

        private readonly ServiceProduct _serviceProduct;

        public AdminController()
        {
            _serviceProduct = new ServiceProduct();
        }

        
        [Route("AddProduct")]
        [HttpGet]
        public IActionResult AddProduct()
        {
            
            return View();
        }

        [Route("AddProduct")]
        [HttpPost]
        public IActionResult AddProductPost()
        {
            string name= Request.Form["ProductName"];
            string description= Request.Form["ProductDescription"];
            double price = Convert.ToDouble(Request.Form["ProductPrice"]);           
            string category = Request.Form["ProductCategory"];
            int quantityStock = int.Parse(Request.Form["QuantityInStock"]);
            Product newProduct =new  Product(name, description, price, category, quantityStock);
            _serviceProduct.AddProduct(newProduct);
            return RedirectToAction("ListProducts");
        }
        
        [Route("ListProducts")]
        [HttpGet]
        public IActionResult ListProducts()
        {
            return View();
        }


        [Route("ListCustomers")]
        [HttpGet]
        public IActionResult ListCustomers()
        {
            return View();
        }

        [Route("History")]
        [HttpGet]
        public IActionResult History()
        {
            return View();
        }

    }
}
