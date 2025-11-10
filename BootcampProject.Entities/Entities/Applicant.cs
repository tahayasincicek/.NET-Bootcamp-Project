using System.Collections.Generic;

namespace BootcampProject.Entities
{
    public class Applicant : User
    {
        public string About { get; set; } = null!;
        public ICollection<Application>? Applications { get; set; }
    }
}
