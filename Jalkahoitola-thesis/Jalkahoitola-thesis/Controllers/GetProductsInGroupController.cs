using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jalkahoitola_thesis.Controllers
{
    public class GetProductsInGroupController : ApiController
    {

        public IEnumerable<Product> Get(int id)
        {

            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            List<Product> items = (from o in entities.Products
                                   where o.GroupId == id
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






        /*
        // GET: api/GetProductsInGroup
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetProductsInGroup/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GetProductsInGroup
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetProductsInGroup/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetProductsInGroup/5
        public void Delete(int id)
        {
        }
    }
    */
    }
}
