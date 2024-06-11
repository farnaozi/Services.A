using System.Security.Claims;

namespace Services.A.Core.Interfaces
{
    public interface IJwtFactory
    {
        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
