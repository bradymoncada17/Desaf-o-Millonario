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

Capturas sugeridas

Guarda las imágenes en la carpeta /Recursos/ y referencia:

/Recursos/registro_usuario.png

/Recursos/menu_principal.png

/Recursos/juego.png

/Recursos/ranking.png

/Recursos/admin.png

Autores

Brady Alexander Moncada Jiménez
David Muños Suárez
Instituto Universitario Pascual Bravo
Tecnología en Desarrollo de Software — 2025
