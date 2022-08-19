using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BitacoraActividades.Shared
{
    public class UsuarioCLS
    {
        public int iidUsuario { get; set; }
        [Required(ErrorMessage = "Debe ingresar  el nombre del usuario")]
        public string nombre { get; set; }
        [MinLength(8,ErrorMessage = "La contraseña debe contener 8 caracteres")]
        public string contra { get; set; }
    }
}
