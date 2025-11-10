namespace BootcampProject.Business.DTOs.Requests
{
    public class UpdateApplicationRequest
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public int BootcampId { get; set; }
    }
}
