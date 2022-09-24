using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

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
        public void InserirDados(String ageNome, String ageEMail, Int32 ageTelefone)
        {
            con = new MySqlConnection(); // instancia mysql conexao
            db = new DAO.Connection(); // instancia conexao
            con.ConnectionString = db.getConnectionString(); //chama o caminho da conexao e aponta para o banco em qustao
            String query = "INSER INTO Agenda(ageNome, ageEMail, ageTelefone) VALUES";
            query += "(?ageNome, ?ageEMail, ?ageTelefone)";//query sql para ser enviada ao bd

            try 
            {
                con.Open(); // abre a conexao com o banco
                MySqlCommand cmd = new MySqlCommand(query, con);// faz uma instancia passando o sql e o caminho do bd
                // add atributos
                cmd.Parameters.AddWithValue("?ageNome", ageNome);
                cmd.Parameters.AddWithValue("?ageEMail",ageEMail);
                cmd.Parameters.AddWithValue("?ageTelefone", ageTelefone);
                cmd.ExecuteNonQuery();
                cmd.Dispose(); //abre o acesso ao vinculo da app com algo externo, no caso, o bd
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um Erro: \n" + ex.ToString());
            }
            finally 
            {
                con.Close(); // fecha a conexao com o banco
            }
        }

        //metodo de att dados da tabela
        public void AtualizarDados(Int32 ageId, String ageNome, String ageEMail, Int32 ageTelefone)
        {
            con = new MySqlConnection(); // instancia mysql conexao
            db = new DAO.Connection(); // instancia conexao
            con.ConnectionString = db.getConnectionString(); //chama o caminho da conexao e aponta para o banco em qustao
            String query = "UPDATE Agenda SET ageId = ?ageId, ageEMail = ?ageEMail, ageNome = ?ageNome, ageTelefone = ?ageTelefone";
            query += "WHERE ageId = ?ageId";

            try
            {
                con.Open(); // abre a conexao com o banco
                MySqlCommand cmd = new MySqlCommand(query, con);// faz uma instancia passando o sql e o caminho do bd
                cmd.Parameters.AddWithValue("?ageId", ageId);// add atributos
                cmd.Parameters.AddWithValue("?ageNome", ageNome);
                cmd.Parameters.AddWithValue("?ageEMail", ageEMail);
                cmd.Parameters.AddWithValue("?ageTelefone", ageTelefone);
                cmd.ExecuteNonQuery();
                cmd.Dispose(); //abre o acesso ao vinculo da app com algo externo, no caso, o bd
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um Erro: \n" + ex.ToString());
            }
            finally
            {
                con.Close(); // fecha a conexao com o banco
            }
        }

        //metodo de excluir dados da tabela
        public void RemoverDados(Int32 ageId)
        {
            con = new MySqlConnection(); // instancia mysql conexao
            db = new DAO.Connection(); // instancia conexao
            con.ConnectionString = db.getConnectionString(); //chama o caminho da conexao e aponta para o banco em qustao
            String query = "DELETE FROM Agenda";
            query += "WHERE ageId = ?ageId";//query sql para ser enviada ao bd

            try
            {
                con.Open(); // abre a conexao com o banco
                MySqlCommand cmd = new MySqlCommand(query, con);// faz uma instancia passando o sql e o caminho do bd
                cmd.Parameters.AddWithValue("?ageId", ageId);// add atributos
                cmd.ExecuteNonQuery();
                cmd.Dispose(); //abre o acesso ao vinculo da app com algo externo, no caso, o bd
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um Erro: \n" + ex.ToString());
            }
            finally
            {
                con.Close(); // fecha a conexao com o banco
            }
        }

    }
}
