Descripción del Proyecto
Solución Completa
La solución se compone de cuatro proyectos, siguiendo la arquitectura hexagonal. Estos proyectos son:

test.domain:

Función: Define la entidad Transaction y las interfaces para los repositorios y servicios.

Propósito: Mantener la lógica de negocio independiente de las dependencias externas.

test.application:

Función: Implementa los servicios de negocio que manipulan las transacciones.

Propósito: Gestionar la lógica de negocio y los casos de uso como crear, editar y consultar transacciones.

test.infrastructure:

Función: Implementa repositorios para conectarse a MongoDB.

Propósito: Manejar la persistencia de datos y las interacciones con la base de datos.

test.webapi:

Función: Exposición de la API RESTful y configuración de la autenticación JWT.

Propósito: Proveer endpoints para operaciones CRUD y asegurar la API con autenticación JWT.


Instrucciones para Ejecutar la Solución
1. Clonar el Repositorio
Primero, clona el repositorio desde GitHub a tu máquina local.
git clone https://github.com/tu-usuario/tu-repositorio.git
2. Abrir la Solución en Visual Studio
Abre Visual Studio y carga la solución Hexagonal2.sln.

3. Configurar la Cadena de Conexión de MongoDB
Abre el archivo Startup.cs en el proyecto test.webapi.

Configura la cadena de conexión de MongoDB como sigue:
services.AddSingleton<IMongoClient>(new MongoClient("mongodb://usrmultiradicador:multiradicador*2020@20.109.8.103:29029/?authSource=isalud-multiradicador-pre-ips"));

Esta cadena de conexión ha sido suministrada por el área de integración y conecta a una base de datos MongoDB para almacenar transacciones.

4. Ejecutar el Proyecto
Presiona F5 en Visual Studio para ejecutar la solución.

Esto iniciará el servidor web y abrirá Swagger UI en tu navegador.

5. Generar el Token JWT
Para acceder a los endpoints protegidos, sigue estos pasos:

En Swagger UI o Postman, realiza una solicitud POST al endpoint /api/auth/login con el siguiente cuerpo:

{
    "Username": "testuser",
    "Password": "password"
}
Copia el token JWT de la respuesta.

6. Consumir los Endpoints Protegidos
En Postman, crea una nueva solicitud para el endpoint que deseas probar (por ejemplo, POST /api/transactions).

Añade el encabezado Authorization con el valor Bearer <tu_token_aquí>.

En el cuerpo de la solicitud, añade los datos correspondientes. Por ejemplo, para crear una transacción:
{
    "Amount": 150.0,
    "Currency": "USD",
    "Date": "2023-10-18T00:00:00Z",
    "Status": "Pending"
}
