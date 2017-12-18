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
        public int? Get(int? SaapumiseranId)
        {
            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            Recieved_ammount result = (from p in entities.Recieved_ammounts
                                       where p.SaapumiseranId == SaapumiseranId
                                       select p).SingleOrDefault();
            result.UnitStock = result.UnitStock - 1;
            int? newvalue = result.UnitStock;
            entities.SaveChanges();
            return newvalue;

           
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
