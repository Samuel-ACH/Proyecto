﻿using Proyecto.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Proyecto.Pages.Usuarios;

partial class NuevosUsuarios
{
    [Inject] private IUsuarioServicio usuarioServicio { get; set; }
    [Inject] private NavigationManager navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }
   

    private Usuario user = new Usuario();

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(user.IdUsuario) || string.IsNullOrEmpty(user.NombreUsuario) || string.IsNullOrEmpty(user.Rol) || user.Rol == "Seleccionar")
        {
            return;
        }

        bool inserto = await usuarioServicio.Nuevo(user);
        if (inserto)
        {
            await Swal.FireAsync("Felicidades", "Usuario creado con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Usuario no se pudo crear", SweetAlertIcon.Error);
        }
        navigationManager.NavigateTo("/Usuarios");

    }

    protected async Task Cancelar()
    {
        navigationManager.NavigateTo("/Usuarios");
    }
}
