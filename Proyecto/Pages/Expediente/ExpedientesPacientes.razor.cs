﻿using Microsoft.AspNetCore.Components;
using Proyecto.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Modelos;
using Datos;

namespace Proyecto.Pages.Expediente;

partial class ExpedientesPacientes
{
    [Inject] private IExpedientesServicio expedientesServicio { get; set; }
    [Inject] private NavigationManager navigationManager { get; set; }

    private IEnumerable<ExpedientesPacientes> ExpedientesList { get; set; }

    [Inject] SweetAlertService Swal { get; set; }

    private Expedientes Exp = new Expedientes();

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(Convert.ToString(Exp.IdExpedientePaciente)) || string.IsNullOrEmpty(Convert.ToString(Exp.IdRegistroPaciente)) || string.IsNullOrEmpty(Convert.ToString(Exp.IdDoctor)) || string.IsNullOrEmpty(Convert.ToString(Exp.FechaConsulta)) ||
        string.IsNullOrEmpty(Exp.Diagnostico))
        {
            return;

            bool inserto = await expedientesServicio.Guardar(Exp);
            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "Usuario del doctor creado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "Usuario del doctor no se pudo crear", SweetAlertIcon.Error);
            }
            navigationManager.NavigateTo("/Expedientes");
        }

    }
}