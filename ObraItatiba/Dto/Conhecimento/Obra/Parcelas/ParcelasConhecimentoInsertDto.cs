namespace ObraItatiba.Dto.Conhecimento.Obra.Parcelas
{
    public class ParcelasConhecimentoInsertDto
    {
        public int ConhecimentoObraId { get; set; }
        public string NumeroParcela { get; set; }
        public DateTime Vencimento { get; set; }
        public int UsuarioCadastroId { get; set; }
        public decimal ValorParcela { get; set;}

    }
}
