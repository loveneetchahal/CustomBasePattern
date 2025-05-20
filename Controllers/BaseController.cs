using CustomBasePattern.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomBasePattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult SuccessResponse<T>(T data, string message = null, object pagination = null)
        {
            var response = new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data,
                Pagination = pagination
            };
            return Ok(response);
        }

        protected IActionResult ErrorResponse(string message)
        {
            var response = new ApiResponse<string>
            {
                Success = false,
                Message = message,
                Data = null
            };
            return BadRequest(response);
        }

        protected IActionResult ValidationErrorResponse()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return BadRequest(new ApiResponse<List<string>>
            {
                Success = false,
                Message = "Validation failed.",
                Data = errors
            });
        }

    }
}
