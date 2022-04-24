using System.ComponentModel.DataAnnotations;

namespace Modelos;

public class Usuario
{
    [Required(ErrorMessage = "El Campo IdUsuario es Obligatorio")]
    public string IdUsuario { get; set; }
    [Required(ErrorMessage = "El Campo Nombre es Obligatorio")]
    public string NombreUsuario { get; set; }
    [Required(ErrorMessage = "El Campo Contraseña es Obligatorio")]
    public string Contraseña { get; set; }
    public bool EstaActivo { get; set; }

    [Required(ErrorMessage = "El Campo Rol es Obligatorio")]
    public string Rol { get; set; }
   
}
