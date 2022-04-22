using Datos.Interfaces;
using Datos.Repositorio;
using Modelos;
using Proyecto.Data;
using Proyecto.Interfaces;

namespace Proyecto.Servicios
{
    public class DoctorServicio : IUsuarioServicio
    {
        private readonly MySQLConfiguration _configuration;
        private IDoctorRepositorio usuarioRepositorio;

        public DoctorServicio(MySQLConfiguration configuration)
        {
            _configuration = configuration;
            usuarioRepositorio = new DoctorRepositorio(configuration.CadenaConexion);
        }

        public async Task<bool> Enviar(Doctores doctores)
        {
            return await usuarioRepositorio.Enviar(doctores);
        }

        public async Task<IEnumerable<Doctores>> GetLista()
        {
            return await usuarioRepositorio.GetLista();
        }
    }
}
