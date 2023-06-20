using System.Net;
using UAS.Models;
using UAS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UAS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresensiMengajarController : ControllerBase
{
    private readonly PresensiMengajarService _presensiMengajarService;

    public PresensiMengajarController(PresensiMengajarService presensiMengajarService) =>
        _presensiMengajarService = presensiMengajarService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<PresensiMengajar>> Get() =>
        await _presensiMengajarService.GetAsync();

    [HttpGet("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PresensiMengajar>> Get(string id)
    {
        var presensiMengajar = await _presensiMengajarService.GetAsync(id);

        if (presensiMengajar is null)
        {
            return NotFound();
        }

        return presensiMengajar;
    }


    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(PresensiMengajar newPresensiMengajar)
    {
        await _presensiMengajarService.CreateAsync(newPresensiMengajar);

        return CreatedAtAction(nameof(Get), new { id = newPresensiMengajar.Id }, newPresensiMengajar);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string id, PresensiMengajar updatedPresensiMengajar)
    {
        var presensiMengajar = await _presensiMengajarService.GetAsync(id);

        if (presensiMengajar is null)
        {
            return NotFound();
        }

        updatedPresensiMengajar.Id = presensiMengajar.Id;

        await _presensiMengajarService.UpdateAsync(id, updatedPresensiMengajar);

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
        var presensiMengajar = await _presensiMengajarService.GetAsync(id);

        if (presensiMengajar is null)
        {
            return NotFound();
        }

        await _presensiMengajarService.RemoveAsync(id);

        return NoContent();
    }
}