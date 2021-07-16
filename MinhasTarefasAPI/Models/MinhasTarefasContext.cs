using Microsoft.EntityFrameworkCore;

namespace MinhasTarefasAPI.Models
{
    public class MinhasTarefasContext : DbContext
    {
        public MinhasTarefasContext(DbContextOptions<MinhasTarefasContext> options) : base(options)
        {
            
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        
    }
}
