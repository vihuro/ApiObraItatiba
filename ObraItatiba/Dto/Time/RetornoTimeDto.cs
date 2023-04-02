using ObraItatiba.Dto.Usuario;

namespace ObraItatiba.Dto.Time
{
    public class RetornoTimeDto
    {
        public int TimeId { get; set; }
        public string Time { get; set; }
        public UsuarioResumidoDto UsuarioCadastro {get;set; }
        public DateTime DataHoraCadastro { get; set; }
        public UsuarioResumidoDto UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
    }
}
