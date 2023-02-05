using ExerciseApp.Context;
using ExerciseApp.Model;
using ExerciseApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace ExerciseApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController : ControllerBase
    {

        private readonly ApplicationContext _db;
        private readonly QuoteService _quoteService = new QuoteService();
        public QuoteController(ApplicationContext db)
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
            var returnObject = new QuoteResponse() { QuoteRequestValid = false };
            try
            {
                if (TryValidateModel(request))
                {
                    returnObject.QuoteRequestValid = true;
                    returnObject.Quote = _quoteService.PerformQuote(request);
                    _db.QuoteEstimations.Add(new QuoteEstimation
                    {
                        quoteRequest = request,
                        quoteResponse = returnObject
                    });
                    _db.SaveChanges();
                }
            }
            catch (Exception ex) { 
            //May log errors
            }
            return returnObject;
        }

    }
}
