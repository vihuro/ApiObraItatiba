﻿using ObraItatiba.Models.Usuarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObraItatiba.Models.Notas
{
    [Table("tab_notasFicais")]
    public class NotasModel
    {
        [Key()]
        public int Id { get; set; }
        public string NumeroNota { get; set; }
        public string Fornecedor { get; set; }
        public decimal ValorTotalNota { get; set; }
        public string Cnpj { get; set; }
        public string DescricaoProdutoServico { get; set; }
        public string NumeroDocumento { get; set; }
        public string ProdutoServico { get; set; }
        public int UsuarioCadastroId { get; set; }
        public virtual UsuarioModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public int UsuarioAlteracaoId { get; set; }
        public virtual UsuarioModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        
    }
}
