using AutoMapper;
using EmployeePaymentSystem.Application.Services.Season;
using EmployeePaymentSystem.Application.Services.Season.Dtos;
using EmployeePaymentSystem.Web.Models;
using EmployeePaymentSystem.Web.Models.Season;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePaymentSystem.Web.Controllers
{
    public class SeasonController : Controller
    {
        private readonly ISeasonService _seasonService;
        private readonly IMapper _mapper;

        public SeasonController(
            ISeasonService seasonService,
            IMapper mapper)
        {
            _seasonService = seasonService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(IndexRequestModel model)
        {
            var request = _mapper.Map<GetAllSeasonsRequestDto>(model);
            var response = await _seasonService.GetAllSeasons(request).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                return NotFound();
            }

            var mappedResponse = _mapper.Map<PagedResponseModel<IndexResponseModel>>(response.Data);
            return View(mappedResponse);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSeasonRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var request = _mapper.Map<CreateSeasonRequestDto>(model);
            var response = await _seasonService.CreateSeason(request).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var response = await _seasonService.GetSeasonById(id).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                return NotFound();
            }

            var model = _mapper.Map<UpdateSeasonRequestModel>(response.Data);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, UpdateSeasonRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var request = _mapper.Map<UpdateSeasonRequestDto>(model);
            var response = await _seasonService.UpdateSeason(request).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _seasonService.DeleteSeason(id).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
