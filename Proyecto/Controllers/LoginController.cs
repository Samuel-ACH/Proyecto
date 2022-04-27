﻿using Proyecto.Data;
using Datos.Interfaces;
using Datos.Repositorio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using System.Security.Claims;
namespace Proyecto.Controllers;

public class LoginController : Controller
{
    private readonly MySQLConfiguration _configuration;
    private IUsuarioRepositorio _usuarioRepositorio;

    public LoginController(MySQLConfiguration configuration)
    {
        _configuration = configuration;
        _usuarioRepositorio = new UsuarioRepositorio(configuration.CadenaConexion);
    }

    [HttpPost("/account/login")]



    public async Task<IActionResult> Login(Login login)
    {

        try
        {
            bool usuarioValido = await _usuarioRepositorio.ValidaUsuario(login);
                Usuario usu = await _usuarioRepositorio.GetPorCodigo(login.Nombre);
                if (usu.EstaActivo)
                {
                    //Añadimos los claims Usuario y Rol para tenerlos disponibles en la Cookie
                    var claims = new[]
                    {
                                new Claim(ClaimTypes.Name, usu.Codigo),
                               
                            };

                    //Creamos el principal
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                  //  Generamos la cookie.SignInAsync es un método de extensión del contexto.
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal,
                                            new AuthenticationProperties
                                            {
                                                IsPersistent = true,
                                                ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
                                            });
                }
               
            

            else
            {
                return LocalRedirect("/login/Datos de usuario Invalido");
            }
        }
        catch (Exception ex)
        {
            return LocalRedirect("/login/Datos de usuario Invalido");
        }
        return LocalRedirect("/");
    }




    [HttpGet("/account/logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return LocalRedirect("/");
    }


}
