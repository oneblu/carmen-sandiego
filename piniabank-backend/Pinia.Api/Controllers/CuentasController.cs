using Microsoft.AspNetCore.Mvc;
using Pinia.Application.Dtos;
using Pinia.Application.Interfaces;
using Pinia.Application.Servicios;

namespace Pinia.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CuentasController : ControllerBase
{
    IServicioCuenta _servicioCuenta;
    IServicioTransaccion _servicioTransaccion;

    public CuentasController()
    {
        _servicioCuenta = new ServicioCuenta();
        _servicioTransaccion= new ServicioTransaccion();
    }

    private readonly ILogger<ClientesController> _logger;

    [HttpGet("",Name = "ConsultarCuentas")]
    public async Task<IActionResult> Get(int idCliente)
    {
        var cuentas = await _servicioCuenta.ConsultarPorCliente(idCliente);
      
        return Ok(cuentas);
    }

    [HttpPost("",Name = "CrearCuenta")]
    public async Task<IActionResult> Crear(CrearCuentaDto crearCuentaDto)
    {
        var result = await _servicioCuenta.Crear(crearCuentaDto);
      
        return Ok(result);
    }

    [HttpPost("transacciones",Name = "CrearTransaccion")]
    public async Task<IActionResult> CrearTransaccion(CrearTransaccionDto crearTransaccionDto)
    {
        var result = await _servicioTransaccion.CrearAsync(crearTransaccionDto);
      
        return Ok(result);
    }

    [HttpPut("{idCuenta}/actualizar-estado",Name = "ActualizarEstadoCuenta")]
    public async Task<IActionResult> ActualizarEstado(int idCuenta, bool nuevoEstado)
    {
        var result = await _servicioCuenta.CambiarEstado(idCuenta, nuevoEstado);
        return Ok(result);
    }

    [HttpPut("{idCuenta}/actualizar-saldo", Name = "ActualizarSaldoCuenta")]
    public async Task<IActionResult> ActualizarEstado(int idCuenta, decimal nuevoMonto)
    {
        var result = await _servicioCuenta.ActualizarSaldo(idCuenta, nuevoMonto);
        return Ok(result);
    }
}