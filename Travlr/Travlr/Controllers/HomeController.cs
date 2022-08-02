using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travlr.Models;
using Travlr.Models.Repository;
using Travlr.Services;

namespace Travlr.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            ProductRepository productRepos = new ProductRepository();
            List<SelectListItem> productItems = productRepos.GetSelectListItem();
            ViewBag.ProductList = productItems;

            return View();
        }
    }
}
