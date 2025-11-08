using Microsoft.AspNetCore.Mvc;
using Pinia.Application.Dtos;
using Pinia.Application.Interfaces;
using Pinia.Application.Servicios;

namespace Pinia.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TransaccionesController : ControllerBase
{
    IServicioTransaccion _servicioTransaccion;

    public TransaccionesController()
    {
        _servicioTransaccion = new ServicioTransaccion();
    }

    private readonly ILogger<ClientesController> _logger;

    [HttpGet("{id}/cancelar",Name = "CancelarTransaccion")]
    public async Task<IActionResult> Get(int id)
    {
        var resultado = await _servicioTransaccion.CancelarTransaccion(id);
        return Ok(resultado);
    }
}