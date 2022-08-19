using System;
using System.Collections.Generic;

#nullable disable

namespace BitacoraActividades.Server.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Contra { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
    }
}
