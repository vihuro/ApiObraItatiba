using ObraItatiba.Dto.Claims.ClaimsUser;

namespace ObraItatiba.Interface.Login
{
    public interface IClaimsForUserService
    {
        ClaimForUserRetorno InsertClaim(ClaimsCadastroUsuarioDto dto);
        List<ClaimsForUserDto> ListClaimsForUser(int idUsuario);
        List<ListClaimsForUserDto> GetAllClaimsForUser();


    }
}
