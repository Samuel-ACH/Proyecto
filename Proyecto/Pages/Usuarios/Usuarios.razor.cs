﻿
using Microsoft.AspNetCore.Components;
using Proyecto.Interfaces;
using Modelos;

namespace Proyecto.Pages.Usuarios;

partial class Usuarios
{
    [Inject] private IUsuarioServicio _usuariosServicio { get; set; }

    private IEnumerable<Usuario> usuariosLista { get; set; }

    protected override async Task OnInitializedAsync() 
    {
        usuariosLista = await _usuariosServicio.GetLista();
    }

}
