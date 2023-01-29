using ExerciseApp.Services;
using System;
using Xunit;

namespace ExerciseApp.Tests
{
    public class QuoteServiceTests
    {
        [Fact]
        public void WhenDetailsAreProvided_AQuoteIsProduced()
        {
            var qs = new QuoteService();
            var quoteResult = qs.PerformQuote(new Model.QuoteRequest { DateOfBirth = new DateTime(2000, 05, 01), InsuranceType = Model.InsuranceType.itFullyComprehensive, Make= "Ford", Model="Focus"});
            Assert.Equal(200, quoteResult);
        }
        [Fact]
        public void WhenLegalAgeProvidedQuoteOrNot()
        {
            var qs = new QuoteService();
            var quoteResultAgeSixteen = qs.PerformQuote(new Model.QuoteRequest { DateOfBirth = new DateTime(2007, 01, 18), InsuranceType = Model.InsuranceType.itFullyComprehensive, Make = "BMW", Model = "X5" });
            var quoteResultAgeEighty = qs.PerformQuote(new Model.QuoteRequest { DateOfBirth = new DateTime(1943, 01, 01), InsuranceType = Model.InsuranceType.itFullyComprehensive, Make = "BMW", Model = "X5" });
            var quoteResultAgeProper = qs.PerformQuote(new Model.QuoteRequest { DateOfBirth = new DateTime(1990, 11, 11), InsuranceType = Model.InsuranceType.itThirdPartyFireAndTheft, Make = "BMW", Model = "X5" });
            Assert.Equal(0, quoteResultAgeSixteen);
            Assert.Equal(500, quoteResultAgeEighty);
            Assert.Equal(510, quoteResultAgeProper);
        }
    }
}
