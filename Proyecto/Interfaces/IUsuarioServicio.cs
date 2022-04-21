using Modelos;

namespace Proyecto.Interfaces;

public interface IUsuarioServicio
{
    Task<bool> Enviar(Doctores doctores);
    Task<IEnumerable<Pages.Doctor.RegistroDoctores>> GetLista();
}
