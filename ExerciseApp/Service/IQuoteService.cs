using ExerciseApp.Model;

namespace ExerciseApp.Services
{
    public interface IQuoteService
    {
        QuoteDetail GetQuoteDetail();
        decimal PerformQuote(QuoteRequest request);
    }
}