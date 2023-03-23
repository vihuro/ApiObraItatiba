using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ObraItatiba.Dto.Usuario;
using ObraItatiba.Interface.Login;
using ObraItatiba.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ObraItatiba.Service.JWT
{
    public class CreateToken : ITokenService
    {
        private readonly AppSettings _appSettings;
        public CreateToken(IOptions<AppSettings> appSetting) 
        {
            this._appSettings = appSetting.Value;
        }

        public string Create(RetornoUsuarioDto dto)
        {
            var tokenHeader = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDesciptor = new SecurityTokenDescriptor();
            var uniqueName = new Claim(ClaimTypes.Name, dto.Apelido);
            var name = new Claim("Nome", dto.NomeUsuario);
            var identityName = new Claim("idUser", dto.UsuarioId.ToString());
            var claims = new List<Claim>();

            foreach(var item in dto.Claims)
            {
                claims.Add(new Claim(item.Nome, item.Valor));
            }
            claims.Add(uniqueName);
            claims.Add(name);
            claims.Add(identityName);
            tokenDesciptor.Subject = new ClaimsIdentity(claims);
            tokenDesciptor.Expires = DateTime.UtcNow.AddHours(8);
            tokenDesciptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var token = tokenHeader.CreateToken(tokenDesciptor);
            return tokenHeader.WriteToken(token);


        }
    }
}
