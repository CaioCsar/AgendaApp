using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace AgendaApp.DAO
{
    class Connection
    {

        private String connectionString; //conexao com o banco

        public String getConnectionString()// chama a conexao com o banco de dados
        {
            connectionString = ConfigurationManager.ConnectionStrings["AgendaApp.Propeties.Settings.configAgendaCRUD"].ConnectionString;
            return connectionString;
        }
    }
}
