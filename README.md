# Ufinet Prueba Técnica

Este proyecto es un API Rest desarrollado en lenguaje C# (.Net 6) que permite obtener información de hoteles y restaurantes por país. La información se devuelve en formato JSON y se implementa una paginación que se realiza en la capa de base de datos para optimizar el rendimiento de la aplicación. Además, se agrega un header en la respuesta para indicar la cantidad total de registros.

## Requisitos previos

Para poder ejecutar este proyecto en su máquina local, debe tener instalados los siguientes programas:

- [Visual Studio 2022 o superior](https://visualstudio.microsoft.com/es/downloads/) o [Visual Studio Code](https://code.visualstudio.com/download)
- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) o superior
- [SQL Server 2019](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) o superior

## Configuración

Para poder ejecutar este proyecto, siga los siguientes pasos:

1. Clone el repositorio en su máquina local.
2. Abra el proyecto en Visual Studio.
3. Abra el archivo `appsettings.json` en la raíz del proyecto y cambie la cadena de conexión para que coincida con su propia base de datos.

## Uso

Para utilizar este proyecto, siga los siguientes pasos:

1. Ejecute el proyecto en Visual Studio.
2. Abra su navegador web e ingrese la dirección `https://localhost:port/api/countries`, donde `port` es el número de puerto asignado por su servidor local.
3. Obtendrá una lista de países en formato JSON, donde cada país tiene una lista de hoteles y restaurantes.
4. Si desea paginar los resultados, simplemente agregue los parámetros `pageNumber` y `pageSize` a la URL. Por ejemplo, `https://localhost:port/Countries?pageNumber=1&pageSize=10` devolverá los primeros 10 resultados.

¡Disfrute utilizando este API Rest y no dude en contactarnos si tiene alguna pregunta o comentario!
