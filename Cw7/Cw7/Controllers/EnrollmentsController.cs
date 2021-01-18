using Cw7.DTOs.Requests;
using Cw7.DTOs.Responses;
using Cw7.Models;
using Cw7.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw7.Controllers
{
    [Route("api/enrollments")]
    [Authorize(Roles = "employee")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private IStudentsDbService _service;

        public EnrollmentsController(IStudentsDbService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            try
            {
                var enr = _service.EnrollStudent(request);

                return Ok(enr);

            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }
    }
}
