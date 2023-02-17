using System;
namespace ExerciseApp.Model;

public class Quote
{
	public string QuoteUID { get; set; }
	public QuoteRequest QuoteRequest { get; set; }
	public decimal QuoteAmount { get; set; }
}

