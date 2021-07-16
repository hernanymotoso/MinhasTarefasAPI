using MinhasTarefasAPI.Models;

namespace MinhasTarefasAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(ApplicationUser usuario, string senha);

        ApplicationUser Obter(string email, string senha);
    }
}
