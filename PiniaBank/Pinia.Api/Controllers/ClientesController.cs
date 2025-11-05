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
    public IActionResult Get()
    {
        var clientes = _servicioCliente.ConsultarTodos();
        return Ok(clientes);
    }
    
    [HttpPost(Name = "CrearClientes")]
    public IActionResult Crear(CrearClienteDto crearClienteDto)
    {
        _servicioCliente.Crear(crearClienteDto);
        return Ok();
    }
}