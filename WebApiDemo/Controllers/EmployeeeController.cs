using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using WebApiDemo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeeController : ControllerBase
    {
        private readonly IEmployeeeService service;
        public EmployeeeController(IEmployeeeService service)
        {
            this.service = service;
        }
        // GET: api/<EmployeeeController>
        [HttpGet]
        [Route("GetEmployeees")]
        public IActionResult Get()
        {
            try
            {
                var model = service.GetEmployeees();
                return new ObjectResult(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        // GET api/<EmployeeeController>/5
        [HttpGet]
        [Route("GetEmployeeeById/{id}")]

        public IActionResult Get(int id)
        {
            try
            {
                var model = service.GetEmployeeeById(id);
                if (model != null)
                    return new ObjectResult(model);
                else
                    return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<EmployeeeController>
        [HttpPost]
        [Route("AddEmployeee")]
        public IActionResult Post([FromBody] Employeee employeee)
        {
            try
            {
                int result = service.AddEmployeee(employeee);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/<EmployeeeController>/5
        [HttpPut]
        [Route("UpdateEmployeee")]
        public IActionResult Put(int id, [FromBody] Employeee employeee)
        {
            try
            {
                int result = service.UpdateEmployeee(employeee);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // DELETE api/<EmployeeeController>/5
        [HttpDelete]
        [Route("DeleteEmployeee/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int result = service.DeleteEmployeee(id);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
