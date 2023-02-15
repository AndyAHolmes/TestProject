using System;
using ExerciseApp.Model;

namespace ExerciseApp.Service
{
	public class FullyCompInsuranceEngine : InsuranceQuoteEngine
	{
		public FullyCompInsuranceEngine()
		{
		}

        public decimal GenerateQuote(QuoteRequest request)
        {
            if (request.Make == "Ford")
                return 200;
            if (request.Make == "BMW")
            {
                if (request.Model == "X5")
                    return 500;
                else
                    return 400;
            }
            return 300;
        }
    }
}

