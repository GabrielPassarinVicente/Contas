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
    public partial class Utilitario : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=862945;Database=contas";

        public Utilitario()
        {
            InitializeComponent();
            this.Load += Utilitario_Load;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cliente = textBox1.Text;
            DateTime dataCompra = dateTimePicker1.Value;
            string parcelas = textBox3.Text;
            string restante = textBox4.Text;
            DateTime dataVencimento = dateTimePicker1.Value;
            string produto = textBox2.Text;
            //string restanteAposVencimento = label1;

            InserirCliente(cliente, dataCompra, parcelas, restante, dataVencimento, produto);

            // Atualiza a DataGridView
            AtualizarDataGridView();
        }
        private void InserirCliente(string cliente, DateTime dataCompra, string parcelas, string restante, DateTime dataVencimento, string produto)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "INSERT INTO contas (cliente, dataCompra, parcelas, restante, dataVencimento, produto) " +
                             "VALUES (@cliente, @dataCompra, @parcelas, @restante, @dataVencimento, @produto)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@cliente", cliente);
                    cmd.Parameters.AddWithValue("@dataCompra", dataCompra);
                    cmd.Parameters.AddWithValue("@parcelas", parcelas);
                    cmd.Parameters.AddWithValue("@restante", restante);
                    cmd.Parameters.AddWithValue("@dataVencimento", dataVencimento);
                    cmd.Parameters.AddWithValue("@produto", produto);
                    // cmd.Parameters.AddWithValue("@restanteAposVencimento", restanteAposVencimento);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void AtualizarDataGridView()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM contas";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void Utilitario_Load(object sender, EventArgs e)
        {
            //VerificarComprasAVencer();

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        public void VerificarComprasAVencer(DataGridView dataGridView1)
        {
            // Consulta para recuperar as compras que estão prestes a vencer neste mês
            string sql = "SELECT cliente, dataCompra, dataVencimento, produto " +
                         "FROM contas " +
                         "WHERE EXTRACT(MONTH FROM dataVencimento) = EXTRACT(MONTH FROM CURRENT_DATE) " +
                         "AND EXTRACT(YEAR FROM dataVencimento) = EXTRACT(YEAR FROM CURRENT_DATE)";

            // Crie um DataTable para armazenar os resultados
            DataTable dt = new DataTable();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    // Use um DataAdapter para preencher o DataTable
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            // Associe o DataTable à DataSource da DataGridView
            dataGridView1.DataSource = dt;

            // Defina os títulos das colunas
            dataGridView1.Columns["cliente"].HeaderText = "Cliente";
            dataGridView1.Columns["dataCompra"].HeaderText = "Data da Compra";

            dataGridView1.Columns["dataVencimento"].HeaderText = "Data de Vencimento";
            dataGridView1.Columns["produto"].HeaderText = "Produto";
            dataGridView1.ColumnHeadersVisible = true;
            // Defina o título da DataGridView


        }
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Contas objConta = new Contas();
            objConta.Show();
        }
    }
}

