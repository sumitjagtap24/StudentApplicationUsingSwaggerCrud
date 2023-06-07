using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentApplication.Models;

namespace StudentApplication.Controllers
{
    public class StudentController : ApiController
    {
        public IEnumerable<Student> Get()
        {
            using(StudentEntities entities = new StudentEntities())
            {
                return entities.Students.ToList();  
            }
        }

        public HttpResponseMessage Get(int id)
        { 
            using (StudentEntities entities = new StudentEntities())
            {
                var entity =  entities.Students.FirstOrDefault(e => e.ID == id);
                if(entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with ID = " + id.ToString() + "  Not found");
                }
            }
        }

        public HttpResponseMessage Post([FromBody] Student student)
        {
            try
            {
                
               using(StudentEntities entities = new StudentEntities())
                    {
                          entities.Students.Add(student);
                          entities.SaveChanges();

                          var message = Request.CreateResponse(HttpStatusCode.Created, student);
                          message.Headers.Location = new Uri(Request.RequestUri + student.ID.ToString());
                           return message;

                     }
            }
            catch (Exception ex)
            {
              return  Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                
            }
          
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {

                using (StudentEntities entities = new StudentEntities())
                {
                    var entity = entities.Students.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with ID = " + id.ToString() + "  Not found");
                    }
                    else
                    {
                        entities.Students.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
                }
             catch(Exception ex)
            {
                     return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

            }
             

            
        }

        public HttpResponseMessage Put(int id, [FromBody] Student student)
        {
            try
            {


                using (StudentEntities entities = new StudentEntities())
                {
                    var entity = entities.Students.FirstOrDefault(e => e.ID == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student with ID = " + id.ToString() + " Not Found to Update");

                    }
                    else
                    {


                        entity.FirstName = student.FirstName;
                        entity.LastName = student.LastName;
                        entity.Age = student.Age;
                        entity.GPA = student.GPA;

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex) ;
            }
            }

    }
}
