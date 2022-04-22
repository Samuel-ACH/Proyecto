using Datos.Interfaces;
using Datos.Repositorio;
using Modelos;
using Proyecto.Data;
using Proyecto.Interfaces;

namespace Proyecto.Servicios
{
    public class DoctorServicio : IDoctorServicio
    {
        private readonly MySQLConfiguration _configuration;
        private IDoctorRepositorio DoctorRepositorio;

        public DoctorServicio(MySQLConfiguration configuration)
        {
            _configuration = configuration;
            DoctorRepositorio = new DoctorRepositorio(configuration.CadenaConexion);
        }

        public async Task<bool> Enviar(Doctores doctores)
        {
            return await DoctorRepositorio.Enviar(doctores);
        }

        public async Task<IEnumerable<Doctores>> GetLista()
        {
            return await DoctorRepositorio.GetLista();
        }
    }
}
