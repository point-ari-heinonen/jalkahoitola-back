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
            //Query entry from entity
            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            Recieved_ammount EntryToModify = (from p in entities.Recieved_ammounts
                                       where p.SaapumiseranId == SaapumiseranId
                                       select p).SingleOrDefault();
            int? id = EntryToModify.ProductId;
            //Take the last one and remove 
            if (EntryToModify.UnitStock == 1)
            {
                EntryToModify.UnitStock = EntryToModify.UnitStock - 1;
                //EntryToModify = null;
                entities.Recieved_ammounts.Remove(EntryToModify);
                entities.SaveChanges();
            }
            //If there's more than one, just reduce the amount
            if (EntryToModify.UnitStock > 1)
            {
                EntryToModify.UnitStock = EntryToModify.UnitStock - 1;
                entities.SaveChanges();
            }
            

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
        
    }
}
