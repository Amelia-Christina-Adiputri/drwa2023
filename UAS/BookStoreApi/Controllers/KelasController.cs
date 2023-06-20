using System.Net;
using UAS.Models;
using UAS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UAS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KelasController : ControllerBase
{
    private readonly KelasService _kelasService;

    public KelasController(KelasService kelasService) =>
        _kelasService = kelasService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<KelasA>> Get() =>
        await _kelasService.GetAsync();

    [HttpGet("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<KelasA>> Get(string id)
    {
        var kelas = await _kelasService.GetAsync(id);

        if (kelas is null)
        {
            return NotFound();
        }

        return kelas;
    }


    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(KelasA newKelas)
    {
        await _kelasService.CreateAsync(newKelas);

        return CreatedAtAction(nameof(Get), new { id = newKelas.Id }, newKelas);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string id, KelasA updatedKelas)
    {
        var kelas = await _kelasService.GetAsync(id);

        if (kelas is null)
        {
            return NotFound();
        }

        updatedKelas.Id = kelas.Id;

        await _kelasService.UpdateAsync(id, updatedKelas);

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
        var kelas = await _kelasService.GetAsync(id);

        if (kelas is null)
        {
            return NotFound();
        }

        await _kelasService.RemoveAsync(id);

        return NoContent();
    }
}