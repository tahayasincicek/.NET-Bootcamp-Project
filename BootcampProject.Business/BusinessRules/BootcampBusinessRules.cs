using BootcampProject.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;
using System;

namespace BootcampProject.Business.BusinessRules
{
    public class BootcampBusinessRules
    {
        private readonly IBootcampRepository _bootcampRepository;
        private readonly IInstructorRepository _instructorRepository;

        public BootcampBusinessRules(IBootcampRepository bootcampRepository, IInstructorRepository instructorRepository)
        {
            _bootcampRepository = bootcampRepository;
            _instructorRepository = instructorRepository;
        }

        public async Task CheckBootcampRulesOnCreate(CreateBootcampRequest request)
        {
            if (request.StartDate >= request.EndDate)
                throw new Exception("Başlangıç tarihi, bitiş tarihinden önce olmalıdır.");

            var sameName = await _bootcampRepository.GetAsync(b => b.Name == request.Name);
            if (sameName != null)
                throw new Exception("Bu isimde bir Bootcamp zaten var.");

            var instructor = await _instructorRepository.GetAsync(i => i.Id == request.InstructorId);
            if (instructor == null)
                throw new Exception("Eğitmen sistemde kayıtlı değil.");
        }
    }
}
