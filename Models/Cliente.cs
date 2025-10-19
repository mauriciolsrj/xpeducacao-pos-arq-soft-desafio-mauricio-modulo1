namespace DesafioMauricio.Models;

/// <summary>
/// Entidade de dom�nio que representa um Cliente.
/// </summary>
public class Cliente
{
    /// <summary>
    /// Identificador �nico do cliente.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nome do cliente.
    /// </summary>
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// Email do cliente.
    /// </summary>
    public string Email { get; set; } = string.Empty;
}