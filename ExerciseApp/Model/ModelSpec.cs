using System.Collections.Generic;

namespace ExerciseApp.Model
{
    public class ModelSpec {
        public ModelSpec() {
            Models = new List<string>();
        }

        public string Make { get; set; }
        public List<string> Models { get; private set; }
    }
}


