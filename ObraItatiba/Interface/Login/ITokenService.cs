using ObraItatiba.Dto.Usuario;

namespace ObraItatiba.Interface.Login
{
    public interface ITokenService
    {
        public string Create(RetornoUsuarioDto dto);
    }
}
