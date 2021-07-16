using System;
using System.Collections.Generic;
using MinhasTarefasAPI.Models;

namespace MinhasTarefasAPI.Interfaces
{
    public interface ITarefaRepository
    {
        void Sincronizacao(List<Tarefa> tarefas);
        List<Tarefa> Restauracao(ApplicationUser usuario, DateTime? dataUltimaSicronizacao);

    }
}
