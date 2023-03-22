using ObraItatiba.Dto.Claims.ClaimsType;

namespace ObraItatiba.Interface.Login
{
    public interface IClaimTypeService
    {
        RetornoClaimsTypeDto Insert(CreateClaimsTypeDto dto);
        RetornoClaimsTypeDto SelectionarPorValorNome(CreateClaimsTypeDto dto);
        RetornoClaimsTypeDto SelectForId(int id);
        List<RetornoClaimsTypeDto> SelectAll();
    }
}
