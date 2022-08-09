using OnePiece.Application.DTOs;

namespace OnePiece.Application.Interfaces
{
    public interface IAccountService
    {
        UsuarioToken GeraToken(UsuarioDTO userInfo); 
    }
}
