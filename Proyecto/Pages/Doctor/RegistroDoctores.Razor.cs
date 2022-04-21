using Microsoft.AspNetCore.Components;
using Modelos;
using Proyecto.Interfaces;

namespace Proyecto.Pages.Doctor;


partial class Doctores
{
    [Inject] private IUsuarioServicio _usuarioServicio { get; set; }

    private IEnumerable<RegistroDoctores> usuariosLista { get; set; }

}
