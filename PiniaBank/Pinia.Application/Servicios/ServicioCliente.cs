using Pinia.Application.Dtos;
using Pinia.Application.Interfaces;
using Pinia.Domain.Entidades;
using Pinia.Domain.Interfaces.Repositorios;
using Pinia.Infraestructure.Data;

namespace Pinia.Application.Servicios;

public class ServicosCliente : IServicioCliente
{
    private readonly IClienteRepositorio _clienteRepositorio = new ClienteRepositorio();

    public async Task<int> Crear(CrearClienteDto crearClienteDto)
    {
        var cliente = new Cliente()
        {
            Nombres = crearClienteDto.Nombres,
            Apellidos = crearClienteDto.Apellidos,
            NumeroIdentificacion = crearClienteDto.NumeroIdentificacion
        };
        var result = await _clienteRepositorio.Crear(cliente);
        return result;
    }

    public void Actualizar(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public void CambiarEstado(int idCLiente, bool estado)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ClienteDto>> ConsultarTodos()
    {
        var clientes =await _clienteRepositorio.ConsultarTodos();
        return clientes.Select(cliente => new ClienteDto { Nombres = cliente.Nombres, Apellidos = cliente.Apellidos, NumeroIdentificacion = cliente.NumeroIdentificacion }).ToList();
    }
}