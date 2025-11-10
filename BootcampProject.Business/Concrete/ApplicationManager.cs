using AutoMapper;
using BootcampProject.Business.Abstracts;
using BootcampProject.Business.BusinessRules;
using BootcampProject.Business.DTOs.Requests;
using BootcampProject.Business.DTOs.Responses;
using BootcampProject.DataAccess.Repositories.Interfaces;
using BootcampProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootcampProject.Business.Concrete
{
    public class ApplicationManager : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationBusinessRules _rules;

        public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper, ApplicationBusinessRules rules)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<List<ApplicationResponse>> GetAllAsync()
        {
            var apps = await _applicationRepository.GetAllAsync();
            return _mapper.Map<List<ApplicationResponse>>(apps);
        }

        public async Task<ApplicationResponse> GetByIdAsync(int id)
        {
            var app = await _applicationRepository.GetAsync(a => a.Id == id);
            return _mapper.Map<ApplicationResponse>(app);
        }

        public async Task AddAsync(CreateBootcampRequest request)
        {
            await _rules.CheckApplicantCanApply(request.ApplicantId, request.BootcampId);

            var app = _mapper.Map<Application>(request);
            await _applicationRepository.AddAsync(app);
        }

        public async Task UpdateAsync(UpdateBootcampRequest request)
        {
            var app = _mapper.Map<Application>(request);
            await _applicationRepository.UpdateAsync(app);
        }

        public async Task DeleteAsync(int id)
        {
            var app = await _applicationRepository.GetAsync(a => a.Id == id);
            if (app != null)
                await _applicationRepository.DeleteAsync(app);
        }
    }
}
