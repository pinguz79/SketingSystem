using DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        #region ADD
        Disciplina AddDisciplina(string nomeDisciplina);
        Categoria AddCategoria(string nomeCategoria);
        Giudice AddGiudice(string nomeGiudice);
        Partecipante AddPartecipante(Partecipante nuovoPartecipante);
        Gara AddGara(Disciplina disciplina, Categoria categoria);
        #endregion
        
        #region GET
        List<Categoria> GetCategorie();
        List<Disciplina> GetDiscipline();
        List<Giudice> GetGiudici();
        List<Partecipante> GetPartecipanti();
        List<Gara> GetGare();
        Gara GetGara(Disciplina disciplina, Categoria categoria);
        #endregion

        #region GET BY ID
        Partecipante GetPartecipanteById(Guid id);
        #endregion

        #region DELETE
        void DeleteDisciplina(Disciplina disciplina);
        void DeleteCategoria(Categoria categoria);
        void DeleteGiudice(Giudice giudice);
        void DeletePartecipante(Guid id);
        #endregion

        void SaveChanges();
    }
}
