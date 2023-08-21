using System.Security.Claims;

namespace postgress.ExtationFunction;

public static class ClaimsPrincipalExtension
{
    public static string GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null) throw new ArgumentNullException(nameof(principal));
        var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
        return claim != null ? claim.Value : null;
    }
}