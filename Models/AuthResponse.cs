namespace _411_tiendita.Models;

public class AuthResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    
    // Puedes implementar el manejo de Tokens de acceso
    public string Token { get; set; }
    public Usuario Usuario { get; set; }
}