using ExerciseApp.Services;
using System;
using ExerciseApp.Model;
using Xunit;

namespace ExerciseApp.Tests
{
    public class QuoteServiceTests
    {
        [Fact]
        public void WhenDetailsAreProvided_AQuoteIsProduced()
        {
            var quoteService = new QuoteService();
            var quoteResult = quoteService.PerformQuote(
                new QuoteRequest
                {
                    DateOfBirth = new DateTime(2000, 05, 01), 
                    InsuranceType = InsuranceType.itFullyComprehensive, 
                    Make = Constants.Makes.Ford, 
                    Model = Constants.Models.Focus
                });
            Assert.Equal("£200", quoteResult);
        }

        [Fact]
        public void CalculateIfAgeIsValid_TrueIsReturn()
        {
            var quoteService = new QuoteService();
            var result = quoteService.CalculateIfAgeIsValid(new DateTime(2000, 05, 01));
            Assert.True(result);
        }

        [Fact]
        public void CalculateIfAgeIsValid_FalseIsReturn()
        {
            var quoteService = new QuoteService();
            var result = quoteService.CalculateIfAgeIsValid(new DateTime(2010, 05, 01));
            Assert.False(result);

            result = quoteService.CalculateIfAgeIsValid(new DateTime(1940, 05, 01));
            Assert.False(result);
        }
    }
}
