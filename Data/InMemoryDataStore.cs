using DesafioMauricio.Models;

namespace DesafioMauricio.Data;

/// <summary>
/// Armazena dados em memória para a aplicação. Simula um banco de dados.
/// </summary>
public static class InMemoryDataStore
{
    internal static readonly List<Cliente> Clientes = new();
    internal static int NextId = 1;
    internal static readonly object LockObj = new();

    /// <summary>
    /// Reseta o estado (usado em testes).
    /// </summary>
    public static void Reset()
    {
        lock (LockObj)
        {
            Clientes.Clear();
            NextId = 1;
        }
    }
}