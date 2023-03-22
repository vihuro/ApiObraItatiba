using ObraItatiba.Dto.Claims.ClaimsUser;

namespace ObraItatiba.Dto.Usuario
{
    public class RetornoUsuarioDto
    {
        public int UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public string Apelido { get; set; }
        public List<ClaimsForUserDto> Claims {get;set;}
    }
}
