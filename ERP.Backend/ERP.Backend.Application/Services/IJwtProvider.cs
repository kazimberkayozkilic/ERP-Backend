using ERP.Backend.Application.Features.Auth.Login;
using ERP.Backend.Domain.Entities;

namespace ERP.Backend.Application.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateToken(AppUser user);
    }
}
