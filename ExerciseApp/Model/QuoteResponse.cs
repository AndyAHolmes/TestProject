using System.ComponentModel.DataAnnotations;

namespace ExerciseApp.Model
{
    public class QuoteResponse
    {
        [Key]
        public int Id { get; set; }
        public bool QuoteRequestValid { get; set; }
        public decimal Quote { get; set; }
    }
}
