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
    public partial class Contas : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=862945;Database=contas";

        public Contas()
        {
            InitializeComponent();
            this.Load += Contas_Load;


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void CarregarContasAVencer()
        {
            dataGridView1.Columns.Add("Cliente", "Cliente");
            dataGridView1.Columns.Add("DataCompra", "Data da Compra");
            dataGridView1.Columns.Add("DataVencimento", "Data de Vencimento");
            dataGridView1.Columns.Add("Produto", "Produto");

            // Adiciona colunas para os botões "Pagar" e "Não Pagar"
            DataGridViewButtonColumn pagarButtonColumn = new DataGridViewButtonColumn();
            pagarButtonColumn.HeaderText = "Pagar";
            pagarButtonColumn.Text = "Pagar";
            pagarButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(pagarButtonColumn);

            DataGridViewButtonColumn naoPagarButtonColumn = new DataGridViewButtonColumn();
            naoPagarButtonColumn.HeaderText = "Não Pagar";
            naoPagarButtonColumn.Text = "Não Pagar";
            naoPagarButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(naoPagarButtonColumn);

            // Consulta para recuperar as compras que estão prestes a vencer neste mês
            string sql = "SELECT cliente, dataCompra, dataVencimento, produto " +
                         "FROM contas " +
                         "WHERE EXTRACT(MONTH FROM dataVencimento) = EXTRACT(MONTH FROM CURRENT_DATE) " +
                         "AND EXTRACT(YEAR FROM dataVencimento) = EXTRACT(YEAR FROM CURRENT_DATE)";

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Adiciona os dados na DataGridView
                            dataGridView1.Rows.Add(reader["cliente"].ToString(),
                                                     reader["dataCompra"].ToString(),
                                                     reader["dataVencimento"].ToString(),
                                                     reader["produto"].ToString());
                            //reader["valor"].ToString());
                        }
                    }
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 4) // Verifica se o clique foi em uma célula de botão
            {
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (buttonCell.Value.ToString() == "Pagar")
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                }
                else if (buttonCell.Value.ToString() == "Não Pagar")
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }



        private void buttonPagar_Click(object sender, EventArgs e)
        {

        }

        private void buttonNaoPagar_Click(object sender, EventArgs e)
        {

        }

        private void Contas_Load(object sender, EventArgs e)
        {
            CarregarContasAVencer();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
    }
}