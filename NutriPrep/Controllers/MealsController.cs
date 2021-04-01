using Microsoft.AspNetCore.Mvc;
using NutriPrep.DTOs;
using NutriPrep.Interfaces;
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
        private readonly IMealsService _mealsService;

        public MealsController(
           IMealsRepository mealsRepository,
           IMealsService mealsService
        )
        {
            _mealsRepository = mealsRepository;
            _mealsService = mealsService;
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

        [HttpGet("GetUshqimetPerEleminimNePlan")]
        public IActionResult GetUshqimetPerEleminimNePlan()
        {
            try
            {
                var result = _mealsRepository.GetUshqimetPerEleminimNePlan();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GetPlan")]
        public async Task<IActionResult> GetPlan(PayLoadDTO payLoad)
        {
            try
            {
                var result = await _mealsService.GetPlan(payLoad);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
