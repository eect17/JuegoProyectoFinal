using System;
using System.Drawing;
using System.Windows.Forms;

namespace JuegoProyectoFinal
{
    public class FormJugadores : Form
    {
        private TextBox txtJ1;
        private TextBox txtJ2;
        private Button btnIniciar;
        public string NombreJ1 { get; private set; }
        public string NombreJ2 { get; private set; }

        public FormJugadores()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Registrar Jugadores";
            this.Size = new Size(360, 280);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(30, 30, 40);

            var lblTitulo = new Label();
            lblTitulo.Text = "Registrar Jugadores";
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(220, 180, 90);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(70, 20);

            var lblJ1 = new Label();
            lblJ1.Text = "Jugador 1 (Blancas):";
            lblJ1.ForeColor = Color.White;
            lblJ1.Font = new Font("Segoe UI", 10);
            lblJ1.Location = new Point(40, 75);
            lblJ1.AutoSize = true;

            txtJ1 = new TextBox();
            txtJ1.Location = new Point(40, 98);
            txtJ1.Size = new Size(265, 28);
            txtJ1.Font = new Font("Segoe UI", 11);
            txtJ1.BackColor = Color.FromArgb(50, 50, 65);
            txtJ1.ForeColor = Color.White;
            txtJ1.BorderStyle = BorderStyle.FixedSingle;

            var lblJ2 = new Label();
            lblJ2.Text = "Jugador 2 (Negras):";
            lblJ2.ForeColor = Color.White;
            lblJ2.Font = new Font("Segoe UI", 10);
            lblJ2.Location = new Point(40, 140);
            lblJ2.AutoSize = true;

            txtJ2 = new TextBox();
            txtJ2.Location = new Point(40, 163);
            txtJ2.Size = new Size(265, 28);
            txtJ2.Font = new Font("Segoe UI", 11);
            txtJ2.BackColor = Color.FromArgb(50, 50, 65);
            txtJ2.ForeColor = Color.White;
            txtJ2.BorderStyle = BorderStyle.FixedSingle;

            btnIniciar = new Button();
            btnIniciar.Text = "INICIAR PARTIDA";
            btnIniciar.Location = new Point(40, 205);
            btnIniciar.Size = new Size(265, 38);
            btnIniciar.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnIniciar.BackColor = Color.FromArgb(80, 180, 100);
            btnIniciar.ForeColor = Color.White;
            btnIniciar.FlatStyle = FlatStyle.Flat;
            btnIniciar.FlatAppearance.BorderSize = 0;
            btnIniciar.Cursor = Cursors.Hand;
            btnIniciar.Click += BtnIniciar_Click;

            this.Controls.AddRange(new Control[] {
                lblTitulo, lblJ1, txtJ1, lblJ2, txtJ2, btnIniciar
            });
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJ1.Text) || string.IsNullOrWhiteSpace(txtJ2.Text))
            {
                MessageBox.Show("Ingresa los nombres de ambos jugadores.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NombreJ1 = txtJ1.Text.Trim();
            NombreJ2 = txtJ2.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}