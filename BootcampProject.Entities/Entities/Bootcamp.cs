using BootcampProject.Entities.Enums;
using System.Collections.Generic;
using System;

namespace BootcampProject.Entities
{
    public class Bootcamp
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public BootcampState BootcampState { get; set; }

        public ICollection<Application>? Applications { get; set; }
    }
}
