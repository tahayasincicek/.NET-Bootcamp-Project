using BootcampProject.Entities.Entities;
using System.Collections.Generic;

namespace BootcampProject.Entities
{
    public class Instructor : User
    {
        public string CompanyName { get; set; } = null!;
        public ICollection<Bootcamp>? Bootcamps { get; set; }
    }
}
