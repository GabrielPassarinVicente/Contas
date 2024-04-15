using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicativo1
{
    public partial class Login : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=862945;Database=Login";

        public Login()
        {
            InitializeComponent();
            this.KeyPreview = true;

            // Adiciona um manipulador de eventos para o evento KeyDown do formulário
            this.KeyDown += Login_KeyDown;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string senha = textBox2.Text;

            if (ValidarLogin(usuario, senha))
            {
                // Se o login for válido, abrir o próximo formulário
                Form1 obj = new Form1();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos");
            }



        }
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Chama o método associado ao clique do botão "Entrar"
                button1_Click(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0'; // Exibir a senha sem asteriscos
            }
            else
            {
                textBox2.PasswordChar = '*'; // Ocultar a senha com asteriscos
            }


        }
        private bool ValidarLogin(string usuario, string senha)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta SQL para verificar se o usuário e senha existem no banco de dados
                    string sql = "SELECT COUNT(*) FROM login WHERE usuario = @usuario AND senha = @senha";
                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@usuario", usuario);
                        command.Parameters.AddWithValue("@senha", senha);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        // Se houver algum registro correspondente, o login é válido
                        if (count > 0)
                            return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RedefinirSenha obj = new RedefinirSenha();
            obj.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Cadastrar tela = new Cadastrar();
            tela.Show();
        }
    }
}
