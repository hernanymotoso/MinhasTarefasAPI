using System;
using System.Collections.Generic;
using System.Linq;
using MinhasTarefasAPI.Interfaces;
using MinhasTarefasAPI.Models;

namespace MinhasTarefasAPI.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly MinhasTarefasContext _banco;
        public TarefaRepository(MinhasTarefasContext banco)
        {
            _banco = banco;
        }
        public void Sincronizacao(List<Tarefa> tarefas)
        {
            
        }

        public List<Tarefa> Restauracao(ApplicationUser usuario, DateTime? dataUltimaSicronizacao)
        {
            var query = _banco.Tarefas.Where(a => a.UsuarioId == usuario.Id).AsQueryable();
            
           if (dataUltimaSicronizacao != null)
           {
               query.Where(a => a.CreatedAt >= dataUltimaSicronizacao || a.UpdatedAt >= dataUltimaSicronizacao);
           }

           return query.ToList<Tarefa>();
        }
    }
}
