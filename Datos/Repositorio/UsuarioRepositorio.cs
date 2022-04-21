using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private string CadenaConexion;

    public UsuarioRepositorio(string cadenaConexion)
    {
        CadenaConexion = cadenaConexion;
    }

    private MySqlConnection Conexion()
    {
        return new MySqlConnection(CadenaConexion);
    }
    public async Task<bool> Enviar(Doctores doctores)
    {
         int resultado;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "UPDATE Doctores SET Nombre = @Nombre, Identidad = @Identidad, FechaNacimiento = @FechaNacimiento, Sexo = @Sexo, NumeroTelefono = @NumeroTelefono, Direccion = @Direccion" +
                "Especialidad = @Especialidad, Turno = @Turno WHERE Nombre = @Nombre ;";
            resultado = await conexion.ExecuteAsync(sql, new {});
            return resultado > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<IEnumerable<Doctores>> GetLista()
    {
        IEnumerable<Doctores> lista = new List<Doctores>();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM Doctores;";
            lista = await conexion.QueryAsync<Doctores>(sql);
        }
        catch (Exception ex)
        {
        }
        return lista;
    }
}
//public async Task<bool> ValidaUsuario(Login login)
//{
//    bool valido = false;
//    try
//    {
//        using MySqlConnection conexion = Conexion();
//        await conexion.OpenAsync();
//        string sql = "SELECT 1 FROM usuario WHERE Codigo = @Codigo AND Clave = @Clave;";
//        valido = await conexion.ExecuteScalarAsync<bool>(sql, new { login.Codigo, login.Clave });
//    }
//    catch (Exception ex)
//    {
//    }
//    return valido;
//}

