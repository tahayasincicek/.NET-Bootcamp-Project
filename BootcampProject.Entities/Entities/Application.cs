using BootcampProject.Entities.Enums;

namespace BootcampProject.Entities
{
    public class Application
    {
        public int Id { get; set; }

        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; } = null!;

        public int BootcampId { get; set; }
        public Bootcamp Bootcamp { get; set; } = null!;

        public ApplicationState ApplicationState { get; set; }
    }
}
