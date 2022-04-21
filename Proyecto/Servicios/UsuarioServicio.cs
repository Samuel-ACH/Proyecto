using Datos.Interfaces;
using Datos.Repositorio;
using Modelos;
using Proyecto.Data;
using Proyecto.Interfaces;

namespace Proyecto.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly MySQLConfiguration _configuration;
        private IUsuarioRepositorio usuarioRepositorio;

        public UsuarioServicio(MySQLConfiguration configuration)
        {
            _configuration = configuration;
            usuarioRepositorio = new UsuarioRepositorio(configuration.CadenaConexion);
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
