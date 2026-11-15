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
| .NET SDK | 8.0 |
| Avalonia / Avalonia.Desktop | 12.1.4 |
| Avalonia.Themes.Fluent | 12.1.4 |
| Avalonia.Fonts.Inter | 12.1.4 |
| Avalonia.Controls.DataGrid | 12.1.2 |
| Microsoft.Data.Sqlite | 8.0.11 |

## Requisitos

- **[SDK de .NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)** (el SDK completo, no solo el runtime).
- **Plantillas de Avalonia**, para crear el proyecto base con `dotnet`.
- Conexión a internet para descargar las plantillas y los paquetes de NuGet.

Comprueba que tienes .NET instalado:

```bash
dotnet --version
```

## Cómo probar el proyecto

Este repositorio contiene los archivos de código, no el proyecto base de Avalonia. Hay que crear primero un proyecto vacío con `dotnet` y luego reemplazar sus archivos por los del repositorio.

### 1. Descargar el repositorio

```bash
git clone <URL-del-repositorio>
```

O descárgalo como ZIP desde GitHub (**Code → Download ZIP**) y descomprímelo.

### 2. Instalar las plantillas de Avalonia

```bash
dotnet new install Avalonia.Templates
```

### 3. Crear el proyecto base

El nombre debe ser **`PruebadeAvalanoia`** (con esa ortografía), porque los archivos del repositorio usan ese namespace.

```bash
dotnet new avalonia.app -n PruebadeAvalanoia -o ADO
cd ADO
```

Abre `PruebadeAvalanoia.csproj` y verifica que el `TargetFramework` sea `net8.0`. Si la plantilla puso otro, cámbialo.

### 4. Instalar los paquetes adicionales

```bash
dotnet add package Avalonia.Controls.DataGrid --version 12.1.2
dotnet add package Microsoft.Data.Sqlite --version 8.0.11
```

Los demás paquetes (`Avalonia`, `Avalonia.Desktop`, `Avalonia.Themes.Fluent`, `Avalonia.Fonts.Inter`) ya vienen con la plantilla. El DataGrid debe tener la misma versión que Avalonia o una muy cercana; si la plantilla instala otra versión de Avalonia, ajusta también la del DataGrid.

### 5. Reemplazar los archivos con los del repositorio

Copia estos archivos del repositorio descargado a la carpeta `ADO` que acabas de crear, aceptando reemplazar los que ya existan:

- `App.axaml` y `App.axaml.cs`
- `MainWindow.axaml` y `MainWindow.axaml.cs`
- `VentanaClientes.axaml` y `VentanaClientes.axaml.cs`
- `Cliente.cs`
- `DAO.cs`

No reemplaces el `.csproj` (ya tiene los paquetes que instalaste).

### 6. Ejecutar

Desde la carpeta `ADO`, la que contiene `PruebadeAvalanoia.csproj`:

```bash
dotnet run
```

Si no sabes en qué carpeta estás, usa `dir` (Windows) o `ls` (Linux/macOS) y comprueba que aparece el archivo `.csproj`. Para moverte, usa `cd ruta_de_la_carpeta`.

## Estructura de los archivos

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

- **MainWindow** recibe los eventos de la interfaz y valida los datos.
- **ClienteDao** es el único que escribe SQL y habla con la base de datos (patrón DAO).
- **Cliente** solo transporta datos.
- **VentanaClientes** solo muestra la lista que recibe.

## Posibles mejoras

- Guardar también el segundo nombre y el segundo apellido (el formulario ya tiene los campos, pero no se almacenan).
- Mover las validaciones a una clase aparte.
- Permitir editar y eliminar clientes.

## Problemas frecuentes

**Errores `InitializeComponent` o `x:Class`:** el nombre del proyecto y el namespace no coinciden. Revisa que el proyecto se llame `PruebadeAvalanoia`.

**`dotnet run` dice que no encuentra un proyecto:** no estás en la carpeta correcta. Entra a la que contiene `PruebadeAvalanoia.csproj`.

**El editor muestra errores en rojo pero el proyecto compila:** pasa a veces en VS Code con Avalonia. Ejecuta `dotnet build`; si dice `0 Error(s)`, reinicia el editor con `Ctrl+Shift+P` → *.NET: Restart Language Server*.

**Quiero empezar con la base de datos vacía:** cierra la app y borra `mi_base.db` (está en `bin/Debug/net8.0/`). Se crea de nuevo al abrir la app.
