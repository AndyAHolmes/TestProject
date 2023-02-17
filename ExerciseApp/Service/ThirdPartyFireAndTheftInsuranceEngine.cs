using System;
using ExerciseApp.Model;

namespace ExerciseApp.Service;

	public class ThirdPartyFireAndTheftInsuranceEngine : InsuranceQuoteEngine
	{
    public override decimal GenerateQuote(QuoteRequest request)
    {
        if (request.Make == "Ford")
            return 180;
        if (request.Make == "BMW")
        {
            if (request.Model == "X5")
                return 510;
            else
                return 400;
        }
        return 300;
    }
}

