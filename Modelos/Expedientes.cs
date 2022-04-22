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
    public int IdRegistroPaciente { get; set; }

    public int IdDoctor { get; set; }
    public DateTime FechaConsulta { get; set; }

    public string Diagnostico { get; set; }
}
