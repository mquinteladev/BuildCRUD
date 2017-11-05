using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web;
using DataInfrastructure.Model;
using DataInfrastructure.Interfaces;
using DataInfrastructure;

namespace CRUD.Controllers
{
    [AllowAnonymous]
    public class EmployeesController : ApiController
    {
      
        private readonly IRepository<ApiEmployee> _repository;


        public EmployeesController(  )
        {
         
            _repository = FactoryClass.MakeEmployeeRepository();
        }

     
        public IEnumerable<ApiEmployee> GetAllEmployees()
        {

            try
            {
            
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                 
            }
            return new List<ApiEmployee>();
        }


      
        public ApiEmployee GetEmployee(int id)
        {
            
            return _repository.Get(id);
        }
         
        [HttpPost]
        public HttpResponseMessage PostEmployee(ApiEmployee Employee)
        {

           if (Employee == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Incorrect form data."));


            try
            {
 
                Employee = _repository.Add(Employee);
 
                var response = Request.CreateResponse<ApiEmployee>(HttpStatusCode.Created, Employee);
                
                return response;

            }

            catch (Exception ex)
            { 
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }
        
        public HttpResponseMessage PutEmployee(int id, ApiEmployee Employee)
        {
           

            if (Employee == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Incorrect form data."));

            if (GetEmployee(id) == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format("Employee {0}, does not exist.", id)));


            try
            {


              
                if (_repository.GetAll(id.ToString()).Count() == 0)
                    throw new Exception("Employee does not exist in the system.");

                _repository.Update(Employee, id);


               

                var response = Request.CreateResponse<ApiEmployee>(HttpStatusCode.OK, Employee);
                string uri = Url.Link("ApiEmployee", new { id = Employee.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }

            catch (Exception ex)
            { 
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public HttpResponseMessage DeleteEmployee(int id)
        {
           
            return new HttpResponseMessage() { StatusCode = HttpStatusCode.NotImplemented };
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
