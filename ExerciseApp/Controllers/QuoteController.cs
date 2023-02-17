using ExerciseApp.Model;
using ExerciseApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseApp.Controllers;

[ApiController]
[Route("[controller]")]
public class QuoteController : ControllerBase
{
    private readonly IQuoteService quoteService;

    public QuoteController(IQuoteService quoteService)
    {
        this.quoteService = quoteService;
    }

    [HttpGet]
    public QuoteDetail Get()
    {
        return quoteService.GetQuoteDetail();
    }

    [HttpPost]
    public QuoteResponse Post(QuoteRequest request)
    {
        var returnObject = new QuoteResponse() { QuoteRequestValid = false };
        if (TryValidateModel(request))
        {
            returnObject.QuoteRequestValid = true;
            returnObject.Quote = quoteService.PerformQuote(request);
            returnObject.QuoteUID = quoteService.StoreQuote(request, returnObject.Quote);
        }
        
        return returnObject;
    }

    [HttpGet("{quoteUID}")]
    public Quote GetPreviousQuote(string quoteUID)
    {
        return quoteService.RetrieveQuote(quoteUID);
    }
}
