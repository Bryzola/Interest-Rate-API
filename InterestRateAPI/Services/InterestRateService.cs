using InterestRateAPI.Interfaces;
using InterestRateAPI.Models;
using System.Threading.Tasks;

namespace InterestRateAPI.Services
{
    public class InterestRateService : IInterestRateService
    {
        private const double FIXED_RATE = 0.01;
        public async Task<InterestRateDTO> retrieveInterestRateData()
        {
            var task = await Task.Run(() => {
                InterestRateDTO interestRate = new InterestRateDTO()
                {
                    CurrentRate = FIXED_RATE
                };

                return interestRate;
            });

            return task;
        }
    }
}
