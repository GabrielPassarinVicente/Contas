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
    public partial class RedefinirSenha : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=862945;Database=Login";

        public RedefinirSenha()
        {
            InitializeComponent();
            this.KeyPreview = true;

            // Adiciona um manipulador de eventos para o evento KeyDown do formulário
            this.KeyDown += Login_KeyDown;
        }
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Chama o método associado ao clique do botão "Entrar"
                button1_Click(sender, e);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
            {

                string novaSenha = textBox2.Text;

                // Obtém o nome de usuário do campo de texto textBox1
                string nomeUsuario = textBox3.Text;

                // Verifica se o nome de usuário e a nova senha não estão vazios
                if (!string.IsNullOrEmpty(novaSenha) && !string.IsNullOrEmpty(nomeUsuario))
                {
                    AtualizarSenha(nomeUsuario, novaSenha);
                }
                else
                {
                    MessageBox.Show("Por favor, insira um nome de usuário e uma nova senha.");
                }


            }


        }
        private void AtualizarSenha(string nomeUsuario, string novaSenha)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Consulta SQL para atualizar a senha com base no nome de usuário
                    string sql = "UPDATE login SET senha = @novaSenha WHERE usuario = @nomeUsuario";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@novaSenha", novaSenha);
                        cmd.Parameters.AddWithValue("@nomeUsuario", nomeUsuario);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Senha atualizada com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Nenhum usuário encontrado com esse nome.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar a senha: " + ex.Message);
                }

            }
        }

        private void RedefinirSenha_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
