# Proyectos de Desarrollo de Software (N-Capas, .NET Core, Vue.js)

A continuación, se presentan cinco opciones de proyectos. El estudiante deberá seleccionar **una** y desarrollarla completamente, aplicando los principios de la **Programación Orientada a Objetos (POO)** y la **Arquitectura N-Capas** (Presentación, Lógica de Negocio/Servicios, Datos/Persistencia).

## 1. Sistema de Gestión de Proyectos Ágil (Mini-Kanban) 📊

### **Objetivo:**
Desarrollar una herramienta para la gestión básica de tareas y proyectos, simulando un tablero Kanban simplificado.

### **Requisitos Funcionales Mínimos:**
1.  **Gestión de Proyectos (CRUD):** Crear, modificar, eliminar y listar proyectos.
2.  **Gestión de Tareas (CRUD):** Asignar tareas a un proyecto. Cada tarea debe tener título, descripción y fecha límite.
3.  **Flujo Kanban:** Las tareas deben poder **cambiar de estado** (ej. Pendiente, En Progreso, Bloqueada, Terminada) arrastrando y soltando (simulado o real).
4.  **Prioridades:** La tarea debe tener una **prioridad** (Baja, Media, Alta, Urgente).
5.  **Filtrado:** El *frontend* debe permitir filtrar tareas por **Estado** y por **Prioridad**.

### **Estructura de Base de Datos (Mínimo 5 Tablas):**
1.  `Proyectos`
2.  `Tareas`
3.  `Estados` (Tabla de catálogo: ID, Nombre del Estado)
4.  `Prioridades` (Tabla de catálogo: ID, Nivel de Prioridad)
5.  `Usuarios` (Para asignar tareas a un responsable)

***

## 2. Catálogo de Cursos en Línea (e-Learning) 📚

### **Objetivo:**
Implementar un sistema que administre la estructura jerárquica de cursos, módulos y lecciones, y gestione las inscripciones de los usuarios.

### **Requisitos Funcionales Mínimos:**
1.  **Administración de Contenido (CRUD):** Permitir a un usuario administrador crear, editar y listar:
    * **Cursos** (Título, Descripción, Precio, Imagen).
    * **Módulos** (Asociados a un Curso).
    * **Lecciones** (Asociadas a un Módulo).
2.  **Categorización:** Cada curso debe estar asociado a una **Categoría** (ej. Desarrollo, Diseño, Negocios).
3.  **Inscripción:** El *frontend* debe simular un proceso de **inscripción de usuarios** a un curso, manejando la relación muchos a muchos.
4.  **Vista de Catálogo:** Mostrar todos los cursos disponibles en el *frontend* con la opción de ver detalles y simular la inscripción.

### **Estructura de Base de Datos (Mínimo 5 Tablas):**
1.  `Cursos`
2.  `Módulos`
3.  `Lecciones`
4.  `Categorías`
5.  `Usuarios`
6.  `Inscripciones` (Tabla intermedia muchos a muchos: Usuario $\leftrightarrow$ Curso)

***

## 3. Sistema de Inventario con Proveedores 📦

### **Objetivo:**
Crear un sistema básico para gestionar el inventario de productos, incluyendo la información de sus proveedores y un registro de órdenes de compra.

### **Requisitos Funcionales Mínimos:**
1.  **Gestión de Productos (CRUD):** Inventario de productos con nombre, precio unitario, stock y **asociación a una Categoría**.
2.  **Gestión de Proveedores (CRUD):** Registro de proveedores con información de contacto.
3.  **Órdenes de Compra:** Implementar la lógica para **registrar una nueva Orden de Compra**. Una orden debe asociarse a un **Proveedor** y contener **Detalles** (qué productos y qué cantidad se compraron).
4.  **Actualización de Stock:** Al registrar una Orden de Compra, el *backend* debe **actualizar automáticamente el *stock*** de los productos involucrados.
5.  **Reporte:** Mostrar un listado de todos los productos y su proveedor asociado.

### **Estructura de Base de Datos (Mínimo 5 Tablas):**
1.  `Productos`
2.  `Proveedores`
3.  `Categorías`
4.  `OrdenesCompra`
5.  `DetallesOrden` (Tabla intermedia: Orden $\leftrightarrow$ Producto)

***

## 4. Sistema de Recetas de Cocina Interactivo 🍲

### **Objetivo:**
Desarrollar una plataforma para la creación, consulta y valoración de recetas de cocina, enfocándose en las relaciones de ingredientes.

### **Requisitos Funcionales Mínimos:**
1.  **Gestión de Recetas (CRUD):** Crear recetas con título, descripción, tiempo de preparación y pasos.
2.  **Ingredientes:** Implementar una relación muchos a muchos entre **Recetas** e **Ingredientes**. Al crear una receta, se debe especificar la **cantidad** y la **unidad de medida** de cada ingrediente.
3.  **Clasificación:** Cada receta debe pertenecer a una **Categoría de Cocina** (ej. Postres, Vegano, Mexicana).
4.  **Interacción de Usuario:** Permitir a los usuarios **dejar un comentario y una calificación** (1 a 5 estrellas) en cada receta.
5.  **Vista Pública:** El *frontend* debe mostrar las recetas, su lista de ingredientes formateada y el promedio de calificaciones.

### **Estructura de Base de Datos (Mínimo 5 Tablas):**
1.  `Recetas`
2.  `Ingredientes`
3.  `CategoriasCocina`
4.  `UnidadesMedida` (Tabla de catálogo: gramos, tazas, ml, etc.)
5.  `RecetaIngrediente` (Tabla intermedia: Receta $\leftrightarrow$ Ingrediente, con campo Cantidad)
6.  `ComentariosRatings` (Asociado a Receta y Usuario)

***

## 5. Plataforma de Reservas de Citas Médicas Ficticia 📅

### **Objetivo:**
Simular un sistema de reservas de citas, manejando la disponibilidad horaria de médicos y la gestión de pacientes y especialidades.

### **Requisitos Funcionales Mínimos:**
1.  **Gestión de Catálogos (CRUD):** Administrar **Médicos** y **Especialidades**. Cada médico debe estar asociado a una especialidad.
2.  **Gestión de Pacientes (CRUD):** Registro de pacientes con información básica.
3.  **Disponibilidad Horaria:** Implementar la lógica para que el *backend* verifique la **disponibilidad del Médico** antes de crear una cita. Un médico solo puede tener una cita por franja horaria.
4.  **Creación de Citas:** El *frontend* debe permitir seleccionar un **Médico** y una **fecha/hora** (franja de 30 minutos) y registrar la cita, asociándola al **Paciente**.
5.  **Consulta de Citas:** Mostrar un listado de todas las citas agendadas, con el nombre del médico, paciente y especialidad.

### **Estructura de Base de Datos (Mínimo 5 Tablas):**
1.  `Pacientes`
2.  `Médicos`
3.  `Especialidades`
4.  `HorariosDisponibles` (Configuración de la disponibilidad del médico)
5.  `Citas` (Asociado a Paciente, Médico y Fecha/Hora)
