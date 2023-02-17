using ExerciseApp.Model;
using ExerciseApp.Repositories;

namespace ExerciseApp.Services;

public interface IQuoteService
{
    QuoteDetail GetQuoteDetail();
    decimal PerformQuote(QuoteRequest request);
    string StoreQuote(QuoteRequest request, decimal quoteAmount);
    Quote RetrieveQuote(string quoteUID);
}