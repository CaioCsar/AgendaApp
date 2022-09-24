using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp.Modelo
{
    class Agenda
    {
        // atributos da tabela
        private Int32 _ageId, _ageTelefone;
        private String _ageNome, _ageEMail;

        //atributo para instancia da classe agendaDAO
        private DAO.AgendaDAO cdao;

        //construtor
        public Agenda()
        {
        }

        //get e set

        public Int32 ageId
        {
            get { return _ageId; }
            set { _ageId = value; }
        }

        public Int32 ageTelefone
        {
            get { return _ageTelefone; }
            set { _ageTelefone = value; }
        }

        public String ageNome
        {
            get { return _ageNome; }
            set { _ageNome = value; }
        }

        public String ageEMail
        {
            get { return _ageEMail; }
            set { _ageEMail = value; }
        }

        //inserir registro na tabela DAO
        public void Inserir()
        {
            cdao = new DAO.AgendaDAO();
            cdao.InserirDados(ageNome, ageEMail, ageTelefone);
        }

        //att registro da tabela
        public void Atualizar()
        {
            cdao = new DAO.AgendaDAO();
            cdao.AtualizarDados(ageId, ageNome, ageEMail, ageTelefone);
        }

        //deletar registro
        public void Remover()
        {
            cdao = new DAO.AgendaDAO();
            cdao.RemoverDados(ageId);
        }
    }
}
