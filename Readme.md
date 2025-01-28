# Task Manager

## Descripción
Este proyecto fue realizado backend(.net core 8 API) y frontend con blazor WASM.

## Decisiones Técnicas
- **Blazor WASM**: pues tiene baja latencia ya que no usa signalR para el manejo de eventos, y me parece mucho mas sencillo de implementar, aunque claro, se demora bastante en cargar.
- **Servicios**: Uso de servicios para el manejo de la lógica entre componentes
- **Architecture**: Trate de hacer una architectura limpia y reducida.

## Posibles Mejoras
- **Interfaz de Usuario**: hubiera querido implementar tailwind, tampoco tuve tiempo de corregir un error, cuando se crea la task no se actualiza la lista.
- **Autenticación**: me falto implementar todo lo de autenticacion.
- **Repository Pattern**: pro lo general siempre implemento repository pattern en todos mis proyectos para simplificar los crud.
- **manejo de errores en el frontend**: me falto manejo de errores badrequest en algunas partes del frontend.
- **Extensiones**: trato de limpiar mucho los program.cs con el uso de extensiones
- **MediaTr**: Prefiero hacer uso de Mediatr para evitar mucha dependencia de servicios, tambien hubiera sido mejor usar desde mi punto de vista una arquitectura ViewModel en el frontend y hacer uso de Properties Notifier, estoy aconstumbrado a esto ya que actualmente trabajo mucho con xaml para desktop applications.
- **Validaciones**: me falto validators en el frontend para no enviar cualquier cosa en el formulario.
- **Testing**: falto testing tanto en el front como back, falta de tiempo.
- **Filtros**: pude implementar el filtro en el backend para filtrar los registros por estado pero no alcancé hacerlo en el frontend.

## Cómo Ejecutar
1. Abrir el proyecto en Visual Studio ultima version .net 8.
2. Ejecutar ambos proyectos en http no https, 
3. Acceder a `https://localhost:5051` para el frontend.
4. El swagger del backend está en el puerto `https://localhost:5050`.

