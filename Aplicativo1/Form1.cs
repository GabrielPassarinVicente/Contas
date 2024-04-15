using Npgsql;

namespace Aplicativo1
{
    public partial class Form1 : Form
    {
        Utilitario utilitarios = new Utilitario();
        private string connectionString = "Host=localhost;Username=postgres;Password=862945;Database=Login";

        public Form1()
        {
            InitializeComponent();


        }


        private void btnInicio_Click(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Movimento tela1 = new Movimento();
            tela1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Relat�rio obj = new Relat�rio();
            obj.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string usuario = Microsoft.VisualBasic.Interaction.InputBox("Digite o usu�rio:", "Usu�rio", "");
            string senhaDigitada = Microsoft.VisualBasic.Interaction.InputBox("Digite a senha:", "Reservado", "");

            // Verificar se o usu�rio e a senha est�o corretos
            if (VerificarCredenciais(senhaDigitada))
            {
                MessageBox.Show("Credenciais corretas. Acesso permitido.");
                Utilitario tela = new Utilitario();
                tela.Show();

                // Se as credenciais estiverem corretas, permitir acesso
                
                // Adicione aqui o c�digo para o acesso reservado
            }
            else
            {
                // Se as credenciais estiverem incorretas, mostrar mensagem de erro
                MessageBox.Show("Credenciais incorretas. Acesso negado.");
            }
            

        }
        private bool VerificarCredenciais( string senha)
        {
            // Estabelecer conex�o com o banco de dados e executar a consulta SQL
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Consulta SQL para buscar o usu�rio e a senha correspondentes
                string sql = "SELECT senha FROM Login WHERE senha = @senha";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@senha", senha);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Comparar a senha do banco de dados com a senha digitada
                            string senhaDoBanco = reader.GetString(0);
                            return senhaDoBanco == senha;
                        }
                        else
                        {
                            // Usu�rio n�o encontrado
                            return false;
                        }
                    }
                }
            }
        }

            private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    
