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
    public partial class Cadastrar : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=862945;Database=Login";

        public Cadastrar()
        {
            InitializeComponent();
        }

        private void Cadastrar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string senha = textBox2.Text;

            // Verifica se tanto o nome de usuário quanto a senha não estão vazios
            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(senha))
            {
                // Verifica se o usuário já existe no banco de dados
                if (!UsuarioExiste(usuario))
                {
                    // Se o usuário não existir, realiza a inserção no banco de dados
                    InserirUsuario(usuario, senha);
                }
                else
                {
                    MessageBox.Show("Usuário já existe. Por favor, escolha outro nome de usuário.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um nome de usuário e uma senha.");
            }
        }
        private bool UsuarioExiste(string usuario)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Consulta SQL para verificar se o usuário já existe no banco de dados
                    string sql = "SELECT COUNT(*) FROM login WHERE usuario = @usuario";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Se count for maior que 0, significa que o usuário já existe
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao verificar usuário: " + ex.Message);
                    return false;
                }
            }
        }
        private void InserirUsuario(string usuario, string senha)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Consulta SQL para inserir o novo usuário no banco de dados
                    string sql = "INSERT INTO login (usuario, senha) VALUES (@usuario, @senha)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@senha", senha);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Usuário cadastrado com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Nenhum usuário cadastrado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
