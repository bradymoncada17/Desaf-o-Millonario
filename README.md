Trivia Millonaria — Proyecto Final en C#
Descripción del proyecto

Trivia Millonaria es una aplicación de escritorio desarrollada en C# con Windows Forms y SQL Server.
Simula un juego de preguntas tipo “¿Quién quiere ser millonario?”, en el que el usuario responde preguntas de opción múltiple y acumula dinero virtual según su desempeño.

Objetivo general

Desarrollar una aplicación de escritorio en C# que permita realizar un juego de trivia con almacenamiento de datos en SQL Server y funcionalidades de registro, control de partidas y ranking de jugadores.

Objetivos específicos

Diseñar una base de datos relacional con las tablas necesarias.

Implementar una interfaz gráfica en Windows Forms.

Desarrollar la lógica del juego y sus validaciones.

Aplicar los patrones Factory, Singleton y Repository.

Permitir carga masiva de preguntas desde Excel o CSV.

Incluir control de acceso al módulo de administración.

Arquitectura técnica
Capa	Contenido
Presentación	Formularios de Windows Forms
Lógica	Clases del dominio del juego
Datos	Repositorios y conexión a SQL (Singleton + Repository)
BD	SQL Server con claves primarias y foráneas
Formularios principales
Formulario	Función
FormularioRegistroUsuario	Permite registrar o iniciar sesión
FormularioPrincipal	Menú principal
FormularioJuego	Muestra las preguntas y controla el progreso
FormularioRanking	Muestra los mejores jugadores
FormularioAdmin	Permite administrar preguntas (solo usuario Brady)
Diseño de la base de datos

Tablas: Usuarios, Preguntas, Opciones, Partidas, RespuestasPartida.
Relaciones:

Usuarios (1 - N) Partidas

Preguntas (1 - N) Opciones

Partidas (1 - N) RespuestasPartida

Tecnologías utilizadas

C# (.NET Framework)

Windows Forms

SQL Server

ADO.NET

Visual Studio

Ejecución del proyecto

Clonar el repositorio:

git clone https://github.com/tuusuario/Millonario-Challenge.git


Abrir el archivo .sln en Visual Studio.

Ejecutar el script MillonarioDB.sql en SQL Server.

Configurar la cadena de conexión en ConexionBD.cs.

Ejecutar el proyecto con Ctrl + F5.

Capturas, 
<img width="535" height="380" alt="image" src="https://github.com/user-attachments/assets/2a88f816-1b18-4908-9a3d-32a5fa9e9fa2" />
<img width="534" height="388" alt="image" src="https://github.com/user-attachments/assets/00882659-23b5-4e67-a9b2-6a017d31126e" />
<img width="810" height="491" alt="image" src="https://github.com/user-attachments/assets/5bdb0a18-79d0-4398-b833-c87354840d01" />
<img width="1409" height="641" alt="image" src="https://github.com/user-attachments/assets/f7a7a4f5-77bf-478b-923a-c9cfb07d7cbb" />
<img width="808" height="486" alt="image" src="https://github.com/user-attachments/assets/bc63b08d-f674-41f5-b985-8df8b52e20f8" />
<img width="775" height="378" alt="image" src="https://github.com/user-attachments/assets/c246304a-cd4c-48ce-b826-31726e6498e3" />
<img width="574" height="600" alt="image" src="https://github.com/user-attachments/assets/4d043b75-14d2-478d-b03b-e3f6cb45f87d" />
Juego
<img width="806" height="487" alt="image" src="https://github.com/user-attachments/assets/22505ca3-826e-4399-8579-048024aacee1" />
50:50
<img width="808" height="486" alt="image" src="https://github.com/user-attachments/assets/6982e6d3-1946-4196-ab38-15d0a2a091da" />
Retirarse
<img width="941" height="511" alt="image" src="https://github.com/user-attachments/assets/e4ee8693-5a95-4237-ba32-47d86d7dda5e" />




Autores

Brady Alexander Moncada Jiménez
David Muños Suárez
Instituto Universitario Pascual Bravo
Tecnología en Desarrollo de Software — 2025
