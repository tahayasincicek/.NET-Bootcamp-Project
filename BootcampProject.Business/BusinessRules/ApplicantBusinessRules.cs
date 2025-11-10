using BootcampProject.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;
using System;

namespace BootcampProject.Business.BusinessRules
{
    public class ApplicantBusinessRules
    {
        private readonly IApplicantRepository _applicantRepo;
        private readonly IBlacklistRepository _blacklistRepo;

        public ApplicantBusinessRules(IApplicantRepository applicantRepo, IBlacklistRepository blacklistRepo)
        {
            _applicantRepo = applicantRepo;
            _blacklistRepo = blacklistRepo;
        }

        public async Task EnsureUniqueNationalityIdentity(string nationalityId)
        {
            var existing = await _applicantRepo.GetAsync(a => a.NationalityIdentity == nationalityId);
            if (existing != null)
                throw new Exception("Bu TC Kimlik Numarası zaten kayıtlı.");
        }

        public async Task EnsureApplicantExists(int applicantId)
        {
            var applicant = await _applicantRepo.GetAsync(a => a.Id == applicantId);
            if (applicant == null)
                throw new Exception("Bu kullanıcı sistemde kayıtlı değil.");
        }

        public async Task EnsureNotBlacklisted(int applicantId)
        {
            var blacklist = await _blacklistRepo.GetAsync(b => b.ApplicantId == applicantId);
            if (blacklist != null)
                throw new Exception("Kullanıcı kara listede olduğu için işlem yapamaz.");
        }
    }
}
