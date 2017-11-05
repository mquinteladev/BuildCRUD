using DataInfrastructure.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInfrastructure.Infrastructure;
using System.Data.Entity.Validation;

namespace DataInfrastructure.Model
{
    public class ApiEmployeeRepository : IRepository<ApiEmployee>
    {
        
        public ApiEmployeeRepository()
        {
             
        }

        public ApiEmployee Add(ApiEmployee item)
        {
            ApiEmployee returnValue = null;

            using (var _context = new EmployeesEntities())
            {
                try
                {


                    Employee user = _context.Employees.Add(item.AsEmployee());
                    _context.SaveChanges();

                    returnValue = user.AsApiEmployee();

                }
                catch (DbEntityValidationException ex)
                {
                    throw ex.DBValidationEntityExceptionAsFriendlyException();
                }
                catch (Exception ex)
                {
                    throw ex.EntityExceptionAsFriendlyException();
                }
            }

            return returnValue;
        }

        public ApiEmployee Add(ApiEmployee item, int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public ApiEmployee Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApiEmployee> GetAll()
        {
            List<ApiEmployee> List = new List<ApiEmployee>();

            using (var context = new EmployeesEntities())
            {
                foreach (Employee employee in context.Employees.ToList())
                    List.Add(employee.AsApiEmployee());
            }
            return List;
        }

        public IEnumerable<ApiEmployee> GetAll(string limiter)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ApiEmployee item)
        {
            throw new NotImplementedException();
        }

        public bool Update(ApiEmployee item, int id)
        {
            throw new NotImplementedException();
        }
    }

    public class ApiEmployee
    {
        public int id { get; set; }

        public string fullName { get; set; }

        public System.DateTime initiationDate { get; set; } 

        public int fk_hiredfor { get; set; }

        public string email { get; set; }

        public string cellphone { get; set; }

        public System.DateTime startDate { get; set; }
        public string service_equipmentneeded { get; set; }
        public string aditional_service { get; set; }
        public int fk_companylist { get; set; }
        public string another_company { get; set; }
        public string aditional_info { get; set; }
        public int building_access { get; set; }
        public string another_building { get; set; }
        public string restricted_access { get; set; }

        public string hiringManagerEmail { get; set; }
    }
}
