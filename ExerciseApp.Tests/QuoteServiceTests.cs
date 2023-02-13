using ExerciseApp.Services;
using ExerciseApp.Controllers;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExerciseApp.Tests
{
    public class QuoteServiceTests
    {
        [Fact]
        public void WhenDetailsAreProvided_AQuoteIsProduced()
        {
            var qs = new QuoteService(17,80);
            var quoteResult = qs.PerformQuote(new Model.QuoteRequest { DateOfBirth = new DateTime(2000, 05, 01), InsuranceType = Model.InsuranceType.itFullyComprehensive, Make= "Ford", Model="Focus"});
            Assert.Equal(200, quoteResult);
        }

        [Fact]
        public void WhenAgeIsValid_TrueIsReturn()
        {
            var qs = new QuoteService(17, 80);
            var result = qs.isValidAge(new DateTime(2000, 05, 01));
            Assert.True(result);
        }

        [Fact]
        public void WhenAgeIsInValid_FalseIsReturn()
        {
            var qs = new QuoteService(17, 80);
            var result = qs.isValidAge(new DateTime(1900, 05, 01));
            Assert.False(result);

            result = qs.isValidAge(new DateTime(2020, 05, 01));
            Assert.False(result);

        }

    }
}

