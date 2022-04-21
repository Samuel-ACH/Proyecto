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

        public Task<IEnumerable<Pages.Doctor.RegistroDoctores>> GetLista()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Pages.Doctor.RegistroDoctores>> IUsuarioServicio.GetLista()
        {
            throw new NotImplementedException();
        }
    }
}
