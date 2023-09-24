using Vote_Application_JonathanMutala.Others_Class;

namespace Vote_Application_JonathanMutala.ViewModel
{
    public class ElectionViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Country>?  Countries { get; set; }

        public string? City { get; set; } 

        public string? Region { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
