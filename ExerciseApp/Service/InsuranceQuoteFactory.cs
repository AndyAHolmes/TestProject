using System;
using ExerciseApp.Model;

namespace ExerciseApp.Service
{
    public class InsuranceQuoteFactory : IInsuranceQuoteFactory
    {
        private readonly IServiceProvider serviceProvider;

        public InsuranceQuoteFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public InsuranceQuoteEngine GetInsuranceTypeEngine(InsuranceType? insuranceType)
        {
            if (insuranceType == InsuranceType.itFullyComprehensive)
            {
                return (InsuranceQuoteEngine)serviceProvider.GetService(typeof(FullyCompInsuranceEngine));
            }
            if (insuranceType == InsuranceType.itThirdPartyFireAndTheft)
            {
                return (InsuranceQuoteEngine)serviceProvider.GetService(typeof(ThirdPartyFireAndTheftInsuranceEngine));
            }
            if (insuranceType == InsuranceType.itThirdPartyOnly)
            {
                return (InsuranceQuoteEngine)serviceProvider.GetService(typeof(ThirdPartyInsuranceEngine));
            }
            return (InsuranceQuoteEngine)serviceProvider.GetService(typeof(InvalidInsuranceEngine));
        }
    }
}

