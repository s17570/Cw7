﻿using Cw7.DTOs.Requests;
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
    [Route("api/enrollments/promotions")]
    [Authorize(Roles = "employee")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private IStudentsDbService _service;

        public PromotionsController(IStudentsDbService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult PromoteStudents(PromoteStudentsRequest request)
        {
            try
            {
                var psr = _service.PromoteStudents(request);

                return Ok(psr);

            }
            catch (Exception exc)
            {
                return BadRequest(exc.ToString());
            }
        }
    }
}
