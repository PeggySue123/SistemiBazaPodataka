using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CirkusDataAccess;
using CirkusDataAccess.DTOs;

namespace Cirkus_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PomocnoOsobljeController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiPomocnoOsoblje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPomocnoOsoblje()
        {
            try
            {
                return new JsonResult(DataProvider.VratiPomocnoOsobljeBasic());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajPomocnuOsobu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddPomocnaOsoba([FromBody] PomocnoOsobljeView s)
        {
            try
            {
                DataProvider.DodajPomocnuOsobu(s);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniPomocnuOsobu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangePomocnaOsoba([FromBody] PomocnoOsobljeView s)
        {
            try
            {
                DataProvider.AzurirajPomocnuOsobu(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiPomocnuOsobu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePomocnaOsoba(int id)
        {
            try
            {
                DataProvider.ObrisiPomocnuOsobu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}