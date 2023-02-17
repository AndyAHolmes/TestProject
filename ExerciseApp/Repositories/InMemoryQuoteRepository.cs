using System;
using System.Collections.Generic;
using System.Linq;
using ExerciseApp.Model;

namespace ExerciseApp.Repositories;

public class InMemoryQuoteRepository : IQuoteRepository
{
	public List<Quote> Quotes { get; set; }
	public InMemoryQuoteRepository()
	{
    Quotes = new List<Quote>();
	}

	public string StoreQuote(QuoteRequest quoteRequest, decimal quote)
	{
		var newUid = Guid.NewGuid().ToString();
		Quotes.Add(new Quote
		{
			QuoteUID = newUid,
			QuoteRequest = quoteRequest,
			QuoteAmount = quote
		});
		return newUid;
	}

	public Quote RetrieveQuote(string quoteUID)
	{
		return Quotes.FirstOrDefault(q => q.QuoteUID == quoteUID);
	}
}

