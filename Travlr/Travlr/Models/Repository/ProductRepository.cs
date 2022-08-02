using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travlr.Services;

namespace Travlr.Models.Repository
{
    public class ProductRepository
    {
        private const string CacheKey = "Products";

        public ProductRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var products = GetDefaultProducts();

                    ctx.Cache[CacheKey] = products;
                }
            }
        }

        private List<Product> GetDefaultProducts()
        {
            string productsJson = TravelrAPI.GetProducts();
            if(productsJson.Contains("Error"))
            {
                return new List<Product>
                {
                    new Product { id = 1, name = "Fab 4 ex Launceston", liveAvailability = true, advertisedPrice = 30000, commission = 10000 },
                    new Product { id = 2, name = "Fab 4 ex Hobart", liveAvailability = true, advertisedPrice = 20000, commission = 6000 },
                    new Product { id = 3, name = "Famous 5", liveAvailability = true, advertisedPrice = 10000, commission = 8000},
                    new Product { id = 4, name = "Port Arthur Day Tour", liveAvailability = true, advertisedPrice = 20000, commission = 9000 },
                    new Product { id = 5, name = "Super7", liveAvailability = true, advertisedPrice = 15000, commission = 12000 }
                };
            }

            return new List<Product>();
        }

        public List<Product> GetAllProducts()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (List<Product>)ctx.Cache[CacheKey];
            }

            return GetDefaultProducts();
        }

        public Product GetProductById(int id)
        {
            string productsJson = TravelrAPI.GetProductById(id.ToString());
            if (productsJson.Contains("Error"))
            {
                return GetAllProducts().Where(a => a.id == id).FirstOrDefault();
            }
            else
            {
                return JsonConvert.DeserializeObject<Product>(productsJson);
            }

        }

        public List<SelectListItem> GetSelectListItem()
        {
            List<Product> productList = GetAllProducts();
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (var product in productList)
            {
                SelectListItem item = new SelectListItem() { Value = product.id.ToString(), Text = product.name };
                result.Add(item);
            }
            return result;
        }
    }
}