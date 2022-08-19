using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BitacoraActividades.Client.Service
{
    public class Autenticacion: AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            
            //Esto equivale a un cerrar Sesion
            var user = new ClaimsPrincipal();
            return Task.FromResult(new AuthenticationState(user));

        }

        public void entrar(string iiduser)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,iiduser)
            }, "auth");

            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));

        }

        public void CerrarSesion()
        {

            //Esto equivale a un cerrar Sesion
            var user = new ClaimsPrincipal();
            NotifyAuthenticationStateChanged( Task.FromResult(new AuthenticationState(user)));

        }

    }
}
