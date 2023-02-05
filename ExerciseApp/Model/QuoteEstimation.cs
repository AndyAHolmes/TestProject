using System.ComponentModel.DataAnnotations;

namespace ExerciseApp.Model
{
    public class QuoteEstimation
    {
        [Key]
        public int Id { get; set; }
        public QuoteResponse quoteResponse { get; set; }
        public QuoteRequest quoteRequest { get; set; }
    }
}
