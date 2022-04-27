using Datos.Interfaces;
using Datos.Repositorio;
using Modelos;
using Proyecto.Data;
using Proyecto.Interfaces;

namespace Proyecto.Servicios;

public class ExpedientesServicio : IExpedientesServicio
{
    private readonly MySQLConfiguration _configuration;
    private IExpedientesRepositorio expedientesRepositorio;

    public ExpedientesServicio(MySQLConfiguration configuration)
    {
        _configuration = configuration;
        expedientesRepositorio = new ExpedientesRepositorio(configuration.CadenaConexion);
    }

    public async Task<bool> Guardar(Expedientes expedientes)
    {
        return await expedientesRepositorio.Guardar(expedientes);
    }

    public async Task<IEnumerable<Expedientes>> GetList()
    {
        return await expedientesRepositorio.GetList();
    }

}
