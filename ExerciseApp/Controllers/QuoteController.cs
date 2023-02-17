using System;
using ExerciseApp.Context;
using ExerciseApp.Model;
using ExerciseApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController : ControllerBase
    {
        private readonly DatabaseContext _db;
        private readonly QuoteService _quoteService = new QuoteService();

        public QuoteController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public QuoteDetail Get()
        {
            return _quoteService.GetQuoteDetail();
        }

        [HttpPost]
        public QuoteResponse Post(QuoteRequest request)
        {
            var returnObject = new QuoteResponse { QuoteRequestValid = false };
            var ticks = DateTime.Now.Ticks;
            
            if (TryValidateModel(request))
            {
                returnObject.QuoteRequestValid = true;
                returnObject.Quote = _quoteService.PerformQuote(request);

                _db.Quote.Add(new Quote
                {
                    Id = ticks,
                    DateOfBirth = request.DateOfBirth,
                    InsuranceType = request.InsuranceType,
                    Make = request.Make,
                    Model = request.Model,
                    QuoteReturned = returnObject.Quote
                });

                _db.SaveChanges();
            }

            return returnObject;
        }
    }
}