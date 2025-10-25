using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApplication3.Helper;
using WebApplication3.Model;


namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private static string CreateToken(List<Employee> employees)
        {
            // Dummy token creation logic for illustration
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("dummy-token"));
        }
        public EmployeeController()
        {
            
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAllData()
        {
            var employees = XmlFileHelper.ReadEmployees();
           
            return Ok(employees);

        }
        [HttpGet("{GetByID}")]
        public ActionResult<List<Employee>> GetByID([FromBody] int id)
        {
            var employees = XmlFileHelper.ReadEmployees();
            var emp = employees.FirstOrDefault(e => e.EmpId==id);
            emp.token = CreateToken(employees);
            return Ok(employees);
           
        }
        [HttpPost]
        public ActionResult<List<Employee>> PostEmpDetails([FromQuery] List<Employee> ? employee)
        {
            XmlFileHelper.WriteEmployees(employee);
            return Ok(employee);
        }

    }
}
