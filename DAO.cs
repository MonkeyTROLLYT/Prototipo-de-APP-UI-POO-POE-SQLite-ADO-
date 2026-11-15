using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

public class ClienteDao
{
    private readonly string _connectionString = "Data Source=mi_base.db";

    // Método para inicializar la tabla (asegurarse de que exista)
    public void InicializarBaseDeDatos()
    {
        using (var conexion = new SqliteConnection(_connectionString))
        {
            conexion.Open();
            string query = @"
                CREATE TABLE IF NOT EXISTS Clientes (
                    Apellido TEXT NOT NULL,
                    Nombre TEXT NOT NULL,
                    edad INTEGER
                );";
            
            using (var comando = new SqliteCommand(query, conexion))
            {
                comando.ExecuteNonQuery();
            }
        }
    }

    // Método para Insertar un cliente (Usa parámetros para seguridad)
    public void Insertar(string apellido, string nombre, int edad)
    {
        using (var conexion = new SqliteConnection(_connectionString))
        {
            conexion.Open();
            string query = "INSERT INTO Clientes (Apellido, Nombre, edad) VALUES (@Apellido, @Nombre, @Edad);";

            using (var comando = new SqliteCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@Apellido", apellido);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Edad", edad);
                
                comando.ExecuteNonQuery();
            }
        }
    }

    // Método para Obtener todos los clientes y pasárselos a Avalonia
    public List<Cliente> ObtenerTodos()
    {
        var listaClientes = new List<Cliente>();

        using (var conexion = new SqliteConnection(_connectionString))
        {
            conexion.Open();
            string query = "SELECT Apellido, Nombre, edad FROM Clientes;";

            using (var comando = new SqliteCommand(query, conexion))
            {
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        var cliente = new Cliente
                        {
                            Apellido = lector["Apellido"].ToString(),
                            Nombre = lector["Nombre"].ToString(),
                            Edad = Convert.ToInt32(lector["edad"])
                        };
                        listaClientes.Add(cliente);
                    }
                }
            }
        }

        return listaClientes; // Devuelve la lista lista para Avalonia
    }
}