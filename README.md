# RealEstateManagerBack

Bienvenido al proyecto RealEstateManager Este proyecto implementa una solución basada en TDD (Desarrollo Guiado por Pruebas), Net 8 que sigue la arquitectura hexagonal. La aplicación consta de una API y utiliza una base de datos también contenerizada.

## Configuración del Entorno

### Requisitos Previos
Asegúrate de tener instalados los siguientes requisitos previos:
- Docker
- SQL Server Management Studio (u otra herramienta similar) para ejecutar scripts SQL

### Configuración de la Base de Datos
1. Navega a la carpeta `BaseDatos` del proyecto.
2. Ejecuta el siguiente comando en la terminal para iniciar la base de datos en Docker:
    ```bash
    docker-compose up -d
    ```
3. Después de iniciar la base de datos, ejecuta el archivo `init-db.sql` en tu herramienta de administración de SQL para crear la base de datos y la tabla necesaria. para efectos de pruebas se crear algunos regisros en las tablas de  : PropertyType y Owner.
## Uso de la API
La API estará disponible en la URL [http://localhost:puerto](http://localhost:puerto), donde "puerto" es el puerto que hayas configurado en tu archivo `docker-compose.yml`.
# Configuración de la Ruta de Almacenamiento de Archivos

La aplicación RealEstateManager permite almacenar archivos, como imágenes, en una ubicación específica del sistema de archivos. Siga los siguientes pasos para configurar la ruta de almacenamiento de archivos:

## 1. Establecer la Ruta Local

Antes de ejecutar la aplicación, decida en qué ubicación local desea almacenar los archivos, por ejemplo, `D:\StorageProperty`. Asegúrese de que esta carpeta exista y sea accesible.

## 2. Configuración en `appsettings.json`

Abra el archivo `appsettings.json` en la raíz del proyecto y busque la propiedad `PathFileTarget`. Ajuste el valor de esta propiedad con la ruta completa de la carpeta que ha decidido en el paso anterior. Por ejemplo:

```json
{
  "PathFileTarget": "D:\\StorageProperty",
  // Otras configuraciones...
}

## Ejecutar Pruebas
El proyecto está diseñado con TDD. Puedes ejecutar las pruebas utilizando tu entorno de desarrollo preferido.

## Validación de Logs

Para validar los logs generados por la aplicación, puedes acceder a la ruta dentro del contenedor Docker donde se almacenan los logs. La ubicación predeterminada es:

```plaintext
/app/Logs/
```
## Nota
Para ejecutar el proyecto se deja un usuario por defecto y poder obtener el token de acceso: Usuario: yeinermeri@gmail.com -- > Password: 0123456789, este es el unico usuario parametrizado.
