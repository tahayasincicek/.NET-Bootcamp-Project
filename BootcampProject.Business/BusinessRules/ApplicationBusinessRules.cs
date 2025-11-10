using BootcampProject.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;
using System;

namespace BootcampProject.Business.BusinessRules
{
    public class ApplicationBusinessRules
    {
        private readonly IApplicationRepository _applicationRepo;
        private readonly IBlacklistRepository _blacklistRepo;

        public ApplicationBusinessRules(IApplicationRepository applicationRepo, IBlacklistRepository blacklistRepo)
        {
            _applicationRepo = applicationRepo;
            _blacklistRepo = blacklistRepo;
        }

        public async Task CheckApplicantCanApply(int applicantId, int bootcampId)
        {
            var isBlacklisted = await _blacklistRepo.GetAsync(b => b.ApplicantId == applicantId);
            if (isBlacklisted != null)
                throw new Exception("Kara listedeki bir kullanıcı başvuru yapamaz.");

            var existing = await _applicationRepo.GetAsync(a => a.ApplicantId == applicantId && a.BootcampId == bootcampId);
            if (existing != null)
                throw new Exception("Aynı bootcamp'e tekrar başvuru yapılamaz.");
        }
    }
}
