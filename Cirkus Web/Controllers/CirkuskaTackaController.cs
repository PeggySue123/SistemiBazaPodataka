using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CirkusDataAccess;
using CirkusDataAccess.DTOs;

namespace Cirkus_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CirkuskaTackaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiCirkuskeTacke")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetCirkuskaTacka()
        {
            try
            {
                return new JsonResult(DataProvider.VratiCirkuskeTacke());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajCirkuskuTacku")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddCirkuskaTacka([FromBody] CirkuskaTackaView s)
        {
            try
            {
                DataProvider.DodajCirkuskuTacku(s);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniCirkuskuTacku")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeCirkuskaTacka([FromBody] CirkuskaTackaView s)
        {
            try
            {
                DataProvider.AzurirajCirkuskuTacku(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiCirkuskuTacku/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteCirkuskaTacka(int id)
        {
            try
            {
                DataProvider.ObrisiCirkuskuTackuIzSistema(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
