using System.Net;
using UAS.Models;
using UAS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UAS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresensiHarianGuruController : ControllerBase
{
    private readonly PresensiHarianGuruService _presensiHarianGuruService;

    public PresensiHarianGuruController(PresensiHarianGuruService presensiMengajarService) =>
        _presensiHarianGuruService = presensiMengajarService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<PresensiHarianGuru>> Get() =>
        await _presensiHarianGuruService.GetAsync();

    [HttpGet("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PresensiHarianGuru>> Get(string id)
    {
        var presensiHarianGuru = await _presensiHarianGuruService.GetAsync(id);

        if (presensiHarianGuru is null)
        {
            return NotFound();
        }

        return presensiHarianGuru;
    }


    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(PresensiHarianGuru newPresensiHarianGuru)
    {
        await _presensiHarianGuruService.CreateAsync(newPresensiHarianGuru);

        return CreatedAtAction(nameof(Get), new { id = newPresensiHarianGuru.Id }, newPresensiHarianGuru);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string id, PresensiHarianGuru updatedPresensiHarianGuru)
    {
        var presensiHarianGuru = await _presensiHarianGuruService.GetAsync(id);

        if (presensiHarianGuru is null)
        {
            return NotFound();
        }

        updatedPresensiHarianGuru.Id = presensiHarianGuru.Id;

        await _presensiHarianGuruService.UpdateAsync(id, updatedPresensiHarianGuru);

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
        var presensiHarianGuru = await _presensiHarianGuruService.GetAsync(id);

        if (presensiHarianGuru is null)
        {
            return NotFound();
        }

        await _presensiHarianGuruService.RemoveAsync(id);

        return NoContent();
    }
}