using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Auth.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api.Auth.Services;

public class JwtOptions
{
    public string Key { get; set; } = "";
    public string Issuer { get; set; } = "";
    public string Audience { get; set; } = "";
    public int ExpireMinutes { get; set; } = 120;
}

public interface IAuthService
{
    Task<LoginResponse?> LoginAsync(LoginRequest req, CancellationToken ct = default);
}

public class AuthService : IAuthService
{
    private readonly string _cn;
    private readonly JwtOptions _jwt;

    public AuthService(IConfiguration cfg, IOptions<JwtOptions> jwt)
    {
        _cn = cfg.GetConnectionString("SqlDb")!;
        _jwt = jwt.Value;
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest req, CancellationToken ct = default)
    {
        using var con = new SqlConnection(_cn);
        var result = await con.QueryFirstOrDefaultAsync<SpUserRow>(
            "dbo.SP_Login",
            new { @p_nombre_usuario = req.Username, @p_password = req.Password },
            commandType: CommandType.StoredProcedure);

        if (result is null) return null;

        var expires = DateTime.UtcNow.AddMinutes(_jwt.ExpireMinutes);
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, result.usuario_id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, result.nombre_usuario),
            new(ClaimTypes.Role, result.nombre_rol),
            new("usuario_id", result.usuario_id.ToString()),
            new("colaborador_id", result.colaborador_id?.ToString() ?? ""),
            new("nombre_colaborador", result.nombre_colaborador)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expires,
            signingCredentials: creds);

        var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

        return new LoginResponse(
            tokenStr, expires,
            result.usuario_id, result.colaborador_id,
            result.nombre_usuario, result.nombre_rol, result.nombre_colaborador);
    }
}
