using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReceiptOrders.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ReceiptOrders.Models.ViewModels;

namespace ReceiptOrders.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new OutputViewModel()
            {
                Orders = _context.Orders,
                Products = _context.Products,
                ProductsInOrders = _context.ProductsInOrders.OrderBy(i => i.OrderNumber)
            };

            return View(model);
        }

        public IActionResult Products()
        {
            var model = new OutputViewModel()
            {
                Orders = _context.Orders,
                Products = _context.Products,
                ProductsInOrders = _context.ProductsInOrders.OrderBy(i => i.OrderNumber)
            };

            return View(model);
        }

        public IActionResult Privacy()
        {

            return View();
        }

        public IActionResult CreateOrder()
        {
            return View();
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        public IActionResult AddProductsInOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Products");
        }
        
        [HttpPost]
        public async Task<IActionResult> AddProductsInOrder(ProductsInOrder productsInOrder)
        {
            // Указываем номер уже существующего документа
            // Указываем номер уже существующего продукта
            // Указываем количество данного продукта в документе
            _context.ProductsInOrders.Add(productsInOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
