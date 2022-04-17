using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Usuario
    {
        [Required(ErrorMessage = "El Campo Codigo es Obligatorio")]
        public string Clave { get; set; }
        [Required(ErrorMessage = "El Campo Nombre es Obligatorio")]
        public string Nombre { get; set; }
       
    }
}