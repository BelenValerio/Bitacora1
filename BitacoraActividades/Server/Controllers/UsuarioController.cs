
using BitacoraActividades.Server.Models;
using BitacoraActividades.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BitacoraActividades.Server.Controllers
{
    [ApiController]
    public class UsuarioController : Controller
    {
        [HttpPost]
        [Route("api/Usuario/login")]
        public int login([FromBody] UsuarioCLS oUsuario)
        {
            int rpta = 0;
            try
            {
                using (BITACORAContext db = new BITACORAContext())
                {
                    String clave = oUsuario.contra;
                    SHA256Managed sha = new SHA256Managed();
                    byte[] buffer = Encoding.Default.GetBytes(clave);
                    byte[] dataCifrada = sha.ComputeHash(buffer);
                    string dataCifradaCadena = BitConverter.ToString(dataCifrada);
                    dataCifradaCadena = dataCifradaCadena.Replace("-", "");
                    int nveces = db.Usuarios.Where(p => p.Nombre == oUsuario.nombre
                    && p.Contra == dataCifradaCadena).Count();
                    if (nveces == 0)
                    {
                        rpta = 0;
                    }
                    else
                    {
                        rpta = db.Usuarios.Where(p => p.Nombre == oUsuario.nombre
                      && p.Contra == dataCifradaCadena).First().Id;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return rpta;
        }
    }
}
