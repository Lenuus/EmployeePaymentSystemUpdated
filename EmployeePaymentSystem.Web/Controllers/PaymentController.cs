using AutoMapper;
using EmployeePaymentSystem.Application.Services.Employee;
using EmployeePaymentSystem.Application.Services.Employee.Dtos;
using EmployeePaymentSystem.Application.Services.Payment;
using EmployeePaymentSystem.Application.Services.Payment.Dtos;
using EmployeePaymentSystem.Application.Services.Season;
using EmployeePaymentSystem.Application.Services.Season.Dtos;
using EmployeePaymentSystem.Web.Models;
using EmployeePaymentSystem.Web.Models.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePaymentSystem.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;
        private readonly ISeasonService _seasonService;

        public PaymentController(
            IPaymentService paymentService,
            IMapper mapper,
            IEmployeeService employeeService,
            ISeasonService seasonService)
        {
            _paymentService = paymentService;
            _mapper = mapper;
            _employeeService = employeeService;
            _seasonService = seasonService;
        }

        // GET: PaymentController
        public async Task<IActionResult> Index(PaymentIndexRequestModel model)
        {
            var requestMapped = _mapper.Map<PaymentPagedRequestDto>(model);
            var response = await _paymentService.GetAllPayments(requestMapped).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                return NotFound();
            }

            var responseMapped = _mapper.Map<PagedResponseModel<PaymentListResponseModel>>(response.Data);
            return View(responseMapped);
        }

        // GET: PaymentController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Employees = (await _employeeService.GetAllEmployees(new GetAllEmployeesRequestDto()).ConfigureAwait(false)).Data.Data;
            ViewBag.Seasons = (await _seasonService.GetAllSeasons(new GetAllSeasonsRequestDto()).ConfigureAwait(false)).Data.Data;
            return View();
        }

        // POST: PaymentController/Create
        [HttpPost]
        public async Task<IActionResult> Create(PaymentCreateRequestModel model)
        {
            var requestMapped = _mapper.Map<AddPaymentRequestDto>(model);
            var response = await _paymentService.AddPayment(requestMapped).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                ViewBag.ErrorMessage = response.ErrorMessage;
                ViewBag.Employees = (await _employeeService.GetAllEmployees(new GetAllEmployeesRequestDto()).ConfigureAwait(false)).Data.Data;
                ViewBag.Seasons = (await _seasonService.GetAllSeasons(new GetAllSeasonsRequestDto()).ConfigureAwait(false)).Data.Data;
                return View(model);
            }

            return RedirectToAction("Index");
        }

        // GET: PaymentController/Update/id
        public async Task<IActionResult> Update(Guid id)
        {
            ViewBag.Employees = (await _employeeService.GetAllEmployees(new GetAllEmployeesRequestDto()).ConfigureAwait(false)).Data.Data;
            ViewBag.Seasons = (await _seasonService.GetAllSeasons(new GetAllSeasonsRequestDto()).ConfigureAwait(false)).Data.Data;
            var response = await _paymentService.GetPaymentDetail(id).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                return NotFound();
            }

            var model = new PaymentUpdateRequestModel()
            {
                Id = id,
                Currency = response.Data.Currency,
                EmployeeId = response.Data.EmployeeId,
                Payment = response.Data.Payment,
                PaymentType = response.Data.PaymentType,
                SeasonId = response.Data.SeasonId
            };
            return View(model);
        }

        // POST: PaymentController/Update/id
        [HttpPost]
        public async Task<IActionResult> Update(PaymentUpdateRequestModel model)
        {
            var requestMapped = _mapper.Map<UpdatePaymentRequestDto>(model);
            var response = await _paymentService.UpdatePayment(requestMapped).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                ViewBag.ErrorMessage = response.ErrorMessage;
                ViewBag.Employees = (await _employeeService.GetAllEmployees(new GetAllEmployeesRequestDto()).ConfigureAwait(false)).Data.Data;
                ViewBag.Seasons = (await _seasonService.GetAllSeasons(new GetAllSeasonsRequestDto()).ConfigureAwait(false)).Data.Data;
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _paymentService.DeletePayment(id).ConfigureAwait(false);
            if (!response.IsSuccessful)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
