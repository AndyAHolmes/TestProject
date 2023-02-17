using ExerciseApp.Service;
using ExerciseApp.Services;
using Moq;
using System;
using System.Reflection;
using Xunit;

namespace ExerciseApp.Tests
{
    public class QuoteServiceTests
    {
        [Theory]
        [InlineData("Ford", "Focus", 200)]
        [InlineData("Audi", "A3", 300)]
        [InlineData("BMW", "X5", 500)]
        [InlineData("BMW", "3 Series", 400)]
        public void WhenDetailsAreProvided_FullyComp_TheCorrectQuoteIsProduced(string make, string model, int quote)
        {
            var fcie = new FullyCompInsuranceEngine();

            var quoteResult = fcie.GenerateQuote(new Model.QuoteRequest {
                DateOfBirth = new DateTime(2000, 05, 01),
                InsuranceType = Model.InsuranceType.itFullyComprehensive,
                Make=make , Model=model});

            Assert.Equal(quote, quoteResult);
        }

        [Theory]
        [InlineData("Ford", "Focus", 180)]
        [InlineData("Audi", "A3", 300)]
        [InlineData("BMW", "X5", 510)]
        [InlineData("BMW", "3 Series", 400)]
        public void WhenDetailsAreProvided_3PFireAndTheft_TheCorrectQuoteIsProduced(string make, string model, int quote)
        {
            var tpfatie = new ThirdPartyFireAndTheftInsuranceEngine();

            var quoteResult = tpfatie.GenerateQuote(new Model.QuoteRequest
            {
                DateOfBirth = new DateTime(2000, 05, 01),
                InsuranceType = Model.InsuranceType.itThirdPartyFireAndTheft,
                Make = make,
                Model = model
            });

            Assert.Equal(quote, quoteResult);
        }

        [Theory]
        [InlineData("Ford", "Focus", 180)]
        [InlineData("Audi", "A3", 250)]
        [InlineData("BMW", "X5", 300)]
        [InlineData("BMW", "3 Series", 300)]
        public void WhenDetailsAreProvided_3Party_TheCorrectQuoteIsProduced(string make, string model, int quote)
        {
            var tpie = new ThirdPartyInsuranceEngine();

            var quoteResult = tpie.GenerateQuote(new Model.QuoteRequest
            {
                DateOfBirth = new DateTime(2000, 05, 01),
                InsuranceType = Model.InsuranceType.itThirdPartyOnly,
                Make = make,
                Model = model
            });

            Assert.Equal(quote, quoteResult);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(90)]
        public void WhenAgeOutOfRangeIsProvided_NoQuoteProduced(int age)
        {
            var qs = new QuoteService(Mock.Of<IInsuranceQuoteFactory>());

            var quoteModel = new Model.QuoteRequest
            {
                DateOfBirth = DateTime.UtcNow.AddYears(0-age),
                InsuranceType = Model.InsuranceType.itThirdPartyOnly,
                Make = "Ford",
                Model = "Focus"
            };

            Assert.ThrowsAny<Exception>(() => qs.PerformQuote(quoteModel));
        }

        
    }
}
