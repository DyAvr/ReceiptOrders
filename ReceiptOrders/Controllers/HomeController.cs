using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReceiptOrders.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult ProductsInOrders()
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Order order = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);
                if (order != null)
                    return View(order);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Order order = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);
                if (order != null)
                    return View(order);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Order order = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);
                if (order != null)
                {
                    _context.Orders.Remove(order);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> EditProduct(int? id)
        {
            if (id != null)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Products");
        }
        [HttpGet]
        [ActionName("DeleteProduct")]
        public async Task<IActionResult> ConfirmDeleteProduct(int? id)
        {
            if (id != null)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id != null)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Products");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> EditConnection(int? id)
        {
            if (id != null)
            {
                ProductsInOrder connection = await _context.ProductsInOrders.FirstOrDefaultAsync(p => p.Id == id);
                if (connection != null)
                    return View(connection);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditConnection(ProductsInOrder connection)
        {
            _context.ProductsInOrders.Update(connection);
            await _context.SaveChangesAsync();
            return RedirectToAction("ProductsInOrders");
        }
        [HttpGet]
        [ActionName("DeleteConnection")]
        public async Task<IActionResult> ConfirmDeleteConnection(int? id)
        {
            if (id != null)
            {
                ProductsInOrder connection = await _context.ProductsInOrders.FirstOrDefaultAsync(p => p.Id == id);
                if (connection != null)
                    return View(connection);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConnection(int? id)
        {
            if (id != null)
            {
                ProductsInOrder connection = await _context.ProductsInOrders.FirstOrDefaultAsync(p => p.Id == id);
                if (connection != null)
                {
                    _context.ProductsInOrders.Remove(connection);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ProductsInOrders");
                }
            }
            return NotFound();
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
            return RedirectToAction("ProductsInOrders");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
