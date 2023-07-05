using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Domain.DTOs.Requests;
using Students.Domain.DTOs.Responses;
using Students.Domain.Entities;
using Students.Services.AppServices.Interfaces;
using StudentsApi.Utils;
using StudentsApi.Validators;

namespace StudentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly ITeacherInteractor _teacherInteractor;

        public TeacherController(ILogger<TeacherController> logger, ITeacherInteractor teacherInteractor)
        {
            _logger = logger;
            _teacherInteractor = teacherInteractor;
        }


        [ProducesResponseType(type: typeof(ApiResponse<Teacher?>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(ApiResponse<Teacher?>), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        [HttpPost("AddTeacher")]
        public async Task<IActionResult> AddTeacher(AddTeacherDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _teacherInteractor.AddTeacher(dto);
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ErrorUtil.OutputErrorString(ex));
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<Teacher?> { Success = false, Errors = ErrorUtil.ReturnErrorList(ex) });
            }
        }


        [ProducesResponseType(type: typeof(ApiResponse<Teacher?>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(ApiResponse<Teacher?>), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        [HttpGet("GetTeachers")]
        public async Task<IActionResult> GetTeachers()
        {
            try
            {
                var result = await _teacherInteractor.GetTeachers();
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ErrorUtil.OutputErrorString(ex));
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<Teacher?> { Success = false, Errors = ErrorUtil.ReturnErrorList(ex) });
            }
        }
    }
}
