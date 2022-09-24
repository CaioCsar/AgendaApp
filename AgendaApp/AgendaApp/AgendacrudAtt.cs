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

        private void AgendacrudAtt_Load(object sender, EventArgs e)
        {

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
            //USING ***

        }
    }
}
