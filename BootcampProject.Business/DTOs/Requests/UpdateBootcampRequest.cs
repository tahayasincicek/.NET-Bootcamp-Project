using BootcampProject.Entities.Enums;
using System;

namespace BootcampProject.Business.DTOs.Requests
{
    public class UpdateBootcampRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public BootcampState BootcampState { get; set; }
    }
}
