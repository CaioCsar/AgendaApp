using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AgendaApp
{
    public partial class AgendacrudAtt : Form
    {

        private DAO.Connection db; //instance connection class
        private Modelo.Agenda cruds; //instance agenda
        private Int32 catchRowIndex; //pega o id da linha do form

        public AgendacrudAtt()
        {
            InitializeComponent();
        }

        //quando o form for carregado, chamar o carregaDados()
        private void AgendacrudAtt_Load(object sender, EventArgs e)
        {
            carregaDados();
        }

        // pesquisa na tabela agenda e retorna os componentes da mesma
        private void carregaDados()
        {
            db = new DAO.Connection();
            dataGridView1.DataSource = null; // cria uma grid vazia de dados
            dataGridView1.Rows.Clear(); //limpa as linhas
            dataGridView1.Refresh(); // att a lista da grid

            string connectionString = db.getConnectionString(); //instancia o caminho com o banco
            string query = "SELECT * FROM Agenda"; //pesquisa a tabela toda

            using (MySqlConnection conn = new MySqlConnection(connectionString))  // instancia de dados no adapter
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))// faz a instancia de dados no adapter{
                    try
                    {
                        //Cria tabela
                        DataTable dataTable = new DataTable();
                        //relacionamento da tabela com a pesquisa
                        adapter.Fill(dataTable);
                        //preenchimento da tabela com os dados da pesquisa
                        for (int i =0; i<dataTable.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(
                                dataTable.Rows[i][0],
                                dataTable.Rows[i][1], 
                                dataTable.Rows[i][2],
                                dataTable.Rows[i][3]); //CONVERTER???
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }
            }

           
           

        }
         //metodo add no botao
        private void btnadicionar_Click(object sender, EventArgs e)
        {
            try
            {
                cruds = new Modelo.Agenda(); // instancia da classe agenda
                cruds.ageId = Convert.ToInt32(txtid.Text);
                cruds.ageNome = txtnome.Text;
                cruds.ageEMail = txtemail.Text;
                cruds.ageTelefone = Convert.ToInt32(txttel.Text);
                cruds.Inserir(); // insercao dos obj na tabela
                dataGridView1.Rows.Add(null, txtnome.Text, txtemail.Text, txttel.Text); // att o datagridview
                txtnome.Clear();
                txtemail.Clear();
                txttel.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao realizar a operação", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {
                
                cruds.ageId = Convert.ToInt32(txtid.Text);
                cruds.ageNome = txtnome.Text;
                cruds.ageEMail = txtemail.Text;
                cruds.ageTelefone = Convert.ToInt32(txttel.Text);
                cruds.Atualizar();
                dataGridView1[0, catchRowIndex].Value = txtid.Text;
                dataGridView1[1, catchRowIndex].Value = txtnome.Text;
                dataGridView1[2, catchRowIndex].Value = txtemail.Text;
                dataGridView1[3, catchRowIndex].Value = txttel.Text;
                btneditar.Enabled = false;
                btnexcluir.Enabled = false;
                txtnome.Clear();
                txtemail.Clear();
                txttel.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao realizar a operação", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            catchRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            foreach (DataGridView row in dataGridView1.SelectedRows)
            {
                txtid.Text = row.SelectedCells[0].Value.ToString(); // envia dados da linha para o txt
                txtnome.Text = row.SelectedCells[1].Value.ToString();
                txtemail.Text = row.SelectedCells[2].Value.ToString();
                txttel.Text = row.SelectedCells[3].Value.ToString();
            }
            btneditar.Enabled = true;
            btnexcluir.Enabled = true;
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        // evento para trata exibicao de botos quando há campos vazios
        private void txtnome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttel_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnlimpar_Click(object sender, EventArgs e)
        {
            txtid.Clear();
            txtnome.Clear();
            txttel.Clear();
            txtemail.Clear();
        }
    }
}
