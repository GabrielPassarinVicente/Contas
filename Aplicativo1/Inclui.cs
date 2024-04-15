using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicativo1
{
    public partial class Inclui : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=862945;Database=Logon";

        public Inclui()
        {
            InitializeComponent();
            textBox5.TextChanged += textBox5_TextChanged;
            textBox6.TextChanged += textBox6_TextChanged;
            textBox2.TextChanged += textBox2_TextChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = "INSERT INTO Logon (nome, conta, banco, inicio, transação, valor, agencia) " +
                                 "VALUES (@nome, @conta, @banco, @inicio, @transação, @valor, @agencia)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {


                        cmd.Parameters.AddWithValue("@conta", string.IsNullOrEmpty(textBox2.Text) ? "vazio" : textBox2.Text);
                        cmd.Parameters.AddWithValue("@nome", string.IsNullOrEmpty(textBox1.Text) ? "vazio" : textBox1.Text);
                        cmd.Parameters.AddWithValue("@banco", string.IsNullOrEmpty(textBox3.Text) ? "vazio" : textBox3.Text);
                        cmd.Parameters.AddWithValue("@transação", string.IsNullOrEmpty(textBox4.Text) ? "vazio" : textBox4.Text);
                        cmd.Parameters.AddWithValue("@inicio", string.IsNullOrEmpty(textBox5.Text) ? "vazio" : textBox5.Text);
                        cmd.Parameters.AddWithValue("@valor", string.IsNullOrEmpty(textBox6.Text) ? "vazio" : textBox6.Text);
                        cmd.Parameters.AddWithValue("@agencia", string.IsNullOrEmpty(textBox7.Text) ? "vazio" : textBox7.Text);



                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dados inseridos com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Nenhum dado inserido.");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao inserir dados");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


            textBox2.MaxLength = 6;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 2 || textBox5.Text.Length == 5)
            {
                textBox5.Text += "/";
                textBox5.SelectionStart = textBox5.Text.Length;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = new string(textBox6.Text.Where(c => char.IsDigit(c) || c == ',' || c == '.').ToArray());

            // Formata para exibir duas casas decimais
            if (!string.IsNullOrEmpty(textBox6.Text) && !textBox6.Text.Contains(".") && !textBox6.Text.Contains(","))
            {
                textBox6.Text = $"{decimal.Parse(textBox6.Text):N2}";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void Inclui_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
