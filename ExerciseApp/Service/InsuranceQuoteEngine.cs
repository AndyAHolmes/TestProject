using System;
using ExerciseApp.Model;

namespace ExerciseApp.Service
{
	public interface InsuranceQuoteEngine
	{
		decimal GenerateQuote(QuoteRequest request);
    }
}

