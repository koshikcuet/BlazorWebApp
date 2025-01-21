using Microsoft.AspNetCore.Mvc;

namespace BlazorAuto.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        // GET: api/<ApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "your ID : " + id.ToString();
        }

        [HttpGet("customer/mycust")]
        public JsonResult GetCustomer()
        {
            List<Customer> customers = new List<Customer>();
            customers.AddRange(new Customer[]
            {
                 new Customer { CompanyName="ABC Company", ContactName="Frank Liu", PhoneNumber="111-1111" },
                 new Customer { CompanyName="DEF Company", ContactName="Thomas Train", PhoneNumber="222-2222" },
                 new Customer { CompanyName="GHI Company", ContactName="John Doe", PhoneNumber="333-3333" }
            });
            return new JsonResult(customers);
        }

        // POST api/<ApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        
    }

    class Customer
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
