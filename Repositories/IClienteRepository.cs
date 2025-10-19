using DesafioMauricio.Models;

namespace DesafioMauricio.Repositories;

/// <summary>
/// Contrato para acesso a dados de clientes.
/// </summary>
public interface IClienteRepository
{
    IEnumerable<Cliente> GetAll();
    Cliente? GetById(int id);
    IEnumerable<Cliente> GetByNome(string nome);
    int Count();
    Cliente Add(Cliente cliente);
    bool Update(Cliente cliente);
    bool Delete(int id);
}