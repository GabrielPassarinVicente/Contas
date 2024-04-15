using iTextSharp.text;
using iTextSharp.text.pdf;
using Npgsql;
using System.Data;
using System.Globalization;
using System.Reflection.Metadata;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;


namespace Aplicativo1
{
    public partial class Relatório : Form
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=862945;Database=Logon";
        public Relatório()
        {
            InitializeComponent();
        }

        private void Relatório_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Digite a informação no campo de texto!");
            }
            else
            {
                string nome = textBox1.Text;
                BuscarNoBanco(nome);
            }

        }
        private void BuscarNoBanco(string nome)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Define a instrução SQL para buscar informações com base no nome
                    string sql = "SELECT nome, conta, banco, transação, inicio, valor FROM Logon WHERE nome ILIKE @Nome";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        // Adiciona parâmetro para o nome
                        cmd.Parameters.AddWithValue("@Nome", "%" + nome + "%");

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);

                            // Adiciona uma coluna para representar os números das linhas
                            DataColumn numeroColuna = new DataColumn("#", typeof(int));
                            dataTable.Columns.Add(numeroColuna);

                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                dataTable.Rows[i]["#"] = i + 1;
                            }

                            // Define a fonte de dados da DataGridView como o DataTable
                            dataGridView1.DataSource = dataTable;

                            // Oculta a coluna '#'
                            dataGridView1.Columns["#"].Visible = false;

                            // Calcular o gasto mensal
                            Dictionary<int, decimal> gastosMensais = new Dictionary<int, decimal>();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                DateTime data = Convert.ToDateTime(row["inicio"]);
                                decimal valor = Convert.ToDecimal(row["valor"]);
                                int mes = data.Month;

                                if (gastosMensais.ContainsKey(mes))
                                    gastosMensais[mes] += valor;
                                else
                                    gastosMensais[mes] = valor;
                            }

                            // Exibir os gastos mensais no gráfico
                            if (gastosMensais.Count > 0)
                            {
                                chart1.Series.Clear();
                                Series series = chart1.Series.Add("Gastos Mensais");
                                series.ChartType = SeriesChartType.Column;
                                series.IsValueShownAsLabel = true;

                                foreach (KeyValuePair<int, decimal> gasto in gastosMensais)
                                {
                                    string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(gasto.Key);
                                    DataPoint point = new DataPoint();
                                    point.SetValueXY(monthName, gasto.Value);
                                    point.Label = gasto.Value.ToString(); // Define o valor como label
                                    series.Points.Add(point);
                                }

                                // Adicionar título ao eixo Y
                                chart1.ChartAreas[0].AxisY.Title = "Valor (em Reais)";

                                chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
                            }
                            else
                            {
                                chart1.Series.Clear();
                                chart1.Titles.Clear();
                                chart1.Titles.Add("Nenhum dado disponível");
                            }
                        }
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(textBox1.Text))
            //{
            //    MessageBox.Show("Por favor, insira um nome antes de exportar para PDF.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            //{
            //    saveFileDialog.Filter = "Arquivos PDF (*.pdf)|*.pdf";
            //    saveFileDialog.Title = "Salvar como PDF";
            //    saveFileDialog.FileName = "Relatorio.pdf";

            //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        try
            //        {
            //            using (iTextSharp.text.Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate()))
            //            using (PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create)))
            //            {
            //                doc.Open();

            //                Paragraph title = new Paragraph("Relatório de Dados", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20));
            //                title.Alignment = Element.ALIGN_CENTER;
            //                doc.Add(title);

            //                PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
            //                table.WidthPercentage = 100;

            //                foreach (DataGridViewColumn column in dataGridView1.Columns)
            //                {
            //                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD)));
            //                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            //                    table.AddCell(cell);
            //                }

            //                foreach (DataGridViewRow row in dataGridView1.Rows)
            //                {
            //                    foreach (DataGridViewCell cell in row.Cells)
            //                    {
            //                        if (cell.Value != null)
            //                        {
            //                            table.AddCell(new Phrase(cell.Value.ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)));
            //                        }
            //                    }
            //                }

            //                doc.Add(table);
            //                doc.Close();

            //                MessageBox.Show("Dados exportados para PDF com sucesso!", "Exportação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Erro ao exportar dados para PDF: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
  