using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jalkahoitola_thesis.Controllers
{
    public class ProductController : ApiController
    {

        public IEnumerable<Product> Get(int id)
        {
         
            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            List<Product> items = (from o in entities.Products
                                   where o.ProductId == id
                                   select o).ToList();
            entities.Dispose();
            List<Product> result = new List<Product>();
            foreach (Product item in items)
            {

                Product data = new Product();
                data.ProductId = item.ProductId;
                data.Nmae = item.Nmae;
                data.Description = item.Description;
                data.Quantity = item.Quantity;
                data.UnitOfMeasure = item.UnitOfMeasure;
                data.GroupId = item.GroupId;
                data.Entery_Date = item.Entery_Date;
                data.Expire = item.Expire;
                data.Person_Name = item.Person_Name;
                //data.ProductGroup = item.ProductGroup;
                //data.Recieved_ammount = item.Recieved_ammount;
                
                result.Add(data);
                }

            return result;
        }

        // POST: api/Product
        public Product Post([FromBody] Product value)
        {

            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            /* Testing part
            Product newProduct = new Product();
            newProduct.Nmae = value.Nmae;
            newProduct.Description = value.Description;
            newProduct.Quantity = value.Quantity;
            newProduct.UnitOfMeasure = value.UnitOfMeasure;
            newProduct.GroupId = value.GroupId;
            newProduct.Entery_Date = value.Entery_Date;
            newProduct.Expire = value.Expire;
            newProduct.Person_Name = value.Person_Name;
            entities.Products.Add(newProduct);
            entities.SaveChanges();
            entities.Dispose();
            return newProduct;
            */
            entities.Products.Add(value);
            entities.SaveChanges();
            entities.Dispose();
            return value;
        }



        /*
        // GET: api/Product
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
        */
    }
}
