using Pinia.Application.Dtos;
using Pinia.Application.Interfaces;
using Pinia.Domain.Entidades;
using Pinia.Domain.Interfaces.Repositorios;
using Pinia.Infraestructure.Data;
using Pinia.Shared;

namespace Pinia.Application.Servicios;

public class ServicioCuenta : IServicioCuenta
{
    private readonly ICuentaRepositorio _cuentaRepositorio = new CuentaRepositorio();

    public async Task<int> Crear(CrearCuentaDto crearCuentaDto)
    {
        var cliente = new Cuenta()
        {
            Numero = long.Parse(Utileria.GenerarNumeroCuenta()),
            Tipo = crearCuentaDto.Tipo,
            IdCliente = crearCuentaDto.IdCliente
        };
        var result = await _cuentaRepositorio.Crear(cliente);
        return result;
    }

    public async Task<bool> ActualizarSaldo(int idCliente, decimal nuevoMonto)
    {
        return await _cuentaRepositorio.ActualizarSaldo(idCliente, nuevoMonto);
    }

    public async Task<bool> CambiarEstado(int idCuenta, bool estado)
    {
        return await _cuentaRepositorio.CambiarEstado(idCuenta, estado);
    }

    public async Task<IEnumerable<CuentaDto>> ConsultarPorCliente(int idCliente)
    {
        var cuentas = await _cuentaRepositorio.ConsultarPorCliente(idCliente);

        return cuentas.ToList().Select(cliente => new CuentaDto
        {
            Id = cliente.Id,
            Numero = cliente.Numero,
            Tipo = cliente.Tipo,
            Saldo = cliente.Saldo,
            Estado = cliente.Estado,
            FechaCreacion = cliente.FechaCreacion,

        });
    }
}