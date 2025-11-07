Trivia Millonaria — Proyecto Final en C#
Descripción del proyecto

Trivia Millonaria es una aplicación de escritorio desarrollada en C# con Windows Forms y SQL Server.
Simula el clásico juego de preguntas tipo “¿Quién quiere ser millonario?”, en el que el usuario responde preguntas de opción múltiple y acumula dinero virtual según su desempeño.

El proyecto combina conocimientos de:

Programación orientada a objetos

Manejo de bases de datos relacionales

Conexión ADO.NET

Diseño de interfaces gráficas en C#

Objetivo general

Desarrollar una aplicación de escritorio en C# que permita realizar un juego de trivia con almacenamiento de datos en SQL Server y funcionalidades de registro, control de partidas y ranking de jugadores.

Objetivos específicos

Diseñar y crear una base de datos relacional para gestionar usuarios, preguntas, opciones, partidas y respuestas.

Implementar una interfaz gráfica en Windows Forms que facilite la interacción con el usuario.

Desarrollar la lógica del juego, incluyendo validaciones, registro de resultados y control de ayudas.

Aplicar conceptos de persistencia de datos mediante ADO.NET y comandos SQL.

Incorporar un sistema de control de acceso al módulo de administración para usuarios autorizados.

Permitir la carga masiva de preguntas desde archivos Excel o CSV.

Evaluar el funcionamiento general del sistema mediante pruebas funcionales y de integración.

Diseño de la base de datos

La base de datos MillonarioDB fue diseñada bajo los principios de la normalización y las buenas prácticas relacionales.

Tablas principales:
Tabla	Descripción
Usuarios	Registra los jugadores (UsuarioId, NombreUsuario, NombreCompleto).
Preguntas	Contiene el texto de la pregunta, dificultad, premio y categoría.
Opciones	Guarda las opciones de cada pregunta e indica la correcta.
Partidas	Representa cada sesión de juego de un usuario.
RespuestasPartida	Almacena las respuestas seleccionadas por cada jugador.
Relaciones principales

Usuarios (1 - N) Partidas

Preguntas (1 - N) Opciones

Partidas (1 - N) RespuestasPartida

Preguntas (1 - N) RespuestasPartida

Diagrama entidad-relación

(Inserta aquí el pantallazo exportado de SQL Server)

/Recursos/diagrama_ER.png

Interfaz gráfica

El sistema está compuesto por los siguientes formularios:

Formulario	Función
FormularioRegistroUsuario	Permite registrar o iniciar sesión con nombre de usuario.
FormularioPrincipal	Menú principal del juego.
FormularioJuego	Muestra las preguntas y controla el progreso.
FormularioRanking	Lista los mejores jugadores.
FormularioAdmin	Permite agregar, modificar o eliminar preguntas (solo usuarios autorizados).
Pantallazos sugeridos

Guarda los pantallazos en la carpeta /Recursos/ y referencia aquí:

Registro de usuario → /Recursos/registro_usuario.png

Menú principal → /Recursos/menu_principal.png

Juego en ejecución → /Recursos/juego_en_ejecucion.png

Ranking de jugadores → /Recursos/ranking.png

Administración de preguntas → /Recursos/admin_preguntas.png

Reglas de acceso

Solo el usuario Brady puede acceder al módulo de administración de preguntas.

Si otro usuario inicia sesión, el botón “Administrar preguntas” no aparece o se bloquea.

Esta validación se hace tanto visual como lógicamente en el código.

Carga de preguntas desde Excel o CSV

Para agregar preguntas masivamente:

Abrir la plantilla PlantillaPreguntas.xls incluida en la carpeta /Recursos/.

Completar las columnas de la siguiente manera:

| Texto | Categoria | Dificultad | Premio | Opcion1 | Opcion2 | Opcion3 | Opcion4 | Correcta |
|--------|------------|-------------|---------|----------|----------|----------|-----------|
| ¿Cuál es el planeta más grande? | Ciencia | 1 | 100 | Tierra | Marte | Júpiter | Venus | 2 |

Guardar el archivo.

Desde el formulario de administración, usar el botón “Cargar desde Excel” para importar los datos.

Flujo de funcionamiento

El usuario se registra o inicia sesión.

Se crea una nueva partida en la base de datos.

Se seleccionan preguntas aleatorias.

El jugador responde y acumula dinero si acierta.

Si falla, la partida termina y se guardan los resultados.

El ranking se actualiza con las estadísticas de todos los usuarios.

Tecnologías utilizadas
Tecnología	Descripción
C# (.NET Framework)	Lenguaje principal del proyecto.
Windows Forms	Interfaz de usuario.
SQL Server	Sistema de gestión de base de datos.
ADO.NET	Comunicación entre la aplicación y la base de datos.
Visual Studio	Entorno de desarrollo.
Ejecución del proyecto

Clonar el repositorio:

git clone https://github.com/tuusuario/Millonario-Challenge.git


Abrir el archivo .sln en Visual Studio.

Ejecutar el script MillonarioDB.sql en SQL Server para crear la base de datos.

Configurar la conexión en ConexionBD.cs:

private string cadenaConexion = "Data Source=TU_PC\\SQLEXPRESS;Initial Catalog=MillonarioDB;Integrated Security=True;";


Compilar y ejecutar el proyecto con Ctrl + F5.

Pruebas y evidencias

Agrega las imágenes de las pruebas en la carpeta /Recursos/ y referencia cada una:

Prueba	Evidencia
Registro de usuario	/Recursos/prueba_registro.png
Inicio de partida	/Recursos/prueba_inicio.png
Respuesta correcta	/Recursos/prueba_correcta.png
Fin del juego	/Recursos/prueba_fin.png
Exportar ranking	/Recursos/prueba_ranking.png
Créditos

Desarrollado por:
Brady Alexander Moncada Jiménez
David Muños Suárez

Instituto Universitario Pascual Bravo
Programa: Tecnología en Desarrollo de Software
Año: 2025

Evaluación según rúbrica
Criterio	Descripción	Cumplimiento
Documentación	Descripción completa del proyecto, estructura y evidencias	Cumplido
Conexión a base de datos	Correcta configuración en SQL Server	Cumplido
Interfaz funcional	Formulario operativos y validados	Cumplido
Importación de datos	Implementada con carga desde Excel	Cumplido
Control de acceso	Módulo restringido a usuario autorizado	Cumplido
Registro de resultados	Guardado y ranking funcional	Cumplido
