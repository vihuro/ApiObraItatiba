using ObraItatiba.Dto.Usuario;

namespace ObraItatiba.Interface.Login
{
    public interface IUsuarioService
    {
        RetornoUsuarioDto Insert(CreateUsuarioDto dto);
        RetornoUsuarioDto ProcurarPorApelido(string apelido);
        List<RetornoUsuarioDto> BuscarTodos();
        RetornoUsuarioDto BuscarPorId(int id);
        string Logar(LogarDto dto);
        string DeleteAll();
    }
}
