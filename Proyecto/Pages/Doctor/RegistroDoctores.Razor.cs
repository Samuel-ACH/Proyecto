using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using Proyecto.Interfaces;

namespace Proyecto.Pages.Doctor;


partial class RegistroDoctores
{
    [Inject] private IDoctorServicio usuarioServicio { get; set; }

    [Inject] private NavigationManager navigationManager { get; set; }

    private IEnumerable<RegistroDoctores> Doctoreslista { get; set; }

    [Inject] SweetAlertService Swal { get; set; }

    private Doctores user = new Doctores();

    protected async Task Enviar()
    {
        if (string.IsNullOrEmpty(Convert.ToString(user.IdDoctor)) || string.IsNullOrEmpty(user.Nombre) || string.IsNullOrEmpty(user.Identidad) || string.IsNullOrEmpty(Convert.ToString(user.FechaNacimiento)) ||
            string.IsNullOrEmpty(user.Sexo) || string.IsNullOrEmpty(user.NumeroTelefono) || string.IsNullOrEmpty(user.Direccion) || string.IsNullOrEmpty(user.Especialidad) || string.IsNullOrEmpty(user.Turno))
        {
            return;

            bool inserto = await usuarioServicio.Enviar(user);
            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "Usuario del doctor creado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "Usuario del doctor no se pudo crear", SweetAlertIcon.Error);
            }
            navigationManager.NavigateTo("/Doctores");

        }

    }
}
