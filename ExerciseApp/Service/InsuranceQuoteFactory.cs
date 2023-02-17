using System;
using ExerciseApp.Model;

namespace ExerciseApp.Service;

public class InsuranceQuoteFactory : IInsuranceQuoteFactory
{
    private FullyCompInsuranceEngine fullyCompEngine;
    private ThirdPartyFireAndTheftInsuranceEngine thirdPartyFandTEngine;
    private ThirdPartyInsuranceEngine thirdPartyEngine;
    private InsuranceQuoteEngine defaultEngine;

    public InsuranceQuoteFactory()
    {
        this.fullyCompEngine = new FullyCompInsuranceEngine();
        this.thirdPartyFandTEngine = new ThirdPartyFireAndTheftInsuranceEngine();
        this.thirdPartyEngine = new ThirdPartyInsuranceEngine();
        this.defaultEngine = new InsuranceQuoteEngine();
    }
    public InsuranceQuoteEngine GetInsuranceTypeEngine(InsuranceType? insuranceType)
    {
        if (insuranceType == InsuranceType.itFullyComprehensive)
        {
            return fullyCompEngine;
        }
        if (insuranceType == InsuranceType.itThirdPartyFireAndTheft)
        {
            return thirdPartyFandTEngine;
        }
        if (insuranceType == InsuranceType.itThirdPartyOnly)
        {
            return thirdPartyEngine;
        }
        return defaultEngine;
    }
}

