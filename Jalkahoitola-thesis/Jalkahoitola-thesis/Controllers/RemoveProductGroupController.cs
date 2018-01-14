using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jalkahoitola_thesis.Controllers
{
    public class RemoveProductGroupController : ApiController
    {
        // GET: api/RemoveProductGroup
        
        //  [HttpGet]
        public int Get(int id)
        {
            JalkahoitolaEntities entities = new JalkahoitolaEntities();
           
            int items = (from p in entities.Products
                         where p.GroupId == id
                         select p).Count();

            if (items == 0)
            {
                ProductGroup ProductGroupToBeRemoved = (from p in entities.ProductGroups
                                                        where p.GroupId == id
                                                        select p).First();
                entities.ProductGroups.Remove(ProductGroupToBeRemoved);
                entities.SaveChanges();
            }

            entities.Dispose();
            return items;
        }



    }
}
