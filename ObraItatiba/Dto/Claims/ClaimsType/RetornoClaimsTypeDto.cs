using ObraItatiba.Dto.Usuario;

namespace ObraItatiba.Dto.Claims.ClaimsType
{
    public class RetornoClaimsTypeDto
    {
        public int ClaimId { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public UsuarioResumidoDto UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
    }
}
