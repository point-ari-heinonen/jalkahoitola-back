using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jalkahoitola_thesis.Controllers
{
    public class ProductGroupController : ApiController
    {
        // GET: api/ProductGroup/5
        public IEnumerable<ProductGroup> Get(int id)
        {
            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            List<ProductGroup> items = new List<ProductGroup>();
            List<ProductGroup> result = new List<ProductGroup>();
            if (id == 0)
            {
                items = (from p in entities.ProductGroups
                                            select p).ToList();
            }
            else
            {
                items = (from p in entities.ProductGroups
                                            where p.GroupId == id
                                            select p).ToList();
            }
            foreach (ProductGroup item in items)
                {
                ProductGroup data = new ProductGroup();
                data.GroupId = item.GroupId;
                data.Name = item.Name;
                //data.Products = item.Products;
                result.Add(data);
            }

            return (result);
        }
        



        /*
        public List<string> ProductGroups()
        {
            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            List<ProductGroup> ListOfProductGroups = (from p in entities.ProductGroups
                                            select p).ToList();
            List<string> ProductGroups = ListOfProductGroups.Select(p => p.Name).ToList();
            return (ProductGroups);
        }
        */
        /*
        // GET: api/ProductGroup
        public List<ProductGroup> Get()
        {
            JalkahoitolaEntities entities = new JalkahoitolaEntities();
            List<ProductGroup> ListOfProductGroups = (from p in entities.ProductGroups
                                            select p).ToList();
            List<string> ProductGroups = ListOfProductGroups.Select(p => p.Name).ToList();
            return ProductGroups;
            //return new string[] { "value1", "value2" };
        }
        
        
        // POST: api/ProductGroup
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProductGroup/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductGroup/5
        public void Delete(int id)
        {
        }
    */
    }
}
