using Pinia.Application.Dtos;
using Pinia.Application.Interfaces;
using Pinia.Domain.Entidades;
using Pinia.Domain.Interfaces.Repositorios;
using Pinia.Infraestructure.Data;

namespace Pinia.Application.Servicios;

public class ServicosCliente : IServicioCliente
{
    private readonly IClienteRepositorio _clienteRepositorio = new ClienteRepositorio();

    public void Crear(CrearClienteDto crearClienteDto)
    {
        var cliente = new Cliente()
        {
            Nombres = crearClienteDto.Nombres,
            Apellidos = crearClienteDto.Apellidos,
            NumeroIdentificacion = crearClienteDto.NumeroIdentificacion
        };
        _clienteRepositorio.Crear(cliente);
    }

    public void Actualizar(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public void CambiarEstado(int idCLiente, bool estado)
    {
        throw new NotImplementedException();
    }

    public string ConsultarTodos()
    {
        var clientes = _clienteRepositorio.ConsultarTodos();
        return clientes.ToString();
    }
}