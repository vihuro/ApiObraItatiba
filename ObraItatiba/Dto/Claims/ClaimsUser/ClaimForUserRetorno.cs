using ObraItatiba.Dto.Usuario;

namespace ObraItatiba.Dto.Claims.ClaimsUser
{
    public class ClaimForUserRetorno
    {
        public string ClaimsId { get; set; }
        public string Valor { get; set; }
        public string Nome { get; set; }
        public UsuarioResumidoDto Usuario { get; set; }
        public UsuarioResumidoDto UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public UsuarioResumidoDto UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
    }
}
