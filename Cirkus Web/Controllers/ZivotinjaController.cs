using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CirkusDataAccess;
using CirkusDataAccess.DTOs;

namespace Cirkus_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZivotinjaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiZivotinje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZivotinje()
        {
            try
            {
                return new JsonResult(DataProvider.VratiZivotinje());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajZivotinju")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddZivotinja([FromBody] ZivotinjaView s)
        {
            try
            {
                DataProvider.DodajZivotinju(s);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniZivotinju")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeZivotinja([FromBody] ZivotinjaView s)
        {
            try
            {
                DataProvider.AzurirajZivotinju(s);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiZivotinju/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteZivotinja(int id)
        {
            try
            {
                DataProvider.ObrisiZivotinju(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}