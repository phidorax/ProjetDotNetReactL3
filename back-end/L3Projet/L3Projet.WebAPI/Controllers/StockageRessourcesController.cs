using L3Projet.Business.Interfaces;
using L3Projet.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L3Projet.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StockageRessourcesController : ControllerBase
    {
        private readonly IStockageRessourcesService stockageRessoucesService;

        public StockageRessourcesController(IStockageRessourcesService stockageRessoucesService)
        {
            this.stockageRessoucesService = stockageRessoucesService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<StockageRessources>> GetAll()
        {
            try
            {
                var ressources = stockageRessoucesService.GetAllStockageRessources();

                if (ressources.Any())
                {
                    return Ok(ressources);
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

