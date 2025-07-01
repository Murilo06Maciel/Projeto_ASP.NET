using Microsoft.EntityFrameworkCore;
using Gerenciador_De_Tarefas.Models;

namespace Gerenciador_De_Tarefas.Data
{
    public class TarefasContext : DbContext
    {
        public TarefasContext(DbContextOptions<TarefasContext> options) : base(options) { }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
