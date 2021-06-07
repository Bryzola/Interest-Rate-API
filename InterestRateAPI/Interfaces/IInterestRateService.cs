using InterestRateAPI.Models;
using System.Threading.Tasks;

namespace InterestRateAPI.Interfaces
{
    public interface IInterestRateService
    {
        public Task<InterestRateDTO> retrieveInterestRateData();
    }
}
