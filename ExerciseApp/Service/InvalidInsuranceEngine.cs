using ExerciseApp.Model;

namespace ExerciseApp.Service
{
    public class InvalidInsuranceEngine : InsuranceQuoteEngine
    {
        public decimal GenerateQuote(QuoteRequest request)
        {
            return 0;
        }
    }
}

