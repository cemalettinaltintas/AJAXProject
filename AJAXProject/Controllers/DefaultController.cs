using AJAXProject.DataAccess.Context;
using AJAXProject.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AJAXProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly AjaxContext _context;

        public DefaultController(AjaxContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var values=_context.Products.ToList();

            var products=JsonConvert.SerializeObject(values);//Json formatına çevirdik
            return Json(products);
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            var values=JsonConvert.SerializeObject(product);
            return Json(values);
        }
        public IActionResult DeleteProduct(int id)
        {
            var value=_context.Products.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet]
        public IActionResult GetProductById(int id)
        {
            var value = _context.Products.Find(id);
            var product=JsonConvert.SerializeObject(value);
            return Json(product);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
