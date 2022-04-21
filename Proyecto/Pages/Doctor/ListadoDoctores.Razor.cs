using Microsoft.AspNetCore.Components;
using Proyecto.Interfaces;
using Modelos;

namespace Proyecto.Pages.Doctor;

partial class ListadoDoctores
{
    [Inject] private IUsuarioServicio _usuarioServicio { get; set; }

    private IEnumerable<Doctores> doctoresLista { get; set; }

    protected override async Task OnInitializedAsync()
    {
        doctoresLista = await _usuarioServicio.GetLista();
    }
}
