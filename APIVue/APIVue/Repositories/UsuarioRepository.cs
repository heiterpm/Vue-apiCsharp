
using Microsoft.EntityFrameworkCore;
using APIVue.Interface;
using APIVue.Models;

namespace APIVue.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {
        private readonly ProdutosDBContext _context;

        public UsuarioRepository(ProdutosDBContext context)
        {
            _context = context;
        }

        public async Task<Usuarios> ReadUsuario(Usuarios usuarios)
        {
            return await _context.TbUsuarios.Where(conta => conta.Usuario == usuarios.Usuario).FirstOrDefaultAsync();
        }
    }
}
