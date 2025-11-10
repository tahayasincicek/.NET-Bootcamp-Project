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
    public class BootcampManager : IBootcampService
    {
        private readonly IBootcampRepository _bootcampRepository;
        private readonly IMapper _mapper;
        private readonly BootcampBusinessRules _rules;

        public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper, BootcampBusinessRules rules)
        {
            _bootcampRepository = bootcampRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<List<BootcampResponse>> GetAllAsync()
        {
            var bootcamps = await _bootcampRepository.GetAllAsync();
            return _mapper.Map<List<BootcampResponse>>(bootcamps);
        }

        public async Task<BootcampResponse> GetByIdAsync(int id)
        {
            var bootcamp = await _bootcampRepository.GetAsync(b => b.Id == id);
            return _mapper.Map<BootcampResponse>(bootcamp);
        }

        public async Task AddAsync(CreateBootcampRequest request)
        {
            await _rules.CheckBootcampRulesOnCreate(request);

            var bootcamp = _mapper.Map<Bootcamp>(request);
            await _bootcampRepository.AddAsync(bootcamp);
        }

        public async Task UpdateAsync(UpdateBootcampRequest request)
        {
            var bootcamp = _mapper.Map<Bootcamp>(request);
            await _bootcampRepository.UpdateAsync(bootcamp);
        }

        public async Task DeleteAsync(int id)
        {
            var bootcamp = await _bootcampRepository.GetAsync(b => b.Id == id);
            if (bootcamp != null)
                await _bootcampRepository.DeleteAsync(bootcamp);
        }
    }
}
