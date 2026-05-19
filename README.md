# ♟️ Juego de Estrategia en Tablero — C#

**Carrera:** Ingeniería en Sistemas
**Institución:** Universidad Rafael Landívar
**Curso:** Pensamiento Computacional — Facultad de Ingeniería
**Versión:** 1.0 — Windows Forms Edition

---

## 👥 Equipo de Trabajo

1. **Edwin Esteban Cox Tay**
2. **Adrián Alejandro Gutiérrez Santos**
3. **Anllela Yasmín Pérez Pérez**

---

## 📝 Descripción del Proyecto

Juego de estrategia por turnos desarrollado en **C#** con **Windows Forms**. Dos jugadores se enfrentan en un tablero de 8×8 moviendo piezas con reglas específicas. El objetivo es capturar el Rey del oponente o eliminar todas sus piezas.

El proyecto aplica:
- Programación Orientada a Objetos (clases: `Jugador`, `Pieza`, `Tablero`, `Juego`)
- Matrices bidimensionales para representar el tablero
- Ciclos y estructuras condicionales
- Validación completa de movimientos
- Interfaz gráfica con Windows Forms y GDI+

---

## 🎮 Piezas del juego

| Pieza | Símbolo J1 | Símbolo J2 | Movimiento |
|-------|-----------|-----------|------------|
| Rey | ♔ | ♚ | 1 casilla en cualquier dirección |
| Torre | ♖ | ♜ | Línea recta sin saltar piezas |
| Soldado | ♙ | ♟ | Avanza 1 hacia adelante, captura en diagonal |

---

## 🗺️ Sistema de Coordenadas

El tablero usa **números para filas (0-7)** y **letras para columnas (A-H)**:

```
    A   B   C   D   E   F   G   H
0  ♜   ·   ·   ·  ♚   ·   ·  ♜
1   ·   ·  ♟  ♟  ♟  ♟   ·   ·
2   ·   ·   ·   ·   ·   ·   ·   ·
3   ·   ·   ·   ·   ·   ·   ·   ·
4   ·   ·   ·   ·   ·   ·   ·   ·
5   ·   ·   ·   ·   ·   ·   ·   ·
6   ·   ·  ♙  ♙  ♙  ♙   ·   ·
7  ♖   ·   ·   ·  ♔   ·   ·  ♖
```

Para mover una pieza se ingresa: **fila + letra** separados por espacio.
Ejemplo: `6 C` → fila 6, columna C

---

## 🔐 Credenciales de acceso

| Campo | Valor |
|-------|-------|
| Usuario | `admin` |
| Contraseña | `Sistemas2026!` |

> La contraseña cumple todos los requisitos de seguridad: mayúscula, minúscula, número y carácter especial.

---

## 🏆 Sistema de puntaje

| Pieza capturada | Puntos |
|----------------|--------|
| Soldado | 10 pts |
| Torre | 10 pts |
| Rey | 60 pts (10 base + 50 adicionales) |

El sistema guarda automáticamente el mejor puntaje de la sesión.

---

## 📖 Manual de Usuario

👉 [Ver Manual de Usuario](https://eect17.github.io/JuegoProyectoFinal/manual/manual_usuarios_ajedres.html)

---

## 🚀 Cómo ejecutar el juego

1. Clona o descarga el repositorio
2. Abre el archivo **`JuegoProyectoFinal.slnx`** en Visual Studio
3. Presiona **F5** o el botón **Iniciar**
4. Ingresa las credenciales en el login
5. Registra los nombres de los dos jugadores
6. ¡A jugar!

---

## 📂 Estructura del Repositorio

```
JuegoProyectoFinal/
├── JuegoProyectoFinal/        # Código fuente del proyecto
│   ├── FormJuego.cs           # Formulario principal del juego
│   ├── FormLogin.cs           # Formulario de autenticación
│   ├── FormMenu.cs            # Menú principal
│   ├── FormJugadores.cs       # Registro de jugadores
│   ├── Juego.cs               # Lógica central del juego
│   ├── Jugador.cs             # Clase Jugador
│   ├── Pieza.cs               # Clase Pieza
│   ├── Tablero.cs             # Clase Tablero (matriz 8x8)
│   ├── Login.cs               # Login versión consola
│   └── Menu.cs                # Menú versión consola
├── manual/                    # Manual de usuario
│   ├── manual_usuarios_ajedres.html
│   └── img_manual/
├── JuegoProyectoFinal.slnx    # Archivo de solución Visual Studio
└── LÉAME.md                   # Este archivo
```

---

## 🛠️ Tecnologías utilizadas

- **Lenguaje:** C# (.NET)
- **Interfaz:** Windows Forms + GDI+
- **IDE:** Visual Studio
- **Control de versiones:** Git + GitHub

---

## 📋 Reglas del juego

- El juego alterna turnos entre dos jugadores
- Cada jugador tiene: 1 Rey, 2 Torres y 4 Soldados
- Gana quien capture el Rey rival o elimine todas sus piezas
- Los movimientos inválidos son rechazados automáticamente
- No se puede mover piezas del rival ni salir del tablero
