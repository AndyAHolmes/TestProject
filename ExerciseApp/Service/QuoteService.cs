using ExerciseApp.Model;
using Microsoft.VisualBasic;
using System;

namespace ExerciseApp.Services
{
    public class QuoteService
    {
        public QuoteDetail GetQuoteDetail()
        {
            var quoteDetail = new QuoteDetail();

            quoteDetail.Makes.Add("Ford");
            quoteDetail.Makes.Add("Audi");
            quoteDetail.Makes.Add("BMW");

            var modelSpec = new ModelSpec { Make = "Ford" };
            modelSpec.Models.AddRange(new []{ "Fiesta", "Focus", "Puma", "S Max" });
            quoteDetail.Models.Add(modelSpec);

            modelSpec = new ModelSpec { Make = "Audi" };
            modelSpec.Models.AddRange(new[] { "A3", "A4", "A5" });
            quoteDetail.Models.Add(modelSpec);

            modelSpec = new ModelSpec { Make = "BMS" };
            modelSpec.Models.AddRange(new[] { "X5", "3 Series", "5 Series" });
            quoteDetail.Models.Add(modelSpec);

            return quoteDetail;
        }

        public decimal PerformQuote(QuoteRequest request)
        {
            if (request.InsuranceType == InsuranceType.itFullyComprehensive)
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
            if (request.InsuranceType == InsuranceType.itThirdPartyFireAndTheft) {
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
            if (request.InsuranceType == InsuranceType.itThirdPartyOnly)
            {
                if (request.Make == "Ford")
                    return 180;
                if (request.Make == "Audi")
                {
                    return 250;
                }
                return 300;
            }
            var age =  DateTime.Now.Year - request.DateOfBirth.Value.Year;
            if (request.DateOfBirth != null)
            {
                if (age > 18 && age < 80)
                {
                    return 400;
                }
                else {
                    return 300;
                }
            }
            return 0;
        }
    }
}
