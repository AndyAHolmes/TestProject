using ExerciseApp.Services;
using System;
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
            var qs = new QuoteService();

            var quoteResult = qs.PerformQuote(new Model.QuoteRequest {
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
            var qs = new QuoteService();

            var quoteResult = qs.PerformQuote(new Model.QuoteRequest
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
            var qs = new QuoteService();

            var quoteResult = qs.PerformQuote(new Model.QuoteRequest
            {
                DateOfBirth = new DateTime(2000, 05, 01),
                InsuranceType = Model.InsuranceType.itThirdPartyOnly,
                Make = make,
                Model = model
            });

            Assert.Equal(quote, quoteResult);
        }

    }
}
