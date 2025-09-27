Este es un simulador balistico para la materia Simuladores, hecho en Unity 6, al jugarlo habrán varios sliders, un botón y una lista desplegable, el botón dispara el proyectil, el slider rojo indicará el angulo en el eje vertical, el slider blanco el ángulo en el eje horizontal y el azul la fuerza del disparo, la lista desplegable tendrá opciones para cambiar la masa del proyectil a disparar
Requisitos mínimos


Controles de disparo en pantalla:
Ángulo y fuerza con Slider o InputField.
Masa del proyectil seleccionable


Disparo físico:
Proyectil con Rigidbody y Collider.
Lanzamiento por AddForce o velocity según el ángulo configurado.


Escena de objetivos:
Estructuras armadas con Rigidbodies y Joints (FixedJoint, HingeJoint o SpringJoint).
Estabilidad inicial correcta. Si se cae sola, está mal configurada.


Registro del resultado:
Guardar datos como tiempo de vuelo, punto de impacto, velocidad relativa, impulso de colisión y piezas derribadas.
Mostrar al final de cada intento: puntuación y un breve “reporte de tiro”.
Link de video: https://youtu.be/JZRrTX5EkrE
