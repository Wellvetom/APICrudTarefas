using APICrudTarefas.Application.DTO.Request;
using APICrudTarefas.Application.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/tarefas")]
public class TarefasController : ControllerBase
{
    private readonly TarefaService _tarefaService;

    public TarefasController(TarefaService tarefaService)
    {
        _tarefaService = tarefaService;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(
      [FromBody] CriarTarefaRequest request)
    {
        var id = await _tarefaService.CriarAsync(request);

        return Created();

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(
        Guid id,
        [FromBody] AtualizarTarefaRequest request)
    {
        await _tarefaService.AtualizarAsync(id, request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(Guid id)
    {
        await _tarefaService.RemoverAsync(id);

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> Listar(
        [FromQuery] int pagina = 1,
        [FromQuery] int tamanhoPagina = 10)
    {
        var resultado =
            await _tarefaService.ListarAsync(
                pagina,
                tamanhoPagina);

        return Ok(resultado);
    }
}
