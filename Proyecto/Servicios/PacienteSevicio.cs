using Datos.Interfaces;
using Datos.Repositorio;
using Modelos;
using Proyecto.Data;
using Proyecto.Interfaces;

namespace Proyecto.Servicios;

public class PacienteServicio : IPacienteServicio
{
    private readonly MySQLConfiguration _configuration;
    private IPacienteRepositorio pacienteRepositorio;

    public PacienteServicio(MySQLConfiguration configuration)
    {
        _configuration = configuration;
        pacienteRepositorio = new PacienteRepositorio(configuration.CadenaConexion);
    }

    public async Task<bool> Enviar(Pacientes pacientes)
    {
        return await pacienteRepositorio.Enviar(pacientes);
    }

    public async Task<IEnumerable<Pacientes>> GetList()
    {
        return await pacienteRepositorio.GetList();
    }


}
