using ExerciseApp.Context;
using ExerciseApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace ExerciseApp.Tests
{
    public class QuoteServiceTests
    {
        private readonly ApplicationContext applicationContext;

        [Fact]
        public void WhenDetailsAreProvided_AQuoteIsProduced()
        {
            var qs = new QuoteService();
            var quoteResult = qs.PerformQuote(new Model.QuoteRequest { DateOfBirth = new DateTime(2000, 05, 01), InsuranceType = Model.InsuranceType.itFullyComprehensive, Make = "Ford", Model = "Focus" });
        }
        [Fact]
        public void TestCaseAddEstimate()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
         .UseInMemoryDatabase(databaseName: "Quote")
         .Options;
            using (var context = new ApplicationContext(options))
            {
                var quoteEstimate = new Model.QuoteRequest { DateOfBirth = new DateTime(2000, 05, 01), InsuranceType = Model.InsuranceType.itFullyComprehensive, Make = "Ford", Model = "Focus" };
                context.QuoteEstimations.Add(new Model.QuoteEstimation
                {
                    quoteRequest = quoteEstimate,
                    quoteResponse = new Model.QuoteResponse
                    {
                        Quote = 300,
                        QuoteRequestValid = true,
                    }
                });
                context.SaveChanges();
            }

        }
    }
}
