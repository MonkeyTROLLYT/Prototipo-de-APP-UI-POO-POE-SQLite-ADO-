# Prototipo de APP UI (POO · POE · SQLite · ADO)

Aplicación de escritorio hecha con **C#** y **Avalonia UI** para registrar clientes y consultarlos desde una base de datos **SQLite**. Es un prototipo académico para practicar programación orientada a objetos, eventos y acceso a datos con ADO.NET.

## Funcionalidades

- **Registrar** un cliente (primer nombre, primer apellido y edad) con validación de los campos.
- **Limpiar** el formulario.
- **Mensaje**: abre una ventana con la lista de todos los clientes guardados.
- Los datos se guardan en un archivo local `mi_base.db`, que se crea solo la primera vez que se ejecuta la app.

### Reglas de validación

- Primer nombre y primer apellido: obligatorios y solo letras (se permiten tildes, `ñ` y espacios).
- Edad: obligatoria, número entero entre 1 y 120.

## Tecnologías

| Tecnología | Versión |
|---|---|
| .NET | 8.0 |
| Avalonia UI | 12.1.4 |
| Avalonia.Controls.DataGrid | 12.1.2 |
| Microsoft.Data.Sqlite | 8.0.11 |

## Requisitos

Solo necesitas instalar el **[SDK de .NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)**.

No hace falta instalar Avalonia ni ningún otro paquete a mano. Están declarados en el archivo `PruebadeAvalanoia.csproj` y `dotnet` los descarga automáticamente de NuGet la primera vez que compilas.

Para comprobar que tienes .NET instalado:

```bash
dotnet --version
```

## Cómo ejecutar el proyecto

1. Clona el repositorio:

   ```bash
   git clone <URL-del-repositorio>
   ```

2. Entra a la carpeta del proyecto, la que contiene `PruebadeAvalanoia.csproj` y `Program.cs`:

   ```bash
   cd <ruta-del-repositorio>/ADO
   ```

   Si no sabes dónde estás, `dir` (Windows) o `ls` (Linux/macOS) muestra el contenido de la carpeta actual. Debes ver el archivo `.csproj`.

3. Ejecuta la aplicación:

   ```bash
   dotnet run
   ```

La primera ejecución tarda un poco más porque descarga los paquetes.

## Estructura del proyecto

```
ADO/
├── Program.cs                  Punto de entrada, configura Avalonia
├── App.axaml / App.axaml.cs    Aplicación: estilos y ventana inicial
├── MainWindow.axaml / .cs      Formulario de registro y validaciones
├── VentanaClientes.axaml / .cs Ventana con la lista de clientes (DataGrid)
├── Cliente.cs                  Modelo de datos (Nombre, Apellido, Edad)
├── DAO.cs                      ClienteDao: acceso a SQLite
└── PruebadeAvalanoia.csproj    Configuración y paquetes
```

## Cómo funciona

```
Program → App → MainWindow
                  ├─ Registrar → valida → ClienteDao.Insertar()  → SQLite
                  ├─ Limpiar   → vacía los campos
                  └─ Mensaje   → ClienteDao.ObtenerTodos() → VentanaClientes
```

Cada clase tiene una sola responsabilidad:

- **MainWindow** recibe los eventos de la interfaz y valida los datos.
- **ClienteDao** es el único que escribe SQL y habla con la base de datos (patrón DAO).
- **Cliente** solo transporta datos.
- **VentanaClientes** solo muestra la lista que recibe.


## Problemas frecuentes

**`dotnet run` dice que no encuentra un proyecto:** no estás en la carpeta correcta. Entra a la que contiene `PruebadeAvalanoia.csproj`.

**El editor muestra errores en rojo pero el proyecto compila:** pasa a veces en VS Code con Avalonia. Ejecuta `dotnet build`; si dice `0 Error(s)`, reinicia el editor con `Ctrl+Shift+P` → *.NET: Restart Language Server*.

**Quiero empezar con la base de datos vacía:** cierra la app y borra el archivo `mi_base.db` (está en `bin/Debug/net8.0/`). Se crea de nuevo al abrir la app.
