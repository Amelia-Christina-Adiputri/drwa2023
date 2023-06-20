using System.Net;
using UAS.Models;
using UAS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UAS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MapelController : ControllerBase
{
    private readonly MapelService _mapelService;

    public MapelController(MapelService mapelService) =>
        _mapelService = mapelService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<Mapel>> Get() =>
        await _mapelService.GetAsync();

    [HttpGet("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Mapel>> Get(string id)
    {
        var mapel = await _mapelService.GetAsync(id);

        if (mapel is null)
        {
            return NotFound();
        }

        return mapel;
    }


    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(Mapel newMapel)
    {
        await _mapelService.CreateAsync(newMapel);

        return CreatedAtAction(nameof(Get), new { id = newMapel.Id }, newMapel);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string id, Mapel updatedMapel)
    {
        var mapel = await _mapelService.GetAsync(id);

        if (mapel is null)
        {
            return NotFound();
        }

        updatedMapel.Id = mapel.Id;

        await _mapelService.UpdateAsync(id, updatedMapel);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(string id)
    {
        var mapel = await _mapelService.GetAsync(id);

        if (mapel is null)
        {
            return NotFound();
        }

        await _mapelService.RemoveAsync(id);

        return NoContent();
    }
}