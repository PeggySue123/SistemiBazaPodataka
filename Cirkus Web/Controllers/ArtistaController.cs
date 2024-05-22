using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CirkusDataAccess;
using CirkusDataAccess.DTOs;

namespace Cirkus_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistaController : ControllerBase
    {
        #region Akrobata

        [HttpGet]
        [Route("PreuzmiAkrobate")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAkrobata()
        {
            try
            {
                return new JsonResult(DataProvider.VratiAkrobate());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajAkrobatu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddAkrobata([FromBody] AkrobataView s)
        {
            try
            {

                DataProvider.SacuvajAkrobatu(s);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajVestinu/{akrobataID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddVestinaToAkrobata([FromBody] VestinaView s)
        {
            try
            {
                DataProvider.SacuvajVestinu(s);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniAkrobatu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeAkrobata([FromBody] AkrobataView s)
        {
            try
            {
                DataProvider.AzurirajAkrobatu(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiAkrobatu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteAkrobata(int id)
        {
            try
            {
                DataProvider.ObrisiAkrobatuIzSistema(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Asistenti

        [HttpGet]
        [Route("PreuzmiAsistente")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAsistenti()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveAsistente());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajAsistenta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddAsistent([FromBody] AsistentiView s)
        {
            try
            {
                DataProvider.SacuvajAsistenta(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniAsistenta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeAsistent([FromBody] AsistentiView s)
        {
            try
            {
                DataProvider.AzurirajAsistenta(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiAsistenta/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteAsistent(int id)
        {
            try
            {
                DataProvider.ObrisiAsistentaIzSistema(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region BacaciNozeva

        [HttpGet]
        [Route("PreuzmiBacaceNozeva")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetBacaciNozeva()
        {
            try
            {
                return new JsonResult(DataProvider.VratiBacaceNozeva());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajBacacaNozeva")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddBacacNozeva([FromBody] BacaciNozevaView s)
        {
            try
            {
                DataProvider.SacuvajBacacaNozeva(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniBacacaNozeva")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeBacacNozeva([FromBody] BacaciNozevaView s)
        {
            try
            {
                DataProvider.AzurirajBacacaNozeva(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiBacacaNozeva/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBacacNozeva(int id)
        {
            try
            {
                DataProvider.ObrisiBacacaNozevaIzSistema(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region GutaciPlamena

        [HttpGet]
        [Route("PreuzmiGutacePlamena")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetGutaciPlamena()
        {
            try
            {
                return new JsonResult(DataProvider.VratiGutacePlamena());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajGutacePlamena")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddGutacPlamena([FromBody] GutaciPlamenaView s)
        {
            try
            {
                DataProvider.SacuvajGutacaPlamena(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniGutacaPlamena")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeGutacPlamena([FromBody] GutaciPlamenaView s)
        {
            try
            {
                DataProvider.AzurirajGutacaPlamena(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiGutacaPlamena/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteGutacPlamena(int id)
        {
            try
            {
                DataProvider.ObrisiGutacaPlamenaIzSistema(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Dreseri

        [HttpGet]
        [Route("PreuzmiDresere")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetDreseri()
        {
            try
            {
                return new JsonResult(DataProvider.VratiDresere());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajDresera")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddDreseri([FromBody] DreseriView s)
        {
            try
            {
                DataProvider.SacuvajDresera(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniDresera")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeDreseri([FromBody] DreseriView s)
        {
            try
            {
                DataProvider.AzurirajDresera(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiDresera/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteDresera(int id)
        {
            try
            {
                DataProvider.ObrisiDreseraIzSistema(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Klovn

        [HttpGet]
        [Route("PreuzmiKlovnove")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetKlovnovi()
        {
            try
            {
                return new JsonResult(DataProvider.VratiKlovnove());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKlovna")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddKlovn([FromBody] KlovnView s)
        {
            try
            {
                DataProvider.SacuvajKlovna(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniKlovna")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeKlovn([FromBody] KlovnView s)
        {
            try
            {
                DataProvider.AzurirajKlovna(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiKlovna/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteKlovn(int id)
        {
            try
            {
                DataProvider.ObrisiKlovnaIzSistema(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion

        #region Zongler

        [HttpGet]
        [Route("PreuzmiZonglere")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZongleri()
        {
            try
            {
                return new JsonResult(DataProvider.VratiZonglere());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajZonglera")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddZongler([FromBody] ZonglerView s)
        {
            try
            {
                DataProvider.SacuvajZonglera(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniZonglera")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeZongler([FromBody] ZonglerView s)
        {
            try
            {
                DataProvider.AzurirajZonglera(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiZonglera/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteZongler(int id)
        {
            try
            {
                DataProvider.ObrisiZongleraIzSistema(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #endregion
    }
}