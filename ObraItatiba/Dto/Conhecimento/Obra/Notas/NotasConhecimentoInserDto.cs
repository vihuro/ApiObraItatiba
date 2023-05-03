namespace ObraItatiba.Dto.Conhecimento.Obra.Notas
{
    public class NotasConhecimentoInserDto
    {
        public string NumeroNota { get; set; }
        public string? Fornecedor { get; set; }
        public DateTime? DataEmissao { get; set; }
        public int ConhecimentoId { get; set; }
        public int UsuarioCadastroId { get; set; }
    }
}
