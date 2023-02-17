using System;
using ExerciseApp.Model;

namespace ExerciseApp.Service;

public class InsuranceQuoteEngine
{
    public virtual decimal GenerateQuote(QuoteRequest request) => 0;
}

