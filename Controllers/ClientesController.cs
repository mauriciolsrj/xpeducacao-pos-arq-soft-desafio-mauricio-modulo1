using DesafioMauricio.Models;
using DesafioMauricio.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMauricio.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ClienteService _service;

    public ClientesController(ClienteService service)
    {
        _service = service;
    }

    /// <summary>
    /// Lista todos os clientes.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Cliente>> GetAll() => Ok(_service.ListarTodos());

    /// <summary>
    /// Obtém um cliente pelo Id.
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Cliente> GetById(int id)
    {
        var cliente = _service.ObterPorId(id);
        if (cliente == null) return NotFound();
        return Ok(cliente);
    }

    /// <summary>
    /// Busca clientes pelo nome (contém).
    /// </summary>
    [HttpGet("nome/{nome}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Cliente>> GetByNome(string nome) => Ok(_service.BuscarPorNome(nome));

    /// <summary>
    /// Retorna a quantidade total de clientes.
    /// </summary>
    [HttpGet("contar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<object> Count() => Ok(new { total = _service.Contar() });

    /// <summary>
    /// Cria um novo cliente.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Cliente> Create([FromBody] Cliente cliente)
    {
        try
        {
            var created = _service.Criar(cliente);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>
    /// Atualiza um cliente existente.
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, [FromBody] Cliente cliente)
    {
        if (id != cliente.Id) return BadRequest(new { error = "Id do path difere do body" });
        try
        {
            var updated = _service.Atualizar(id, cliente);
            if (!updated) return NotFound();
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>
    /// Remove um cliente.
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var removed = _service.Remover(id);
        if (!removed) return NotFound();
        return NoContent();
    }
}