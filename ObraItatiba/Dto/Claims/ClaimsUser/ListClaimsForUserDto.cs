using ObraItatiba.Dto.Usuario;

namespace ObraItatiba.Dto.Claims.ClaimsUser
{
    public class ListClaimsForUserDto
    {
        public int ClaimId { get; set; }
        public string Valor { get; set; }
        public string Nome { get; set; }
        public List<UsuarioResumidoDto> Usuarios { get; set; }
    }
}
