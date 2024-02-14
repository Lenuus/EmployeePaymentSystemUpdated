using AutoMapper;
using EmployeePaymentSystem.Application.Services.Season.Dtos;
using EmployeePaymentSystem.Common.Dto;
using EmployeePaymentSystem.Common.Helpers;
using Microsoft.EntityFrameworkCore;

namespace EmployeePaymentSystem.Application.Services.Season
{
    public class SeasonService : ISeasonService
    {
        private readonly IRepository<Domain.Season> _seasonRepository;
        private readonly IMapper _mapper;

        public SeasonService(
            IRepository<Domain.Season> seasonRepository,
            IMapper mapper)
        {
            _seasonRepository = seasonRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<ServiceResponse<SeasonDetailDto>> GetSeasonById(Guid id)
        {
            var Season = await _seasonRepository.GetById(id).ConfigureAwait(false);
            if (Season == null)
            {
                return new ServiceResponse<SeasonDetailDto>(null, false, "Not found.");
            }

            var response = _mapper.Map<SeasonDetailDto>(Season);
            return new ServiceResponse<SeasonDetailDto>(response, true, string.Empty);
        }

        public async Task<ServiceResponse<PagedResponseDto<SeasonListDto>>> GetAllSeasons(GetAllSeasonsRequestDto request)
        {
            var query = await _seasonRepository.GetAll()
                .Where(f => !f.IsDeleted && (!string.IsNullOrEmpty(request.Search) ? (f.Name).Contains(request.Search) : true))
                .Select(f => new SeasonListDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    StartDate = f.StartDate,
                    EndDate = f.EndDate
                }).ToPagedListAsync(request.PageSize, request.PageIndex);

            return new ServiceResponse<PagedResponseDto<SeasonListDto>>(query, true, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<ServiceResponse> DeleteSeason(Guid id)
        {
            try
            {
                await _seasonRepository.DeleteById(id).ConfigureAwait(false);
                return new ServiceResponse(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new ServiceResponse(false, ex.Message);
            }
        }

        /// <inheritdoc/>
        public async Task<ServiceResponse> CreateSeason(CreateSeasonRequestDto request)
        {
            if (request == null)
            {
                return new ServiceResponse(false, "Lütfen formu doldurun");
            }

            var entity = _mapper.Map<Domain.Season>(request);
            await _seasonRepository.Create(entity);
            return new ServiceResponse(true, string.Empty);
        }

        public async Task<ServiceResponse> UpdateSeason(UpdateSeasonRequestDto request)
        {
            if (request == null)
            {
                return new ServiceResponse(false, "Lütfen formu doldurun");
            }
            
            var Season = await _seasonRepository.GetById(request.Id).ConfigureAwait(false);
            if (Season == null)
            {
                return new ServiceResponse(false, "Not Found");
            }

            Season.Name = request.Name;
            Season.EndDate = request.EndDate;
            Season.StartDate = request.StartDate;
            await _seasonRepository.Update(Season);
            return new ServiceResponse(true, string.Empty);
        }
    }
}
