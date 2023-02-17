using System;
using ExerciseApp.Model;

namespace ExerciseApp.Service;

	public class ThirdPartyInsuranceEngine : InsuranceQuoteEngine
	{
    public override decimal GenerateQuote(QuoteRequest request)
    {
        if (request.Make == "Ford")
            return 180;
        if (request.Make == "Audi")
        {
            return 250;
        }
        return 300;
    }
}

