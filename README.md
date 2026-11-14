# Prototipo-de-APP-UI-POO-POE-SQLite-ADO-

## ¿Que es ADO.NET?
ADO.NET es el framework nativo dentro de .NET que te proporciona todas las herramientas, clases y arquitecturas necesarias para conectar tu aplicación con bases de datos.
Donde sus principales componetes so:
  * Connection 
    Esta se encarga de guarda la conexion con la base de datos
    Ej: string connectionString = "Data Source=mi_base.db";
    var conexion = new SqliteConnection(connectionString))
    //Aqui finalmente abre el camino o la conexion con la base
    conexion.Open()
  * Command
    Es la consulta sql que se crea a base de
    Ej: string query = "SELECT Id, Nombre FROM Usuarios WHERE Rol = @RolFiltro;";
    //Lo veo como declarar que consulta hacer para que no cualquiera venga y no cualquiera persona consulta informacion privada de la base de daTOS
    var comando = new SqliteCommand(query, conexion)
  * DataReader
    Ejecuta el command
    Ej: comando.ExecuteReader();
  
    comando.Parameters.AddWithValue("@NombreUsuario", nombreBuscado);
