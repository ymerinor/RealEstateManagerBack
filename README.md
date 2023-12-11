# RealEstateManagerBack

Bienvenido al proyecto RealEstateManager Este proyecto implementa una solución basada en TDD (Desarrollo Guiado por Pruebas) y sigue la arquitectura hexagonal. La aplicación consta de una API, contenerizada en Docker, y utiliza una base de datos también contenerizada.

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
3. Después de iniciar la base de datos, ejecuta el archivo `init-db.sql` en tu herramienta de administración de SQL para crear la base de datos y la tabla necesaria.
## Uso de la API
La API estará disponible en la URL [http://localhost:puerto](http://localhost:puerto), donde "puerto" es el puerto que hayas configurado en tu archivo `docker-compose.yml`.


## Ejecutar Pruebas
El proyecto está diseñado con TDD. Puedes ejecutar las pruebas utilizando tu entorno de desarrollo preferido.

## Validación de Logs

Para validar los logs generados por la aplicación, puedes acceder a la ruta dentro del contenedor Docker donde se almacenan los logs. La ubicación predeterminada es:

```plaintext
/app/Logs/
```
