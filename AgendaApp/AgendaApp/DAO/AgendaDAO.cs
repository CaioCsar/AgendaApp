using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace AgendaApp.DAO
{
    class AgendaDAO
    {
        private DAO.Connection db; // instacia da classe de conexao
        private MySqlConnection con; //instancia da biblioteca MySql

        // construtor vazio da classe agendaDAO
        public AgendaDAO()
        {

        }

        // metodo para inserir dados na tabela agenda
        public void InserirDados(String itemid, String nome, String email, String telefone)
        {
            con = new MySqlConnection(); // instancia mysql conexao
            db = new DAO.Connection(); // instancia conexao

            con.ConnectionString = db.getConnectionString(); //chama o caminho da conexao e aponta para o banco em qustao

        }
    }
}
