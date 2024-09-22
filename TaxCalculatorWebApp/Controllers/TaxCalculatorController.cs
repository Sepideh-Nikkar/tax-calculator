using Microsoft.AspNetCore.Mvc;
using TaxCalculatorWebApp.Controllers.Models;
using TaxCalculatorWebApp.Controllers.Service;

namespace TaxCalculatorWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly ILogger<TaxCalculatorController> _logger;
        private readonly ITaxCalculatorService _taxCalculatorService;

        public TaxCalculatorController(ILogger<TaxCalculatorController> logger, ITaxCalculatorService taxCalculatorService)
        {
            _logger = logger;
            _taxCalculatorService = taxCalculatorService;
        }

        [HttpPost]
        [Route("CalculateTax")]
        public ActionResult<CalculateTollFeeResponse> CalculateTax([FromBody] CalculateTollFeeRequest requestBody)
        {
            var isResponseValid = _taxCalculatorService.TryCalculateTax(requestBody, out var response);
            if (!isResponseValid)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}