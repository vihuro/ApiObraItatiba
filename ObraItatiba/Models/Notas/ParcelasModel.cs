using ObraItatiba.Models.Usuarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraItatiba.Models.Notas
{
    [Table("tab_Parcelas")]
    public class ParcelasModel
    {
        [Key()]
        public int Id { get; set; }
        public string NumeroParcela { get; set; }
        public string Status { get; set; }
        public DateTime Vencimento { get; set; }
        public int NotaId { get; set; }
        public virtual NotasModel Nota { get; set; }
        public int UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int UsuarioAlteracaoId { get; set; }
        public virtual UsuarioModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }

    }
}
