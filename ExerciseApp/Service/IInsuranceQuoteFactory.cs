using ExerciseApp.Model;

namespace ExerciseApp.Service
{
    public interface IInsuranceQuoteFactory
    {
        InsuranceQuoteEngine GetInsuranceTypeEngine(InsuranceType? insuranceType);
    }
}