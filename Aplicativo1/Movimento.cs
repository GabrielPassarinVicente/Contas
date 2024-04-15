using Npgsql;
using OfficeOpenXml;
using SharpDX.DXGI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Aplicativo1
{
    public partial class Movimento : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=862945;Database=Logon";

        public Movimento()
        {
            InitializeComponent();

            PreencherListBoxes();
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged; // Subscrever evento SelectedIndexChanged



        }
        private void PreencherListBoxes()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT nome, conta, banco, transação, inicio, valor, agencia  FROM Logon";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                           
                                // Adicione cada coluna às ListBox correspondentes
                                listBox1.Items.Add(reader.GetString(0)); // Nome
                                listBox2.Items.Add(reader.GetString(1)); // Conta
                                listBox3.Items.Add(reader.GetString(2)); // Banco
                                listBox4.Items.Add(reader.GetString(3)); // Transação
                                listBox5.Items.Add(reader.GetString(4));
                                listBox6.Items.Add(reader.GetString(5));
                                listBox7.Items.Add(reader.GetString(6));

                            }
                        }
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }
        }
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;

            // Verifica se algum item está selecionado na listBox1
            if (selectedIndex >= 0)
            {
                // Atualiza as outras listBoxes com base no índice selecionado
                listBox2.SelectedIndex = selectedIndex;
                listBox7.SelectedIndex = selectedIndex;
                listBox3.SelectedIndex = selectedIndex;
                listBox4.SelectedIndex = selectedIndex;
                listBox5.SelectedIndex = selectedIndex;
                listBox6.SelectedIndex = selectedIndex;
              



            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {



        }
        private void ExibirDadosNoDataGridView(int rowIndex)
        {
            // Criar DataTable para armazenar os dados
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nome");
            dataTable.Columns.Add("Conta");
            dataTable.Columns.Add("Banco");
            dataTable.Columns.Add("Transação");
            dataTable.Columns.Add("Data");
            dataTable.Columns.Add("Valor");
            dataTable.Columns.Add("Agência");


            // Adicionar linha com dados selecionados às DataGridView
            dataTable.Rows.Add(listBox1.Items[rowIndex], listBox2.Items[rowIndex], listBox3.Items[rowIndex], listBox4.Items[rowIndex], listBox5.Items[rowIndex], listBox6.Items[rowIndex], listBox7.Items[rowIndex]);

            // Definir a fonte de dados do DataGridView como o DataTable
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;

            // Verifica se algum item está selecionado na listBox1
            if (selectedIndex >= 0)
            {
                // Atualiza as outras listBoxes com base no índice selecionado
                listBox2.SelectedIndex = selectedIndex;
                listBox7.SelectedIndex = selectedIndex;
                listBox3.SelectedIndex = selectedIndex;
                listBox4.SelectedIndex = selectedIndex;
                listBox5.SelectedIndex = selectedIndex;
                listBox6.SelectedIndex = selectedIndex;
                //listBox7.SelectedIndex = selectedIndex;

                
                // Exibir dados no DataGridView
                ExibirDadosNoDataGridView(selectedIndex);
            }
            else
            {
                MessageBox.Show("Selecione um item na cliente para visualizar os dados ");
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExportarParaDocumentoTexto();
        }
        private void ExportarParaDocumentoTexto()
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Documento de Texto|*.txt";
                    saveDialog.Title = "Salvar como documento de texto";
                    saveDialog.FileName = "DadosExportados.txt";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                        {
                            for (int i = 0; i < listBox1.Items.Count; i++)
                            {
                                writer.WriteLine($"Nome: {listBox1.Items[i].ToString()}");
                                writer.WriteLine($"Conta: {listBox2.Items[i].ToString()}");
                                writer.WriteLine($"Banco: {listBox3.Items[i].ToString()}");
                                writer.WriteLine($"Transação: {listBox4.Items[i].ToString()}");
                                writer.WriteLine($"Data: {listBox5.Items[i].ToString()}");
                                writer.WriteLine($"Valor: {listBox6.Items[i].ToString()}");
                                writer.WriteLine($"Agencia: {listBox7.Items[i].ToString()}");

                            }
                        }
                    }
                }

                MessageBox.Show("Dados exportados para documento de texto com sucesso!", "Exportação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exportar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Limpa os itens existentes no ListBox
            listBox1.Items.Clear();

            // Verifica se o TextBox está vazio
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                // Se estiver vazio, exibe todos os itens
                PreencherListBoxes();
            }
            else
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        string sql = "SELECT nome, conta, banco, transação, agencia FROM Logon WHERE nome ILIKE @Nome ";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                        {
                            // Adiciona parâmetros para o filtro
                            cmd.Parameters.AddWithValue("@Nome", "%" + textBox1.Text + "%");

                            using (NpgsqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Adiciona cada coluna às ListBox correspondentes
                                    listBox1.Items.Add(reader.GetString(0)); // Nome

                                }
                            }
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inclui obj = new Inclui();
            obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExcluirItemSelecionado();

        }
        private void ExcluirItemSelecionado()
        {
            int selectedIndex = listBox1.SelectedIndex;

            // Verifica se algum item está selecionado na listBox1
            if (selectedIndex >= 0)
            {
                // Obtém o nome selecionado na ListBox
                string nome = listBox1.Items[selectedIndex].ToString();

                // Realiza a exclusão no banco de dados
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // Define a instrução SQL para excluir a linha com base no nome
                        string sql = "DELETE FROM Logon WHERE nome = @Nome";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                        {
                            // Adiciona parâmetro para o nome
                            cmd.Parameters.AddWithValue("@Nome", nome);

                            // Executa a instrução SQL
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Informação excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                listBox1.Items.Clear();
                                listBox2.Items.Clear();
                                listBox3.Items.Clear();
                                listBox4.Items.Clear();
                                listBox5.Items.Clear();
                                listBox6.Items.Clear();
                                listBox7.Items.Clear();
                                // Atualiza as ListBoxes e o DataGridView após a exclusão
                                PreencherListBoxes();
                                // ExibirDadosNoDataGridView(0); // Exibir os dados do primeiro item após a exclusão
                            }
                            else
                            {
                                MessageBox.Show("Nenhuma informação correspondente foi encontrada para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir informação: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}






