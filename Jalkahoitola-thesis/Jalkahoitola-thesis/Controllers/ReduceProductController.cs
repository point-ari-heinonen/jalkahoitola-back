using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jalkahoitola_thesis.Controllers
{
    public class ReduceProductController : ApiController
    {
        // GET: api/ReduceProduct
        public IEnumerable<Recieved_ammount> Get(int? SaapumiseranId)
        {
            //Query entry from entity and update it
            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            Recieved_ammount EntryToModify = (from p in entities.Recieved_ammounts
                                       where p.SaapumiseranId == SaapumiseranId
                                       select p).SingleOrDefault();
            EntryToModify.UnitStock = EntryToModify.UnitStock - 1;
            int? id = EntryToModify.ProductId;
            entities.SaveChanges();

            //Get updated list from db and return it to client
            List<Recieved_ammount> items = (from o in entities.Recieved_ammounts
                                            where o.ProductId == id
                                            select o).ToList();
            entities.Dispose();
            List<Recieved_ammount> result = new List<Recieved_ammount>();
            foreach (Recieved_ammount item in items)
            {
                Recieved_ammount data = new Recieved_ammount();
                if (item.UnitStock > 0)
                {
                    data.ProductId = item.ProductId;
                    data.SaapumiseranId = item.SaapumiseranId;
                    data.VendorName = item.VendorName;
                    data.ExpireDate = item.ExpireDate;
                    data.Date = item.Date;
                    data.Price = item.Price;
                    data.UnitStock = item.UnitStock;
                    result.Add(data);
                }
            }
            return result;
        }

        // POST: api/ReduceProduct
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ReduceProduct/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ReduceProduct/5
        public void Delete(int id)
        {
        }
    }
}
