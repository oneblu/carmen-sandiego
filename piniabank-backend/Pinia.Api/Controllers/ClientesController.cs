using Microsoft.AspNetCore.Mvc;
using Pinia.Application.Dtos;
using Pinia.Application.Interfaces;
using Pinia.Application.Servicios;

namespace Pinia.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    IServicioCliente _servicioCliente;

    public ClientesController()
    {
        _servicioCliente = new ServicosCliente();
    }

    private readonly ILogger<ClientesController> _logger;

    [HttpGet(Name = "ConsultarClientes")]
    public async Task<IActionResult> Get()
    {
        var clientes = await _servicioCliente.ConsultarTodos();
        return Ok(clientes);
    }

    [HttpPost(Name = "CrearClientes")]
    public async Task<IActionResult> Crear(CrearClienteDto crearClienteDto)
    {
        var result = await _servicioCliente.Crear(crearClienteDto);
        return Ok(result);
    }
}