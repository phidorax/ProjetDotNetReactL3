﻿using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClassementController : ControllerBase
    {
        private readonly IClassementsService classementsService;

        public ClassementController(IClassementsService classementsService)
        {
            this.classementsService = classementsService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Classement>> GetAll()
        {
            try
            {
                var classement = classementsService.GetAllClassements();

                if (classement.Any())
                {
                    return Ok(classement);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}

