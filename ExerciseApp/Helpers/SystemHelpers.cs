using System;
using System.Globalization;
using ExerciseApp.Model;

namespace ExerciseApp.Helpers
{
    public static class SystemHelpers
    {
        public static decimal CalculateFullyComprehensive(this QuoteRequest request)
        {
            switch (request.Make)
            {
                case Constants.Makes.Ford:
                    return 200;
                case Constants.Makes.Bmw:
                    return request.Model == Constants.Models.X5 ? 500 : 400;
                default:
                    return 300;
            }
        }

        public static decimal CalculateThirdPartyFireAndTheft(this QuoteRequest request)
        {
            switch (request.Make)
            {
                case Constants.Makes.Ford:
                    return 180;
                case Constants.Makes.Bmw:
                    return request.Model == Constants.Models.X5 ? 510 : 400;
                default:
                    return 300;
            }
        }

        public static decimal CalculateThirdPartyOnly(this QuoteRequest request)
        {
            switch (request.Make)
            {
                case Constants.Makes.Ford:
                    return 180;
                case Constants.Makes.Audi:
                    return 250;
                default:
                    return 300;
            }
        }

        public static bool CalculateIfAgeIsValid(this DateTime? dateOfBirth)
        {
            if (!dateOfBirth.HasValue)
            {
                return false;
            }

            var currentDate = DateTime.Now.Date;
            var is17 = currentDate.AddYears(-17);
            var is80 = currentDate.AddYears(-80);

            return dateOfBirth <= is17 && dateOfBirth > is80;
        }

        public static string ConvertQuoteToString(this decimal quote)
        {
            return $"£{quote.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}