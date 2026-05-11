using System;
using System.Drawing;
using System.Windows.Forms;

namespace JuegoProyectoFinal
{
    public class FormLogin : Form
    {
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Button btnEntrar;
        private Label lblError;

        private const string USUARIO_CORRECTO = "admin";
        private const string PASSWORD_CORRECTA = "123456789";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Juego de Tablero — Login";
            this.Size = new Size(380, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(30, 30, 40);

            var lblTitulo = new Label();
            lblTitulo.Text = "♟ JUEGO DE TABLERO";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(220, 180, 90);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(60, 25);

            var lblUsuario = new Label();
            lblUsuario.Text = "Usuario:";
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Font = new Font("Segoe UI", 10);
            lblUsuario.Location = new Point(50, 90);
            lblUsuario.AutoSize = true;

            txtUsuario = new TextBox();
            txtUsuario.Location = new Point(50, 115);
            txtUsuario.Size = new Size(270, 28);
            txtUsuario.Font = new Font("Segoe UI", 11);
            txtUsuario.BackColor = Color.FromArgb(50, 50, 65);
            txtUsuario.ForeColor = Color.White;
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;

            var lblContrasena = new Label();
            lblContrasena.Text = "Contraseña:";
            lblContrasena.ForeColor = Color.White;
            lblContrasena.Font = new Font("Segoe UI", 10);
            lblContrasena.Location = new Point(50, 155);
            lblContrasena.AutoSize = true;

            txtContrasena = new TextBox();
            txtContrasena.Location = new Point(50, 180);
            txtContrasena.Size = new Size(270, 28);
            txtContrasena.Font = new Font("Segoe UI", 11);
            txtContrasena.PasswordChar = '●';
            txtContrasena.BackColor = Color.FromArgb(50, 50, 65);
            txtContrasena.ForeColor = Color.White;
            txtContrasena.BorderStyle = BorderStyle.FixedSingle;
            txtContrasena.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnEntrar_Click(s, e); };

            lblError = new Label();
            lblError.Text = "";
            lblError.ForeColor = Color.FromArgb(220, 80, 80);
            lblError.Font = new Font("Segoe UI", 9);
            lblError.Location = new Point(50, 215);
            lblError.AutoSize = true;

            btnEntrar = new Button();
            btnEntrar.Text = "ENTRAR";
            btnEntrar.Location = new Point(50, 238);
            btnEntrar.Size = new Size(270, 38);
            btnEntrar.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnEntrar.BackColor = Color.FromArgb(220, 180, 90);
            btnEntrar.ForeColor = Color.FromArgb(30, 30, 40);
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.FlatAppearance.BorderSize = 0;
            btnEntrar.Cursor = Cursors.Hand;
            btnEntrar.Click += btnEntrar_Click;

            var lblHint = new Label();
            lblHint.Text = "Usuario: admin  |  Contraseña: Admin@1234";
            lblHint.Font = new Font("Segoe UI", 8, FontStyle.Italic);
            lblHint.ForeColor = Color.FromArgb(100, 100, 130);
            lblHint.Location = new Point(50, 290);
            lblHint.AutoSize = true;

            this.Controls.AddRange(new Control[] {
                lblTitulo, lblUsuario, txtUsuario,
                lblContrasena, txtContrasena,
                lblError, btnEntrar, lblHint
            });
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == USUARIO_CORRECTO && txtContrasena.Text == PASSWORD_CORRECTA)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
                txtContrasena.Clear();
                txtContrasena.Focus();
            }
        }
    }
}