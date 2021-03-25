using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriPrep.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealsController : Controller
    {
        private readonly IMealsRepository _mealsRepository;

        public MealsController(
           IMealsRepository mealsRepository
        )
        {
            _mealsRepository = mealsRepository;
        }

        [HttpGet("GetUshqimet")]
        public IActionResult GetUshqimet()
        {
            try
            {
                var customerResult = _mealsRepository.GetUshqimet();

                return Ok(customerResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
