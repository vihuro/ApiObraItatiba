﻿using ObraItatiba.Dto.Claims.ClaimsUser;
using ObraItatiba.Models.Claims;

namespace ObraItatiba.Dto.Usuario
{
    public class CreateUsuarioDto
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Senha { get; set; }
        public List<ClaimsCadastroUsuarioDto> Claims { get; set; }
    }
}
