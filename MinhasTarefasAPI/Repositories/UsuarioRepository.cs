using System;
using System.Text;
using Microsoft.AspNetCore.Identity;
using MinhasTarefasAPI.Interfaces;
using MinhasTarefasAPI.Models;

namespace MinhasTarefasAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsuarioRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        

        public void Cadastrar(ApplicationUser usuario, string senha)
        {
           var result = _userManager.CreateAsync(usuario, senha).Result;
           if (!result.Succeeded)
           {
               StringBuilder sb = new StringBuilder();
               foreach (var erro in result.Errors)
               {
                   sb.Append(erro.Description);
               }

               throw new Exception($"Usuário não cadastrado! {sb.ToString()}");
           }
        }

        public ApplicationUser Obter(string email, string senha)
        {
            var usuario = _userManager.FindByEmailAsync(email).Result;
            if (_userManager.CheckPasswordAsync(usuario, senha).Result)
            {
                return usuario;
            }
            else
            {
                /*
                 * Domain Notification
                 */
                throw new Exception("Usuario não localizado");
            }

        }
    }
}
