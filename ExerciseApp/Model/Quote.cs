using System;
using System.ComponentModel.DataAnnotations;

namespace ExerciseApp.Model
{
    public class Quote
    {
        [Key]
        public long Id { get; set; }
        
        public DateTime? DateOfBirth { get; set; }
        
        public string Make { get; set; }
        
        public string Model { get; set; }
        
        public InsuranceType? InsuranceType { get; set; }

        public string QuoteReturned { get; set; }
    }
}