using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VaquesBackend.Db;
using VaquesBackend.Models;
using VaquesBackend.Services;

namespace VaquesBackend.Controllers
{
    [ApiController]
    [Route("vaques")]
    public class CampController : ControllerBase
    {


        private readonly ILogger<CampController> _logger;
        private readonly ICampService _campService;

        public CampController(ICampService campService, ILogger<CampController> logger)
        {
            _logger = logger;
            _campService = campService;
        }

        [HttpGet]
        [Route("start/{num}")]
        public IEnumerable<IVaca> IniciaCamp(int num)
        {
            _campService.init(num);
            return _campService.getCasa();
        }

        [HttpGet]
        [Route("camp")]
        public IEnumerable<IVaca> GetVaquesDelCamp()
        {
            return _campService.getCasa();
        }

        [HttpGet("camio")]
        public IEnumerable<IVaca> GetVaquesDelCamio()
        {
            return _campService.getCamio();
        }


        [HttpGet("ciutat")]
        public IEnumerable<IVaca> GetVaquesDeLaCiutat()
        {
            return _campService.getCiutat();
        }

        [HttpGet("posacamio/{nom}")]
        public IActionResult PosaVacaAlCamio(string nom)
        {
            if (_campService.PosaVacaAlCamio(nom))
            {
                return Ok(new Result
                {
                    Resultat = "Ok"
                });
            }
            else
            {
                return NotFound(new Result
                {
                    Resultat = "La vaca no hi cap al camió"
                });
            }
        }

        [HttpGet("posacamp/{nom}")]
        public IActionResult TornaVacaAlCamp(string nom)
        {
            if (_campService.PosaVacaAlCamp(nom))
            {
                return Ok(new Result
                {
                    Resultat = "Ok"
                });
            }
            else
            {
                return NotFound(new Result
                {
                    Resultat = "Quina vaca s'ha de tornar al camp?"
                });
            }
        }

        [HttpGet("tocity")]
        public double EnviaCamioALaCiutat(string nom)
        {
            double kg = _campService.CamioACiutat();
            return kg;
        }
    }
}
