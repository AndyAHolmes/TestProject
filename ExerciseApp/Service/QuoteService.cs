using System;
using ExerciseApp.Model;
using ExerciseApp.Repositories;
using ExerciseApp.Service;

namespace ExerciseApp.Services;

public class QuoteService : IQuoteService
{
    private readonly IInsuranceQuoteFactory insuranceQuoteFactory;
    private readonly IQuoteRepository quoteRepository;

    public QuoteService(IInsuranceQuoteFactory insuranceQuoteFactory, IQuoteRepository quoteRepository)
    {
        this.insuranceQuoteFactory = insuranceQuoteFactory;
        this.quoteRepository = quoteRepository;
    }

    public QuoteDetail GetQuoteDetail()
    {
        var quoteDetail = new QuoteDetail();

        quoteDetail.Makes.Add("Ford");
        quoteDetail.Makes.Add("Audi");
        quoteDetail.Makes.Add("BMW");

        var modelSpec = new ModelSpec { Make = "Ford" };
        modelSpec.Models.AddRange(new[] { "Fiesta", "Focus", "Puma", "S Max" });
        quoteDetail.Models.Add(modelSpec);

        modelSpec = new ModelSpec { Make = "Audi" };
        modelSpec.Models.AddRange(new[] { "A3", "A4", "A5" });
        quoteDetail.Models.Add(modelSpec);

        modelSpec = new ModelSpec { Make = "BMW" };
        modelSpec.Models.AddRange(new[] { "X5", "3 Series", "5 Series" });
        quoteDetail.Models.Add(modelSpec);

        return quoteDetail;
    }

    public decimal PerformQuote(QuoteRequest request)
    {
        ValidateRequest(request);

        var engine = insuranceQuoteFactory.GetInsuranceTypeEngine(request.InsuranceType);

        return engine.GenerateQuote(request);
    }

    public string StoreQuote(QuoteRequest request, decimal quoteAmount) => quoteRepository.StoreQuote(request, quoteAmount);

    public Quote RetrieveQuote(string quoteUID) => quoteRepository.RetrieveQuote(quoteUID);

    private void ValidateRequest(QuoteRequest request)
    {
        int maxAgeInYears = 80;
        int minAgeInYears = 17;

        if (request.DateOfBirth < DateTime.UtcNow.AddYears(0 - maxAgeInYears)) 
            throw new Exception($"Quote request exceeds maximum age limit in years: {maxAgeInYears}");


        if (request.DateOfBirth > DateTime.UtcNow.AddYears(0 - minAgeInYears))
            throw new Exception($"Quote request is under the minimum age limit in years: {minAgeInYears}");

    }
}
