using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Domain.DTOs.Requests;
using Students.Domain.DTOs.Responses;
using Students.Domain.Entities;
using Students.Services.AppServices.Interfaces;
using StudentsApi.Utils;

namespace StudentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentInteractor _studentInteractor;

        public StudentController(ILogger<StudentController> logger, IStudentInteractor studentInteractor)
        {
            _logger = logger;
            _studentInteractor = studentInteractor;
        }


        [ProducesResponseType(type: typeof(ApiResponse<Student?>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(ApiResponse<Student?>), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent(AddStudentDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _studentInteractor.AddStudent(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ErrorUtil.OutputErrorString(ex));
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<Student?> { Success = false, Errors = ErrorUtil.ReturnErrorList(ex) });
            }
        }


        [ProducesResponseType(type: typeof(ApiResponse<Student?>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(ApiResponse<Student?>), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var result = await _studentInteractor.GetStudents();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ErrorUtil.OutputErrorString(ex));
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<Student?> { Success = false, Errors = ErrorUtil.ReturnErrorList(ex) });
            }
        }
    }
}
