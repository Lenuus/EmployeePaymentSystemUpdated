using EmployeePaymentSystem.Application.Services.Season.Dtos;
using EmployeePaymentSystem.Common.Dto;

namespace EmployeePaymentSystem.Application.Services.Season
{
    public interface ISeasonService
    {
        /// <summary>
        /// GetSeasonById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<SeasonDetailDto>> GetSeasonById(Guid id);

        /// <summary>
        /// Get All Seasons based request data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse<PagedResponseDto<SeasonListDto>>> GetAllSeasons(GetAllSeasonsRequestDto request);

        /// <summary>
        /// Delete Employe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse> DeleteSeason(Guid id);

        /// <summary>
        /// Create Season
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> CreateSeason(CreateSeasonRequestDto request);

        /// <summary>
        /// UpdateSeason
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ServiceResponse> UpdateSeason(UpdateSeasonRequestDto request);
    }
}
