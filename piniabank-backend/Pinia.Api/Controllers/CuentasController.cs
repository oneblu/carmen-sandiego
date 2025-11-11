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

    public CuentasController()
    {
        _servicioCuenta = new ServicioCuenta();
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