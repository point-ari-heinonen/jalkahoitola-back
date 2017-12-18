using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jalkahoitola_thesis.Controllers
{
    public class ShipmentsForProductController : ApiController
    {
        public IEnumerable<Recieved_ammount> Get(int id)
        {
            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            List<Recieved_ammount> items = (from o in entities.Recieved_ammounts
                                   where o.ProductId == id
                                   select o).ToList();
            entities.Dispose();
            List<Recieved_ammount> result = new List<Recieved_ammount>();
            foreach (Recieved_ammount item in items)
            {
                Recieved_ammount data = new Recieved_ammount();
                data.ProductId = item.ProductId;
                data.SaapumiseranId = item.SaapumiseranId;
                data.VendorName = item.VendorName;
                data.ExpireDate = item.ExpireDate;
                data.Date = item.Date;
                data.Price = item.Price;
                data.UnitStock = item.UnitStock;
               
                result.Add(data);
            }
            return result;
        }
        public int Post([FromBody] Recieved_ammount value)
        {
            /*
            Recieved_ammount testvalue = new Recieved_ammount();
            testvalue.ProductId = value.ProductId;
            testvalue.SaapumiseränId = value.SaapumiseränId;
            testvalue.Date = value.Date;
            testvalue.ExpireDate = value.ExpireDate;
            testvalue.Price = value.Price;
            testvalue.VendorName = value.VendorName;
            testvalue.LocationCode = value.LocationCode;
            testvalue.Product = value.Product;
            testvalue.Stocks = value.Stocks;
            return testvalue;
            */
            Recieved_ammount testvalue = new Recieved_ammount();
            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            entities.Recieved_ammounts.Add(value);
            int result=entities.SaveChanges();
            entities.Dispose();
            return result;
            
         }
    }
}

        /*
        // GET: api/ShipmentsForProduct
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ShipmentsForProduct/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ShipmentsForProduct
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShipmentsForProduct/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShipmentsForProduct/5
        public void Delete(int id)
        {
        }
    }
}
*/