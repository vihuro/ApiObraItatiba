using ObraItatiba.Dto.Claims.ListClaimsForUser;
using ObraItatiba.Dto.Usuario;
using ObraItatiba.Models.Claims;

namespace ObraItatiba.Dto.Claims.ClaimsUser
{
    public class ListClaimsForUserDto
    {
        public int ClaimId { get; set; }
        public string Valor { get; set; }
        public string Nome { get; set; }
        public List<ValueListClaimsForUser> ListUsers { get; set; }
    }
}
