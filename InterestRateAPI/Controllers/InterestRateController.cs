using InterestRateAPI.Interfaces;
using InterestRateAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InterestRateAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class InterestRateController : ControllerBase
    {

        private readonly IInterestRateService _interestRateService;

        public InterestRateController(IInterestRateService interestRateService)
        {
            _interestRateService = interestRateService;
        }

        [HttpGet("taxaJuros")]
        public async Task<IActionResult> GetInterestRate()
        {
            //Retrieves current interest rate from service
            InterestRateDTO interestRate = await _interestRateService.retrieveInterestRateData();

            //Returns current interest rate
            return Ok(interestRate);   
        }
    }
}
