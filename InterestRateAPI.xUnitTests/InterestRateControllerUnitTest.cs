using Xunit;
using Moq;
using InterestRateAPI.Controllers;
using InterestRateAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using InterestRateAPI.Models;

namespace InterestRateAPI.xUnitTests
{
    public class InterestRateControllerUnitTest
    {
        private Mock<IInterestRateService> _mockInterestRateService = new Mock<IInterestRateService>();

        [Fact]
        public async void Valid_GetInterestRate()
        {
            //Arrange
            var expectedRateDTO = new InterestRateDTO()
            {
                CurrentRate = 0.01
            };
            _mockInterestRateService.Setup(x => x.retrieveInterestRateData()).ReturnsAsync(new InterestRateDTO()
            {
                CurrentRate = 0.01
            });
            InterestRateController interestRateController = new InterestRateController(_mockInterestRateService.Object);
            
            //Act
            ObjectResult result = await interestRateController.GetInterestRate() as ObjectResult;
            InterestRateDTO rateResult = result.Value as InterestRateDTO;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.True(expectedRateDTO.CurrentRate.Equals(rateResult.CurrentRate));
        }

        [Fact]
        public async void Invalid_GetInterestRate()
        {
            //Arrange
            var expectedRateDTO = new InterestRateDTO()
            {
                CurrentRate = 0.01
            };
            _mockInterestRateService.Setup(x => x.retrieveInterestRateData()).ReturnsAsync(new InterestRateDTO()
            {
                CurrentRate = 0.06
            });
            InterestRateController interestRateController = new InterestRateController(_mockInterestRateService.Object);

            //Act
            ObjectResult result = await interestRateController.GetInterestRate() as ObjectResult;
            InterestRateDTO rateResult = result.Value as InterestRateDTO;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.False(expectedRateDTO.CurrentRate.Equals(rateResult.CurrentRate));
        }
    }
}
