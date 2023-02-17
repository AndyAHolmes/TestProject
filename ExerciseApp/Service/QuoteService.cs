using System;
using ExerciseApp.Helpers;
using ExerciseApp.Model;

namespace ExerciseApp.Services
{
    public class QuoteService
    {
        public QuoteDetail GetQuoteDetail()
        {
            var quoteDetail = new QuoteDetail();

            quoteDetail.Makes.Add(Constants.Makes.Ford);
            quoteDetail.Makes.Add(Constants.Makes.Audi);
            quoteDetail.Makes.Add(Constants.Makes.Bmw);

            var modelSpec = new ModelSpec { Make = Constants.Makes.Ford };
            modelSpec.Models.AddRange(new []{ Constants.Models.Fiesta, Constants.Models.Focus, Constants.Models.Puma, Constants.Models.SMax });
            quoteDetail.Models.Add(modelSpec);

            modelSpec = new ModelSpec { Make = Constants.Makes.Audi };
            modelSpec.Models.AddRange(new[] { Constants.Models.A3, Constants.Models.A4, Constants.Models.A5 });
            quoteDetail.Models.Add(modelSpec);

            modelSpec = new ModelSpec { Make = Constants.Makes.Bmw };
            modelSpec.Models.AddRange(new[] { Constants.Models.X5, Constants.Models.Series3, Constants.Models.Series5 });
            quoteDetail.Models.Add(modelSpec);

            return quoteDetail;
        }

        public string PerformQuote(QuoteRequest request)
        {
            if (!request.DateOfBirth.CalculateIfAgeIsValid())
            {
                return "We cannot provide a quote for you at this time, you do not meet the required criteria";
            }

            switch (request.InsuranceType)
            {
                case InsuranceType.itFullyComprehensive:
                    return request.CalculateFullyComprehensive().ConvertQuoteToString();
                case InsuranceType.itThirdPartyFireAndTheft:
                    return request.CalculateThirdPartyFireAndTheft().ConvertQuoteToString();
                case InsuranceType.itThirdPartyOnly:
                    return request.CalculateThirdPartyOnly().ConvertQuoteToString();
                default:
                    return "Insurance Type not specified";
            }
        }

        public bool CalculateIfAgeIsValid(DateTime? dateOfBirth)
        {
            return dateOfBirth.CalculateIfAgeIsValid();
        }
    }
}
