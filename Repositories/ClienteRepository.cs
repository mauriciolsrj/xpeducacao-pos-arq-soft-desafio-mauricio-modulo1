using DesafioMauricio.Models;
using DesafioMauricio.Data;

namespace DesafioMauricio.Repositories;

/// <summary>
/// Implementação em memória do repositório de clientes.
/// Utiliza uma lista estática para simular persistência.
/// </summary>
public class ClienteRepository : IClienteRepository
{
    public IEnumerable<Cliente> GetAll() => InMemoryDataStore.Clientes.OrderBy(c => c.Id);

    public Cliente? GetById(int id) => InMemoryDataStore.Clientes.FirstOrDefault(c => c.Id == id);

    public IEnumerable<Cliente> GetByNome(string nome) => InMemoryDataStore.Clientes
        .Where(c => c.Nome.Contains(nome, StringComparison.InvariantCultureIgnoreCase))
        .OrderBy(c => c.Nome);

    public int Count() => InMemoryDataStore.Clientes.Count;

    public Cliente Add(Cliente cliente)
    {
        if (cliente == null) throw new ArgumentNullException(nameof(cliente));
        lock (InMemoryDataStore.LockObj)
        {
            cliente.Id = InMemoryDataStore.NextId++;
            InMemoryDataStore.Clientes.Add(cliente);
        }
        return cliente;
    }

    public bool Update(Cliente cliente)
    {
        if (cliente == null) throw new ArgumentNullException(nameof(cliente));
        lock (InMemoryDataStore.LockObj)
        {
            var existing = InMemoryDataStore.Clientes.FindIndex(c => c.Id == cliente.Id);
            if (existing == -1) return false;
            InMemoryDataStore.Clientes[existing].Nome = cliente.Nome;
            InMemoryDataStore.Clientes[existing].Email = cliente.Email;
            return true;
        }
    }

    public bool Delete(int id)
    {
        lock (InMemoryDataStore.LockObj)
        {
            var existing = InMemoryDataStore.Clientes.FirstOrDefault(c => c.Id == id);
            if (existing == null) return false;
            InMemoryDataStore.Clientes.Remove(existing);
            return true;
        }
    }
}