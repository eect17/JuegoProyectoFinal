using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace JuegoProyectoFinal
{
    public class FormJuego : Form
    {
        private const int TAM_CASILLA = 72;
        private const int OFFSET_X = 40;
        private const int OFFSET_Y = 40;

        private Juego juego;
        private Panel panelTablero;
        private Label lblTurno;
        private Label lblPuntajes;
        private Label lblMensaje;
        private Button btnMover;
        private Button btnReiniciar;
        private Button btnMenu;
        private TextBox txtOrigen;
        private TextBox txtDestino;
        private bool juegoTerminado = false;

        public FormJuego(Juego juegoActivo)
        {
            juego = juegoActivo;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            int anchoTablero = TAM_CASILLA * 8 + OFFSET_X * 2;
            int altoTablero = TAM_CASILLA * 8 + OFFSET_Y * 2;

            this.Text = "Juego de Tablero";
            this.Size = new Size(anchoTablero + 240, altoTablero + 40);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(28, 28, 38);

            panelTablero = new Panel();
            panelTablero.Location = new Point(10, 10);
            panelTablero.Size = new Size(anchoTablero, altoTablero);
            panelTablero.BackColor = Color.FromArgb(28, 28, 38);
            panelTablero.Paint += PanelTablero_Paint;

            int lx = anchoTablero + 20;

            lblTurno = new Label();
            lblTurno.Location = new Point(lx, 20);
            lblTurno.Size = new Size(200, 60);
            lblTurno.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTurno.ForeColor = Color.FromArgb(220, 180, 90);
            lblTurno.TextAlign = ContentAlignment.MiddleCenter;

            lblPuntajes = new Label();
            lblPuntajes.Location = new Point(lx, 95);
            lblPuntajes.Size = new Size(200, 80);
            lblPuntajes.Font = new Font("Segoe UI", 10);
            lblPuntajes.ForeColor = Color.White;
            lblPuntajes.TextAlign = ContentAlignment.MiddleLeft;

            // Origen
            var lblOrigen = new Label();
            lblOrigen.Text = "Origen (fila letra):";
            lblOrigen.ForeColor = Color.FromArgb(220, 180, 90);
            lblOrigen.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblOrigen.Location = new Point(lx, 190);
            lblOrigen.AutoSize = true;

            txtOrigen = new TextBox();
            txtOrigen.Location = new Point(lx, 210);
            txtOrigen.Size = new Size(200, 28);
            txtOrigen.Font = new Font("Segoe UI", 12);
            txtOrigen.BackColor = Color.FromArgb(50, 50, 65);
            txtOrigen.ForeColor = Color.White;
            txtOrigen.BorderStyle = BorderStyle.FixedSingle;
            txtOrigen.MaxLength = 3;
            txtOrigen.TextAlign = HorizontalAlignment.Center;

            // Destino
            var lblDestino = new Label();
            lblDestino.Text = "Destino (fila letra):";
            lblDestino.ForeColor = Color.FromArgb(220, 180, 90);
            lblDestino.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblDestino.Location = new Point(lx, 250);
            lblDestino.AutoSize = true;

            txtDestino = new TextBox();
            txtDestino.Location = new Point(lx, 270);
            txtDestino.Size = new Size(200, 28);
            txtDestino.Font = new Font("Segoe UI", 12);
            txtDestino.BackColor = Color.FromArgb(50, 50, 65);
            txtDestino.ForeColor = Color.White;
            txtDestino.BorderStyle = BorderStyle.FixedSingle;
            txtDestino.MaxLength = 3;
            txtDestino.TextAlign = HorizontalAlignment.Center;
            txtDestino.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnMover_Click(s, e); };

            // Ejemplo
            var lblEjemplo = new Label();
            lblEjemplo.Text = "Ejemplo: 6 C";
            lblEjemplo.ForeColor = Color.FromArgb(120, 120, 150);
            lblEjemplo.Font = new Font("Segoe UI", 8, FontStyle.Italic);
            lblEjemplo.Location = new Point(lx, 302);
            lblEjemplo.AutoSize = true;

            // Botón mover
            btnMover = new Button();
            btnMover.Text = "▶ MOVER";
            btnMover.Location = new Point(lx, 325);
            btnMover.Size = new Size(200, 40);
            btnMover.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnMover.BackColor = Color.FromArgb(220, 180, 90);
            btnMover.ForeColor = Color.FromArgb(28, 28, 38);
            btnMover.FlatStyle = FlatStyle.Flat;
            btnMover.FlatAppearance.BorderSize = 0;
            btnMover.Cursor = Cursors.Hand;
            btnMover.Click += BtnMover_Click;

            lblMensaje = new Label();
            lblMensaje.Location = new Point(lx, 375);
            lblMensaje.Size = new Size(200, 50);
            lblMensaje.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblMensaje.ForeColor = Color.FromArgb(160, 220, 160);
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;

            // Leyenda
            var lblLeyenda = new Label();
            lblLeyenda.Location = new Point(lx, 430);
            lblLeyenda.Size = new Size(200, 80);
            lblLeyenda.Font = new Font("Segoe UI", 8);
            lblLeyenda.ForeColor = Color.FromArgb(180, 180, 200);
            lblLeyenda.Text = "LEYENDA:\n♔ ♖ ♙ = J1 (Negras)\n♚ ♜ ♟ = J2 (Blancas)";

            btnReiniciar = new Button();
            btnReiniciar.Text = "↺ Nueva Partida";
            btnReiniciar.Location = new Point(lx, 520);
            btnReiniciar.Size = new Size(200, 35);
            btnReiniciar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnReiniciar.BackColor = Color.FromArgb(80, 160, 220);
            btnReiniciar.ForeColor = Color.White;
            btnReiniciar.FlatStyle = FlatStyle.Flat;
            btnReiniciar.FlatAppearance.BorderSize = 0;
            btnReiniciar.Cursor = Cursors.Hand;
            btnReiniciar.Click += BtnReiniciar_Click;

            btnMenu = new Button();
            btnMenu.Text = "← Menú Principal";
            btnMenu.Location = new Point(lx, 565);
            btnMenu.Size = new Size(200, 35);
            btnMenu.Font = new Font("Segoe UI", 10);
            btnMenu.BackColor = Color.FromArgb(60, 60, 75);
            btnMenu.ForeColor = Color.White;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.Cursor = Cursors.Hand;
            btnMenu.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.AddRange(new Control[] {
                panelTablero, lblTurno, lblPuntajes,
                lblOrigen, txtOrigen,
                lblDestino, txtDestino,
                lblEjemplo, btnMover,
                lblMensaje, lblLeyenda,
                btnReiniciar, btnMenu
            });

            ActualizarInfo();
            ActualizarPuntajes();
        }

        private void BtnMover_Click(object sender, EventArgs e)
        {
            if (juegoTerminado) return;

            // Validar origen
            string[] partsOrigen = txtOrigen.Text.Trim().Split(' ');
            if (partsOrigen.Length != 2)
            {
                MostrarError("Origen inválido. Ejemplo: 6 3");
                return;
            }

            // Validar destino
            string[] partsDestino = txtDestino.Text.Trim().Split(' ');
            if (partsDestino.Length != 2)
            {
                MostrarError("Destino inválido. Ejemplo: 5 3");
                return;
            }

            int f1, c1, f2, c2;

            if (!int.TryParse(partsOrigen[0], out f1))
            {
                MostrarError("Fila inválida. Ejemplo: 6 C");
                return;
            }
            c1 = LetraAColumna(partsOrigen[1]);
            if (c1 == -1)
            {
                MostrarError("Columna inválida. Usa A-H. Ejemplo: 6 C");
                return;
            }

            if (!int.TryParse(partsDestino[0], out f2))
            {
                MostrarError("Fila inválida. Ejemplo: 5 C");
                return;
            }
            c2 = LetraAColumna(partsDestino[1]);
            if (c2 == -1)
            {
                MostrarError("Columna inválida. Usa A-H. Ejemplo: 5 D");
                return;
            }

            if (f1 < 0 || f1 > 7 || c1 < 0 || c1 > 7 ||
                f2 < 0 || f2 > 7 || c2 < 0 || c2 > 7)
            {
                MostrarError("Coordenadas fuera del tablero (0-7).");
                return;
            }

            // Validar que haya pieza en origen
            Pieza pieza = juego.tablero.casillas[f1, c1];
            if (pieza == null)
            {
                MostrarError("No hay pieza en el origen.");
                return;
            }

            if (pieza.jugador != juego.turno)
            {
                MostrarError("Esa pieza no es tuya.");
                return;
            }

            if (juego.tablero.casillas[f2, c2] != null &&
                juego.tablero.casillas[f2, c2].jugador == juego.turno)
            {
                MostrarError("No puedes moverte a tu propia pieza.");
                return;
            }

            if (!juego.MovimientoValido(pieza, f1, c1, f2, c2))
            {
                MostrarError("Movimiento inválido para " + pieza.tipo + ".");
                return;
            }

            // Ejecutar movimiento
            string mensaje = "";
            if (juego.tablero.casillas[f2, c2] != null)
            {
                Pieza comida = juego.tablero.casillas[f2, c2];
                int puntos = 10;
                string extra = "";

                if (comida.tipo == "Rey")
                {
                    puntos += 50;
                    extra = " ¡Capturaste el REY!";
                }

                if (juego.turno == 1) juego.puntosJ1 += puntos;
                else juego.puntosJ2 += puntos;

                mensaje = "¡Captura! +" + puntos + " pts" + extra;
            }

            juego.tablero.casillas[f2, c2] = pieza;
            juego.tablero.casillas[f1, c1] = null;

            // Verificar ganador
            string ganador = juego.VerificarGanador();
            if (ganador != null)
            {
                int pts = (ganador == juego.j1.nombre) ? juego.puntosJ1 : juego.puntosJ2;
                if (pts > Juego.mejorPuntaje)
                {
                    Juego.mejorPuntaje = pts;
                    Juego.mejorJugador = ganador;
                }

                juegoTerminado = true;
                panelTablero.Invalidate();
                ActualizarInfo();
                ActualizarPuntajes();

                MessageBox.Show(
                    $"🏆 ¡{ganador} ha ganado la partida!\n\n" +
                    $"Mejor jugador global: {Juego.mejorJugador}\n" +
                    $"Mejor puntaje: {Juego.mejorPuntaje}",
                    "¡Fin del juego!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            juego.turno = (juego.turno == 1) ? 2 : 1;

            txtOrigen.Clear();
            txtDestino.Clear();
            txtOrigen.Focus();

            lblMensaje.ForeColor = Color.FromArgb(160, 220, 160);
            lblMensaje.Text = mensaje == "" ? "¡Movimiento realizado!" : mensaje;

            panelTablero.Invalidate();
            ActualizarInfo();
            ActualizarPuntajes();
        }

        private void MostrarError(string msg)
        {
            lblMensaje.ForeColor = Color.FromArgb(220, 80, 80);
            lblMensaje.Text = msg;
            txtOrigen.Focus();
        }

        private void PanelTablero_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Font fCoord = new Font("Segoe UI", 9, FontStyle.Bold);
            for (int i = 0; i < 8; i++)
            {
                g.DrawString(i.ToString(), fCoord, Brushes.Gray,
                    OFFSET_X - 20, OFFSET_Y + i * TAM_CASILLA + TAM_CASILLA / 2 - 8);
                string letraCol = ((char)('A' + i)).ToString();
                g.DrawString(letraCol, fCoord, Brushes.Gray,
                    OFFSET_X + i * TAM_CASILLA + TAM_CASILLA / 2 - 5, OFFSET_Y - 22);
            }

            for (int f = 0; f < 8; f++)
            {
                for (int c = 0; c < 8; c++)
                {
                    int x = OFFSET_X + c * TAM_CASILLA;
                    int y = OFFSET_Y + f * TAM_CASILLA;
                    Rectangle rect = new Rectangle(x, y, TAM_CASILLA, TAM_CASILLA);

                    bool esClaras = (f + c) % 2 == 0;
                    Color colorBase = esClaras
                        ? Color.FromArgb(235, 210, 165)
                        : Color.FromArgb(165, 120, 70);

                    using (SolidBrush br = new SolidBrush(colorBase))
                        g.FillRectangle(br, rect);

                    g.DrawRectangle(Pens.Black, rect);

                    Pieza p = juego.tablero.casillas[f, c];
                    if (p != null)
                    {
                        string sym = GetSimbolo(p);
                        Font fPieza = new Font("Segoe UI Symbol", 28, FontStyle.Bold);
                        Color colorPieza = p.jugador == 1
                            ? Color.FromArgb(255, 255, 255)
                            : Color.FromArgb(20, 20, 20);

                        SizeF sz = g.MeasureString(sym, fPieza);
                        float px = x + (TAM_CASILLA - sz.Width) / 2f;
                        float py = y + (TAM_CASILLA - sz.Height) / 2f;

                        using (SolidBrush shadow = new SolidBrush(Color.FromArgb(80, 0, 0, 0)))
                            g.DrawString(sym, fPieza, shadow, px + 2, py + 2);

                        using (SolidBrush br = new SolidBrush(colorPieza))
                            g.DrawString(sym, fPieza, br, px, py);
                    }
                }
            }

            using (Pen bordeExt = new Pen(Color.FromArgb(220, 180, 90), 3))
                g.DrawRectangle(bordeExt, OFFSET_X - 1, OFFSET_Y - 1,
                    TAM_CASILLA * 8 + 2, TAM_CASILLA * 8 + 2);
        }

        private string GetSimbolo(Pieza p)
        {
            if (p.jugador == 1)
            {
                if (p.tipo == "Rey") return "♔";
                if (p.tipo == "Torre") return "♖";
                return "♙";
            }
            else
            {
                if (p.tipo == "Rey") return "♚";
                if (p.tipo == "Torre") return "♜";
                return "♟";
            }
        }

        private void ActualizarInfo()
        {
            if (juegoTerminado)
            {
                lblTurno.Text = "🏆 Partida\nTerminada";
                return;
            }
            string nombreTurno = juego.turno == 1 ? juego.j1.nombre : juego.j2.nombre;
            string simbolo = juego.turno == 1 ? "♔" : "♚";
            lblTurno.Text = $"Turno:\n{simbolo} {nombreTurno}";
        }

        private void ActualizarPuntajes()
        {
            lblPuntajes.Text =
                $"♔ {juego.j1.nombre}\n  Puntos: {juego.puntosJ1}\n\n" +
                $"♚ {juego.j2.nombre}\n  Puntos: {juego.puntosJ2}";
        }

        private void BtnReiniciar_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "¿Iniciar nueva partida con los mismos jugadores?",
                "Nueva partida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                juego.Iniciar(juego.j1.nombre, juego.j2.nombre);
                juegoTerminado = false;
                txtOrigen.Clear();
                txtDestino.Clear();
                lblMensaje.Text = "";
                ActualizarInfo();
                ActualizarPuntajes();
                panelTablero.Invalidate();
                txtOrigen.Focus();
            }
        }
        private int LetraAColumna(string letra)
        {
            if (string.IsNullOrWhiteSpace(letra)) return -1;
            char c = char.ToUpper(letra.Trim()[0]);
            if (c < 'A' || c > 'H') return -1;
            return c - 'A';
        }
    }
}