using DataModel.Entities;
using Persistence;

namespace BusinessLogic
{
    public class DataService : IDataService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DataService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        #region ADD
        public Disciplina AddDisciplina(string nomeDisciplina) => _unitOfWork.AddDisciplina(nomeDisciplina);
        public Categoria AddCategoria(string nomeCategoria) => _unitOfWork.AddCategoria(nomeCategoria);
        public Giudice AddGiudice(string nomeGiudice) => _unitOfWork.AddGiudice(nomeGiudice);
        public Partecipante AddPartecipante(Partecipante nuovoPartecipante) => _unitOfWork.AddPartecipante(nuovoPartecipante);
        public Gara AddGara(Disciplina disciplina, Categoria categoria) => _unitOfWork.AddGara(disciplina, categoria);
        #endregion

        #region DELETE
        public void DeleteDisciplina(Disciplina disciplina) => _unitOfWork.DeleteDisciplina(disciplina);
        public void DeleteCategoria(Categoria categoria) => _unitOfWork.DeleteCategoria(categoria);
        public void DeleteGiudice(Giudice giudice) => _unitOfWork.DeleteGiudice(giudice);
        public void DeletePartecipante(Guid id) => _unitOfWork.DeletePartecipante(id);
        #endregion

        #region GET
        public List<Disciplina> GetDiscipline() => _unitOfWork.GetDiscipline();
        public List<Categoria> GetCategorie() => _unitOfWork.GetCategorie();
        public List<Giudice> GetGiudici() => _unitOfWork.GetGiudici();
        public List<Partecipante> GetPartecipanti() => _unitOfWork.GetPartecipanti();
        public List<Gara> GetGare() => _unitOfWork.GetGare();
        public Gara GetGara(Disciplina disciplina, Categoria categoria) => _unitOfWork.GetGara(disciplina, categoria);
        #endregion

        #region GET BY ID
        public Partecipante GetPartecipanteById(Guid id) => _unitOfWork.GetPartecipanteById(id);
        #endregion

        public void SaveChanges() => _unitOfWork.SaveChanges();
    }
}
