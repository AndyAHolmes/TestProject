using System;
using ExerciseApp.Model;
using ExerciseApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExerciseApp.Storeage;


namespace ExerciseApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController : ControllerBase
    {
        
        private readonly QuoteService _quoteService = new QuoteService(17, 80); //Pass min_age and max_age into quoteService
        public QuoteController()
        {

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
            if (TryValidateModel(request) && _quoteService.isValidAge((DateTime)request.DateOfBirth)) // Check if DOB is valid
            {
                returnObject.QuoteRequestValid = true;
                returnObject.Quote = _quoteService.PerformQuote(request);
            }

            //Store the request object into singleton instance
            SingletonDB singleDB = SingletonDB.GetInstance;
            singleDB.addRequest(request);

            return returnObject;
        }

    }
}
