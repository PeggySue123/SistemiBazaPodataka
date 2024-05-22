using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CirkusDataAccess;
using CirkusDataAccess.DTOs;

namespace Cirkus_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PredstavaController : ControllerBase
    {
        [HttpDelete]
        [Route("IzbrisiPredstavu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePredstavu(int id)
        {
            try
            {
                DataProvider.ObrisiPredstavu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #region RedovnePredstave
        [HttpGet]
        [Route("PreuzmiRedovnePredstave")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetOdeljenjaDo5()
        {
            try
            {
                return new JsonResult(DataProvider.VratiRedovnePredstave());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajRedovnuPredstavu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddOdeljenjeDo5WithProdavnica()
        {
            try
            {
                DataProvider.DodajRedovnuPredstavu();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region HumanitarnePredstave
        [HttpGet]
        [Route("PreuzmiHumanitarnePredstave")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetHumanitarnePredstave()
        {
            try
            {
                return new JsonResult(DataProvider.VratiHumanitarnePredstave());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniHumanitarnuPredstavu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeHumanitarnuPredstavu([FromBody] HumanitarnaPredstavaView o)
        {
            try
            {
                DataProvider.AzurirajHumanitarnuPredstavu(o);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajHumanitarnuPredstavu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddHumanitarnuPredstavu([FromBody]HumanitarnaPredstavaView predstava)
        {
            try
            {
                DataProvider.DodajHumanitarnuPredstavu(predstava);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region NarucenaPredstava
        [HttpGet]
        [Route("PreuzmiNarucenePredstave")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetNarucenePredstave()
        {
            try
            {
                return new JsonResult(DataProvider.VratiNarucenePredstave());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniNarucenuPredstavu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeNarucenuPredstavu([FromBody] NarucenaPredstavaView predstava)
        {
            try
            {
                DataProvider.AzurirajNarucenuPredstavu(predstava);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajNarucenuPredstavu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddNarucenuPredstavu([FromBody] NarucenaPredstavaView predstava)
        {
            try
            {
                DataProvider.DodajNarucenuPredstavu(predstava);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #region TelefoniNarucioca
        [HttpPost]
        [Route("DodajTelefonNarucioca")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddTelefonNarucioca([FromBody] TelefonNaruciocaView predstava)
        {
            try
            {
                DataProvider.DodajTelefonNarucioca(predstava);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiTelefonNarucioca/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteTelefonNarucioca(int id)
        {
            try
            {
                DataProvider.ObrisiTelefonNarucioca(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #endregion
    }
}
