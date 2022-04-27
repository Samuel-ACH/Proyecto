using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelos;

public class Expedientes
{
    public int IdExpedientePaciente { get; set; }

    public string IdRegistroPaciente { get; set; }

    public string IdDoctor { get; set; }
    public string FechaConsulta { get; set; }

    public string Diagnostico { get; set; }
}
