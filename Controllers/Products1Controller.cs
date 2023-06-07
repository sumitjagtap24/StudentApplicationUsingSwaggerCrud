using Azure.Core;
using StudentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentApplication.Controllers
{
    public class Products1Controller : ApiController
    {
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Products1> Get()
        {
            using (Products1Entities entities = new Products1Entities())
            {
                return entities.Products1.ToList();
            }
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public IHttpActionResult Get(string id)
        {
            using (Products1Entities entities = new Products1Entities())
            {
               var test = entities.Products1.Where(x => x.id == id).ToList();
                return Ok(test);
            }
        }
    }




   /* [HttpGet]*/
 /*   public Products1 Get(string id)
    {
        using (Products1Entities entities = new Products1Entities())
        {

            return entities.Products1.FirstOrDefault(e => e.id == id);
           *//* var entity = entities.Products1.FirstOrDefault(e => e.id == id);
            if (entity != null)
            {

            }
            else
            {

            }*//*
        }
    }*/



}
