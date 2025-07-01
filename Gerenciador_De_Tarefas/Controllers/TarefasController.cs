using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gerenciador_De_Tarefas.Data;
using Gerenciador_De_Tarefas.Models;

namespace Gerenciador_De_Tarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly TarefasContext _context;
        public TarefasController(TarefasContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTarefas()
        {
            var tarefas = await _context.Tarefas.OrderByDescending(t => t.DataCriacao).ToListAsync();
            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<IActionResult> AddTarefa([FromBody] Tarefa tarefa)
        {
            tarefa.DataCriacao = DateTime.Now;
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return Created($"/api/tarefas/{tarefa.Id}", tarefa);
        }

        [HttpPut("{id}/concluir")]
        public async Task<IActionResult> ConcluirTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null) return NotFound();
            tarefa.Concluida = true;
            await _context.SaveChangesAsync();
            return Ok(tarefa);
        }

        [HttpPut("{id}/reabrir")]
        public async Task<IActionResult> ReabrirTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null) return NotFound();
            tarefa.Concluida = false;
            await _context.SaveChangesAsync();
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarTarefa(int id, [FromBody] Tarefa tarefaEditada)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null) return NotFound();
            tarefa.Descricao = tarefaEditada.Descricao;
            await _context.SaveChangesAsync();
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null) return NotFound();
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
