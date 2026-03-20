using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjetosController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public ProjetosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetProjetos()
    {
        var projetos = await _context.Projetos.ToListAsync();
        return Ok(projetos);
    }

    [HttpPost]
    public async Task<IActionResult> CriarProjeto(Projeto projeto)
    {
        _context.Projetos.Add(projeto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProjetos), new { id = projeto.Id }, projeto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjeto(int id)
    {
        var projeto = await _context.Projetos.FindAsync(id);

        if (projeto == null)
        {
            return NotFound();
        }
        return Ok(projeto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarProjeto(int id, Projeto projetoAtualizado)
    {
        if (id != projetoAtualizado.Id)
        {
            return BadRequest();
        }

        _context.Entry(projetoAtualizado).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Projetos.Any(p => p.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirProjeto(int id)
    {
        var projeto = await _context.Projetos.FindAsync(id);

        if (projeto == null)
        {
            return NotFound();
        }

        _context.Projetos.Remove(projeto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}