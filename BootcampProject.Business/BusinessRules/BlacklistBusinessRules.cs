using BootcampProject.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;
using System;

namespace BootcampProject.Business.BusinessRules
{
    public class BlacklistBusinessRules
    {
        private readonly IBlacklistRepository _blacklistRepo;

        public BlacklistBusinessRules(IBlacklistRepository blacklistRepo)
        {
            _blacklistRepo = blacklistRepo;
        }

        public async Task EnsureNoDuplicateBlacklist(int applicantId)
        {
            var existing = await _blacklistRepo.GetAsync(b => b.ApplicantId == applicantId);
            if (existing != null)
                throw new Exception("Bu aday zaten kara listededir.");
        }

        public void EnsureReasonIsProvided(string? reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new Exception("Kara liste sebebi boş olamaz.");
        }
    }
}
