using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore2Demo.Business.Service;
using NetCore2Demo.Entities.Domain;
using NetCore2Demo.Models;

namespace NetCore2Demo.Controllers
{
    public class HomeController : Controller
    {
        public IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        
        [Authorize]
        public IActionResult Index()
        {
            return View(_productService.GetProductList());
        }

        public IActionResult SaveProduct(Product productItem)
        {
            _productService.SaveProduct(productItem);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}