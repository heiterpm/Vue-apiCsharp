using APIVue.Models;

namespace APIVue.Interface
{
    public interface IUsuariosRepository
    {
        Task<Usuarios> ReadUsuario(Usuarios usuarios);
    }
}
