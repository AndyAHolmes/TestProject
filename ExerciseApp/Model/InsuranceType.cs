using System.ComponentModel;

namespace ExerciseApp.Model;

public enum InsuranceType {
    [Description("Fully Comprehensive")]
    itFullyComprehensive,
    [Description("Third Party Fire & Theft")]
    itThirdPartyFireAndTheft,
    [Description("Third Party Only")]
    itThirdPartyOnly
};


