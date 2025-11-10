using BootcampProject.Entities.Enums;

namespace BootcampProject.Business.DTOs.Responses
{
    public class ApplicationResponse
    {
        public int Id { get; set; }
        public string ApplicantFullName { get; set; } = null!;
        public string BootcampName { get; set; } = null!;
        public ApplicationState ApplicationState { get; set; }
    }
}
