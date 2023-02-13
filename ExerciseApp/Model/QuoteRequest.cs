using System;
using System.ComponentModel.DataAnnotations;
//Simply uncomment below to enable attribute valiation
//using static ExerciseApp.Validators.CustomValidation;

namespace ExerciseApp.Model
{
    public class QuoteRequest
    {
        [DataType(DataType.Date)]
        [Required]
        //Simply uncomment below to enable attribute valiation
        //[checkDateOfBirth(ErrorMessage = ("People under the age of 17 and over the age of 80 can not receive a quote"))]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        [Required(AllowEmptyStrings =false)]
        public string Make { get; set; }

        [StringLength(10)]
        [Required(AllowEmptyStrings = false)]
        public string Model { get; set; }

        [Required]
        public InsuranceType? InsuranceType { get; set; }
    }
}
