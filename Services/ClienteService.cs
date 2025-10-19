using DesafioMauricio.Models;
using DesafioMauricio.Repositories;

namespace DesafioMauricio.Services;

/// <summary>
/// Camada de regras de negócio para Clientes.
/// </summary>
public class ClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Cliente> ListarTodos() => _repository.GetAll();

    public Cliente? ObterPorId(int id) => _repository.GetById(id);

    public IEnumerable<Cliente> BuscarPorNome(string nome) => _repository.GetByNome(nome);

    public int Contar() => _repository.Count();

    public Cliente Criar(Cliente cliente)
    {
        Validar(cliente);
        return _repository.Add(cliente);
    }

    public bool Atualizar(int id, Cliente cliente)
    {
        if (id != cliente.Id) return false;
        Validar(cliente, isUpdate: true);
        return _repository.Update(cliente);
    }

    public bool Remover(int id) => _repository.Delete(id);

    private static void Validar(Cliente cliente, bool isUpdate = false)
    {
        if (string.IsNullOrWhiteSpace(cliente.Nome))
            throw new ArgumentException("Nome é obrigatório", nameof(cliente.Nome));
        if (string.IsNullOrWhiteSpace(cliente.Email))
            throw new ArgumentException("Email é obrigatório", nameof(cliente.Email));
        if (!cliente.Email.Contains('@'))
            throw new ArgumentException("Email inválido", nameof(cliente.Email));
        if (isUpdate && cliente.Id <= 0)
            throw new ArgumentException("Id inválido para atualização", nameof(cliente.Id));
    }
}