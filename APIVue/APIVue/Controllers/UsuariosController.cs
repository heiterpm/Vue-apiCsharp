using APIVue.Interface;
using APIVue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace APIVue.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly AppSettings _appSettings;

        public UsuariosController (IUsuariosRepository usuariosRepository, IOptions<AppSettings> appSettings)
        {
            _usuariosRepository = usuariosRepository;
            _appSettings = appSettings.Value;
        }

        [HttpPost ("Login")]
        public async Task<ActionResult<Usuarios>>  Login(Usuarios usuario)
        {
            var user = await _usuariosRepository.ReadUsuario(usuario);

            if (user == null)
            {
                return BadRequest("Usuario não encontrado");
            }
            if (usuario.Senha != user.Senha)
            {
                return BadRequest("Senha incorreta");
            }
            else
            {
                user.Token = await GerarJwt(user);
                return Ok(await GerarJwt(usuario));
            }
        }
        private async Task<string> GerarJwt(Usuarios usuario)
        {
            var user = await _usuariosRepository.ReadUsuario(usuario);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
