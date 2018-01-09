using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jalkahoitola_thesis.Controllers
{
    public class RemoveProductController : ApiController
    {
        
        // GET: api/RemoveProduct/5
        public int Get(int? id)
        {


            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            List<int?> items = (from o in entities.Recieved_ammounts
                                where o.ProductId == id
                                select o.UnitStock).ToList();
            
            if(items.Sum() == 0 || items.Sum() == null)
            {
                Product ProductToBeRemoved = (from o in entities.Products
                                              where o.ProductId == id
                                              select o).First();
               entities.Products.Remove(ProductToBeRemoved);
                entities.SaveChanges();
            }

            entities.Dispose();
            return 1;
        }
        
    }
}
