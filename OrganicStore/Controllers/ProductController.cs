using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OrganicStore.Models;
using System.Data;
using Newtonsoft.Json;

namespace OrganicStore.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(products products)
        {
            products prod = new products();
            prod.id = products.id;
            prod.p_name = products.p_name;
            prod.details = products.details;
            prod.category = products.category;
            prod.o_price = products.o_price;
            prod.s_price = products.s_price;
             prod.img = products.img;
            List<products> res = prod.GetProducts();
            string productsJson = JsonConvert.SerializeObject(res);
            TempData["products"] = productsJson;
           
            return RedirectToAction("Products","Home",res);            }
        }
    }


