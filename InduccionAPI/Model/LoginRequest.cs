namespace Api.Auth.Models;

public record LoginRequest(string Username, string Password);

public record LoginResponse(
    string Token,
    DateTime ExpiresAt,
    int UsuarioId,
    int? ColaboradorId,
    string UserName,
    string Rol,
    string NombreColaborador
);

internal class SpUserRow
{
    public int usuario_id { get; set; }
    public int? colaborador_id { get; set; }
    public string nombre_usuario { get; set; } = "";
    public int rol_id { get; set; }
    public string nombre_rol { get; set; } = "";
    public string nombre_colaborador { get; set; } = "";
}
