using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jalkahoitola_thesis.Controllers
{
    public class ProductCountController : ApiController
    {

        // GET: api/ProductCount/5
        public int? Get(int id)
        {
            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            List<int?> items = (from o in entities.Recieved_ammounts
                               where o.ProductId == id
                               select o.UnitStock).ToList();
            entities.Dispose();
            return items.Sum();
            
        }
    }
}
