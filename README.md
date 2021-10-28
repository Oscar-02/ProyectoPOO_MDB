![C#-Shield](https://img.shields.io/badge/Lenguaje-C%23-brightgreen.svg)
![SQL-Shield](https://img.shields.io/badge/Proveedor%20Base%20de%20Datos-SQL%20Server-red.svg)

## Desarrolladores:
Antes de abrir la aplicacion deberan seguir los pasos enlistados [aqui](#devsReq).

<br/><br/>

# Clinica Dental
### Proyecto para **Programacion Orientada a Objetos** (POO) y **Modelamiento de Bases de Datos** (MDB).
<br />

## Integrantes
- **CD210488** Jairo Rafael Colocho Díaz
- **AE210567** Bryan Josué Alberto Elena
- **CV210468** Oscar Rolando Cañas Valdizón
- **HM210444** Javier Enrique Hernández Márquez
- **PR210566** Mercedes Guadalupe Pérez Rivas
- **VC200416** Francisco Armando Ventura Cortez

<br />

<a name="devsReq"></a>
# Requisitos para desarrolladores
Como este proyecto esta desarrollado bajo `Windows UI Library 2` (UI preparado para Windows 11) necesita que, antes de abrir la solucion del proyecto `Windows_ClinicaDental` se instalen los siguientes requisitos:

| Requisito | Version Minima | Informacion adicional |
| - | :- | -: | 
| Visual Studio 2019 o superior | VS2019 16.11 <br/> VS2022 17.0 Preview 2 | https://visualstudio.microsoft.com/es/<br/>Tambien puedes revisar la version ya instalada desde Visual Studio Installer |
|Carga de trabajo de VS:<br/>`Desarrollo de escritorio de .NET` | | Instalable desde Visual Studio Installer (requiere Visual Studio)<br/>https://docs.microsoft.com/es-es/visualstudio/install/modify-visual-studio?view=vs-2019 |
|Carga de trabajo de VS:<br/>`Desarrollo de la plataforma universal de Windows` |  | Instalable desde Visual Studio Installer (requiere Visual Studio)<br/>https://docs.microsoft.com/es-es/visualstudio/install/modify-visual-studio?view=vs-2019 |
| Extension de VS:<br/>`Windows App SDK (Experimental)` | VS2019 16.11 <br/> VS2022 17.0 Preview 2 <br/> *Cargas de trabajo* antes mencionadas | https://marketplace.visualstudio.com/items?itemName=ProjectReunion.MicrosoftProjectReunionPreview <br/> Tambien instalable desde Visual Studio > Extensiones > Administrar extensiones |
| Paquetes NuGet (ver siguiente seccion) | VS2019 16.11 <br/> VS2022 17.0 Preview 2 <br/> *Cargas de trabajo* antes mencionadas | Ver seccion _"Paquetes NuGet"_ |

<br/>

## Paquetes Nuget

A diferencia de `.NET Framework`, `.NET` no incluye ciertos paquetes / referencias (en ciertos casos) como `System.Data.Sqlclient`, elementos necesarios para que la solucion funcione al 100%. Estos elementos son llamados **Paquetes NuGet**. Ademas, aunque Visual Studio restaure estos paquetes en el momento de compilacion del proyecto, suele pasar que no se restauren completamente y muestre advertencias y/o errores de compilacion y la aplicacion no se habra depurado completamente. <br/> <br/>
Para evitar estos problemas, recomendamos instalarlos manualmente. Para instalarlos, deben:

1. Abrir Visual Studio con la solucion y proyecto `Windows_ClinicaDental` abiertos.
2. Ir a _Pestaña Herramientas > Administrador de paquetes NuGet > Consola de Administrador de Paquetes_. <br/> Se abrira una consola de Powershell.
3. Insertar un comando por paquete segun la siguiente tabla (ingresar todos):

| Paquete NuGet | Comando de Powershell |
| - | -: |
| Microsoft.UI.Xaml | `Install-Package Microsoft.UI.Xaml -Version 2.8.0-prerelease.210927001` |
| Microsoft.Data.SqlClient| `Install-Package Microsoft.Data.SqlClient -Version 4.0.0-preview3.21293.2` |
| Microsoft.Win32.Registry | `Install-Package Microsoft.Win32.Registry -Version 6.0.0-preview.5.21301.5` |
| Microsoft.SqlServer.ConnectionInfo | `Install-Package Microsoft.SqlServer.ConnectionInfo -Version 150.18097.0-xplat` |
| Microsoft.SqlServer.SqlManagementObjects | `Install-Package Microsoft.SqlServer.SqlManagementObjects -Version 161.46521.71` |
| System.Drawing.Common | `Install-Package System.Drawing.Common -Version 6.0.0-rc.2.21480.5` |
| Win2D.uwp | `Install-Package Win2D.uwp -Version 1.26.0` |

<br/>

## Requisitos Adicionales

Tambien necesarios, la aplicacion necesita de estos requisitos para que funcione totalmente y sin errores detectados.
| Requisito | Version Minima | Mas Informacion|
| :- | :-: | -: |
| Windows 10 - Windows 11 | Win10 v1809 comp. 17763 <br/> Win11 v21H1 comp. 22000 | Verifica si existen actualizaciones desde Windows Update |
| SQL Server <strong>\*\*</strong> | Ultima version disponible | Ultima version de **SQL Server _Developer_** <strong>\*\*</strong> |

(**) Solicitamos el uso de SQL Server _Developer_ debido a que la version _Express_ del mismo no es admite el servicio `Agente SQL Server`, servicio necesario para la ejecucion de esta aplicacion. Este servicio permite acceder por medio de la cadena de conexion al servidor en general.


<a name="sqlServer"></a>
# SQL Server

<a name="sqlTcpRef"></a>
## Acceder a SQL Server por medio de tu computadora usando IP

Si quieres usar tu PC como un servidor en tu red de area local (es decir, solamente conexion entre varios dispositivos de tu misma red) deberas habilitar ciertos elementos en tu router\* que permitiran el acceso a tu PC:

1. Establecer la conexion WiFi - Ethernet con una IP dinamica. Deberas establecerla desde tu router usando la _direccion MAC de tu PC_\*\*.
2. Si tu router\* tiene la habilidad de usar servidores virtuales, deberas crear un servidor virtual con la direccion IP dinamica de tu dispositivo.
3. Abrir los _puertos TCP_\*\*\* correspondientes de SQL Server en tu router\*. De manera predeterminada, el puerto es `1433` (tanto de entrada como de salida).

**(\*)**: Los pasos pueden depender de las marcas y modelos de router.<br/>
**(\*\*)**: Puedes obtener la direccion MAC por medio del `Simbolo del Sistema`, escribiendo el comando `ipconfig /all` y finalmente buscar el dispositivo a utilizar.<br/>
***(\*\*\*)***: Si abriste los puertos y aun no puedes conectarte, pueda que necesites tambien abrir los puertos TCP desde el `Firewall de Windows con Seguridad Avanzada`.