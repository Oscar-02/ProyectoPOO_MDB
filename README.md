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
<br/>

## Requisitos Adicionales

Tambien necesarios, la aplicacion necesita de estos requisitos para que funcione totalmente y sin errores detectados.
| Requisito | Version Minima | Mas Informacion|
| :- | :-: | -: |
| Windows 10 - Windows 11 | Win10 v1809 comp. 17763 <br/> Win11 v21H1 comp. 22000 | Verifica si existen actualizaciones desde Windows Update |
| SQL Server | Ultima version disponible | Recomendamos usar **SQL Server Developer** para el funcionamiento de esta aplicacion, aunque seguimos probando si _SQL Server Express_ es compatible con el entorno de trabajo |