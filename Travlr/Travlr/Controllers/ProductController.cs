using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travlr.Models;
using Travlr.Models.Repository;

namespace Travlr.Controllers
{
    public class ProductController : Controller
    {
        [HttpPost]
        public int GetPrice(int productID, bool isDiscount)
        {
            try
            {
                ProductRepository productRepos = new ProductRepository();
                Product product = productRepos.GetProductById(productID);
                return product.advertisedPrice - (isDiscount ? product.commission / 2 : 0);
            }
            catch
            {
                return 0;
            }
        }
    }
}