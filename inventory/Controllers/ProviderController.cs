using inventory.Api.Request;
using inventory.Data.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Constants = inventory.Api.Utils.Constants;

namespace inventory.Api.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    [Produces("application/json")]
    public class ProviderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProviderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("providers")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProviderRequest request)
        {
            //Validaciones
            if (request == null)
                return BadRequest(new { message = Constants.INVALID_REQUEST, detail = Constants.NULL_REQUEST });

            if (String.IsNullOrEmpty(request.Name))
                return BadRequest(new { message = Constants.INVALID_REQUEST, detail = "Name, the field name cannot be null or empty." });

            var newStatus = await _unitOfWork.Provider.CreateAsync(request.Name);
            if (!newStatus)
                return BadRequest(new { message = Constants.GENERIC_ERROR });

            return Ok();
        }

        [Route("providers")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? select, [FromQuery] string? order, [FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {

            var providerList = await _unitOfWork.Provider.GetAllAsync(select, order, page, pageSize);
            return Ok(new { Providers = providerList });
        }

        [Route("providers/{providerId}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int providerId, [FromQuery] string? select)
        {
            if (providerId == 0)
                return BadRequest(new { message = Constants.INVALID_ID, detail = "providerId : You must provide a valid Id." });

            var validId = await _unitOfWork.Provider.CheckIfExistsAsync(providerId);
            if (!validId)
                return StatusCode(StatusCodes.Status404NotFound);

            var rol = await _unitOfWork.Provider.GetByIdAsync(providerId, select);
            if (rol == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return Ok(new { rol });
        }
    }
}
