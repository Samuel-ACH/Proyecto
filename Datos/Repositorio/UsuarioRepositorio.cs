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
    public async Task<bool>Enviar(Doctores doctores)
    {
        int Enviar;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "UPDATE Doctores SET IdDoctor=@IdDoctor, Nombre = @Nombre, Identidad = @Identidad, FechaNacimiento = @FechaNacimiento, Sexo = @Sexo, NumeroTelefono = @NumeroTelefono, Direccion = @Direccion" +
                "Especialidad = @Especialidad, Turno = @Turno WHERE IdDoctor=@IdDoctor;";
            Enviar = await conexion.ExecuteAsync(sql, new {doctores.IdDoctor, doctores.Nombre, doctores.Identidad, doctores.FechaNacimiento, doctores.Sexo, doctores.NumeroTelefono, doctores.Direccion, doctores.Especialidad, doctores.Turno });
            return Enviar > 0;
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


