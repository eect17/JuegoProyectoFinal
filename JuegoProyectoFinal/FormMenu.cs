using JuegoTablero;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace JuegoProyectoFinal
{
    public class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Juego de Tablero";
            this.Size = new Size(420, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(28, 28, 38);

            var lblTitulo = new Label();
            lblTitulo.Text = "♟";
            lblTitulo.Font = new Font("Segoe UI Symbol", 48);
            lblTitulo.ForeColor = Color.FromArgb(220, 180, 90);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(170, 30);

            var lblNombre = new Label();
            lblNombre.Text = "JUEGO DE TABLERO";
            lblNombre.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblNombre.ForeColor = Color.White;
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(80, 110);

            var lblSub = new Label();
            lblSub.Text = "Rey · Torre · Soldado";
            lblSub.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblSub.ForeColor = Color.FromArgb(150, 150, 180);
            lblSub.AutoSize = true;
            lblSub.Location = new Point(135, 148);

            var sep = new Panel();
            sep.BackColor = Color.FromArgb(220, 180, 90);
            sep.Location = new Point(80, 175);
            sep.Size = new Size(250, 2);

            var btnJugar = CrearBoton("▶  Iniciar Partida", Color.FromArgb(80, 180, 100), 210);
            btnJugar.Click += BtnJugar_Click;

            var btnReglas = CrearBoton("📋  Ver Reglas", Color.FromArgb(80, 130, 200), 268);
            btnReglas.Click += BtnReglas_Click;

            var btnPuntaje = CrearBoton("🏆  Mejor Puntaje", Color.FromArgb(180, 140, 50), 326);
            btnPuntaje.Click += BtnPuntaje_Click;

            var btnSalir = CrearBoton("✕  Salir", Color.FromArgb(180, 70, 70), 384);
            btnSalir.Click += (s, e) => Application.Exit();

            var lblCredito = new Label();
            lblCredito.Text = "v1.0 — Windows Forms Edition";
            lblCredito.Font = new Font("Segoe UI", 8);
            lblCredito.ForeColor = Color.FromArgb(80, 80, 100);
            lblCredito.AutoSize = true;
            lblCredito.Location = new Point(130, 460);

            this.Controls.AddRange(new Control[] {
                lblTitulo, lblNombre, lblSub, sep,
                btnJugar, btnReglas, btnPuntaje, btnSalir, lblCredito
            });
        }

        private Button CrearBoton(string texto, Color color, int y)
        {
            var btn = new Button();
            btn.Text = texto;
            btn.Location = new Point(80, y);
            btn.Size = new Size(250, 46);
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            return btn;
        }

        private void BtnJugar_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            if (login.ShowDialog() != DialogResult.OK) return;

            FormJugadores fj = new FormJugadores();
            if (fj.ShowDialog() != DialogResult.OK) return;

            Juego juego = new Juego();
            juego.Iniciar(fj.NombreJ1, fj.NombreJ2);

            FormJuego fJuego = new FormJuego(juego);
            fJuego.ShowDialog();
        }

        private void BtnReglas_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "REGLAS DEL JUEGO:\n\n" +
                "♔ Rey: Se mueve 1 casilla en cualquier dirección.\n" +
                "♖ Torre: Se mueve en línea recta sin saltar piezas.\n" +
                "♙ Soldado: Avanza 1 casilla hacia adelante.\n" +
                "         Captura en diagonal (1 casilla).\n\n" +
                "• Gana quien capture el Rey enemigo.\n" +
                "• También gana si el rival pierde todas sus piezas.\n" +
                "• Capturar una pieza = +10 puntos.\n" +
                "• Capturar el Rey = +60 puntos.\n\n" +
                "Haz click en tu pieza y luego en el destino.",
                "Reglas del Juego",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnPuntaje_Click(object sender, EventArgs e)
        {
            string msg = Juego.mejorJugador == ""
                ? "Aún no hay puntajes registrados"
                : $"🏆 Mejor Jugador: {Juego.mejorJugador}\n   Puntaje: {Juego.mejorPuntaje} puntos";

            MessageBox.Show(msg, "Mejor Puntaje Global",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}