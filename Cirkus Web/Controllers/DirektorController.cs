using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CirkusDataAccess;
using CirkusDataAccess.DTOs;

namespace Cirkus_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirektorController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiDirektore")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetDirektori()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveDirektore());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajDirektora")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddDirektor([FromBody] DirektorView s)
        {
            try
            {
                DataProvider.DodajDirektora(s);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniDirektora")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeDirektor([FromBody] DirektorView s)
        {
            try
            {
                DataProvider.AzurirajDirektora(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiDirektora/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteDirektor(int id)
        {
            try
            {
                DataProvider.ObrisiDirektora(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}