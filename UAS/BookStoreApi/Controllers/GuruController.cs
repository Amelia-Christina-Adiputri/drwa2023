using System.Net;
using UAS.Models;
using UAS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace UAS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuruController : ControllerBase
{
    private readonly GuruService _guruService;

    public GuruController(GuruService guruService) =>
        _guruService = guruService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<Guru>> Get() =>
        await _guruService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Guru>> Get(string id)
    {
        var guru = await _guruService.GetAsync(id);

        if (guru is null)
        {
            return NotFound();
        }

        return guru;
    }


    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(Guru newGuru)
    {
        await _guruService.CreateAsync(newGuru);

        return CreatedAtAction(nameof(Get), new { id = newGuru.Id }, newGuru);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string id, Guru updatedGuru)
    {
        var guru = await _guruService.GetAsync(id);

        if (guru is null)
        {
            return NotFound();
        }

        updatedGuru.Id = guru.Id;

        await _guruService.UpdateAsync(id, updatedGuru);

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
        var guru = await _guruService.GetAsync(id);

        if (guru is null)
        {
            return NotFound();
        }

        await _guruService.RemoveAsync(id);

        return NoContent();
    }
}