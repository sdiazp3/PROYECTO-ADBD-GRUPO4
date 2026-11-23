# Proyecto Integrador - Sistema de Gestión de Ayudantías de Cátedra

## Integrantes

Díaz Pontón Steven Santiago
Gamarra Zárate Jamileth Estefanía
Herrera Ramos Thais Melanie
Tigasi Sampedro Paul Alexander.

## Descripción del proyecto

Aplicación de escritorio para la gestión de ayudantías de cátedra en la Universidad Técnica Estatal de Quevedo (UTEQ). Permite administrar usuarios (Administrador, Coordinador, Docente y Estudiante), facultades, carreras, asignaturas, períodos académicos, convocatorias y postulaciones, y generar reportes y predicciones.

Asignatura: Administración de Base de Datos · Ingeniería de Software · UTEQ.

## Tecnologías utilizadas

| Parte | Tecnología |
|---|---|
| Lenguaje e interfaz | C# .NET 10, Windows Forms |
| Base de datos | PostgreSQL 14 o superior (extensión `pgcrypto`) |
| Gestor de base de datos | pgAdmin o DBeaver |
| Conexión | Npgsql |
| Reportes | QuestPDF (PDF) y DocumentFormat.OpenXml (Word) |

## Requisitos previos

- Visual Studio 2026 (.NET 10).
- PostgreSQL instalado y en ejecución.

## Instrucciones para configurar y ejecutar

### 1. Base de datos

Cree una base llamada `ayudantias_catedra` en pgAdmin o DBeaver y ejecute **en este orden**, sobre esa base, los scripts de la carpeta `BaseDeDatos/`:

1. `ayudantias_catedra.sql`: tablas, procedimientos, funciones, datos de ejemplo y el usuario `app_ayudantias`.
2. `actualizacion_periodos_predicciones.sql`: períodos académicos anteriores y las funciones de predicción. No modifica tablas y se puede ejecutar más de una vez.

Antes de ejecutar el primero puede cambiar la contraseña del usuario `app_ayudantias` (inicio de la PARTE 4 del script).

### 2. Conexión

Copie `SistemaAyudantias/appsettings.example.json` como `SistemaAyudantias/appsettings.json` y ajuste la cadena de conexión:

```json
{
  "ConexionPostgreSQL": "Host=localhost;Port=5432;Database=ayudantias_catedra;Username=app_ayudantias;Password=SU_CLAVE",
  "Institucion": "Universidad Técnica Estatal de Quevedo"
}
```

La contraseña debe coincidir con la de la PARTE 4 del script. `appsettings.json` no se sube a GitHub (está en `.gitignore`).

### 3. Ejecución

Abra `SistemaAyudantias.sln` en Visual Studio y presione **F5**.

## Credenciales de acceso (usuarios de prueba)

Contraseña de todos: `Ayudantia2026`

| Rol | Correo |
|---|---|
| Administrador | `admin@uteq.edu.ec` |
| Coordinador | `coordinador@uteq.edu.ec` |
| Docente | `docente@uteq.edu.ec` |
| Estudiante | `ana.torres@uteq.edu.ec` |

## Funcionalidades implementadas

- Inicio de sesión seguro con roles; contraseñas cifradas con bcrypt y cambio de la propia contraseña.
- CRUD de usuarios, facultades, carreras, asignaturas y períodos académicos (RF-01, RF-02, RF-03).
- Publicación de convocatorias por el coordinador (RF-04).
- Postulación del estudiante con documento PDF y evaluación de postulantes (RF-05, RF-06).
- Selector de período académico en la cabecera para los 4 roles: todas las pantallas se filtran por el período elegido.
- Predicciones: tendencia de postulaciones con proyección del siguiente período, y por convocatoria los postulantes esperados, la probabilidad de obtener un cupo y la nota de corte estimada.
- Exportación de reportes a PDF y Word (RF-11).

**Pendiente (siguiente versión):** RF-07 a RF-10 (asignación de ayudantes y control de horas).

## Pruebas funcionales

Después de ejecutar los dos scripts:

```
psql -U postgres -d ayudantias_catedra -f BaseDeDatos/pruebas/pruebas_funcionales.sql
```

Ejecuta 56 pruebas y al final hace `ROLLBACK` (no modifica los datos).

(Nota: El script de pruebas utiliza comandos nativos de psql, por lo que debe ejecutarse desde la consola de PostgreSQL y no desde DBeaver)
