using System;
using ExerciseApp.Model;

namespace ExerciseApp.Repositories
{
	public interface IQuoteRepository
	{
		string StoreQuote(QuoteRequest quoteRequest, decimal quoteAmount);
		Quote RetrieveQuote(string quoteUID);
	}
}

