using DataModel.Entities;
using Persistence.Repositories;
using System.Reflection;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataModelContext _context;
        private DisciplineRepository _disciplinaRepository;
        private CategorieRepository _categoriaRepository;
        private GiudiceRepository _giudiceRepository;
        private PartecipantiRepository _partecipantiRepository;
        private GareRepository _gareRepository;
        public UnitOfWork(DataModelContext context)
        {
            _context = context;

            var type = GetType();

            var repos = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var fieldTypes = repos.Where(f => f.FieldType.BaseType.IsGenericType);
            foreach (var fieldType in fieldTypes)
            {
                ConstructorInfo ctor = fieldType.FieldType.GetConstructor(new Type[] { typeof(DataModelContext) });
                var repo = ctor.Invoke(new object[] { context });
                fieldType.SetValue(this, repo);
            }
        }

        public void Dispose() => _context.Dispose();

        #region ADD
        public Disciplina AddDisciplina(string nomeDisciplina) => _disciplinaRepository.Add(new Disciplina { Nome = nomeDisciplina });
        public Categoria AddCategoria(string nomeCategoria) => _categoriaRepository.Add(new Categoria { Nome = nomeCategoria });
        public Giudice AddGiudice(string nomeGiudice) => _giudiceRepository.Add(new Giudice { Nome = nomeGiudice });
        public Partecipante AddPartecipante(Partecipante nuovoPartecipante) => _partecipantiRepository.Add(nuovoPartecipante);
        public Gara AddGara(Disciplina disciplina, Categoria categoria) => _gareRepository.Add(new Gara { Disciplina = disciplina, Categoria = categoria });
        #endregion

        #region GET
        public List<Disciplina> GetDiscipline() => _disciplinaRepository.GetAll().ToList();
        public List<Categoria> GetCategorie() => _categoriaRepository.GetAll().ToList();
        public List<Giudice> GetGiudici() => _giudiceRepository.GetAll().ToList();
        public List<Partecipante> GetPartecipanti() => _partecipantiRepository.GetAll().ToList();
        public List<Gara> GetGare() => _gareRepository.GetAll().ToList();
        public Gara GetGara(Disciplina disciplina, Categoria categoria) => _gareRepository.Where(g => g.DisciplinaId == disciplina.Id && g.CategoriaId == categoria.Id).FirstOrDefault();
        #endregion

        #region GET BY ID
        public Partecipante GetPartecipanteById(Guid id) => _partecipantiRepository.GetById(id);
        #endregion

        #region DELETE
        public void DeleteDisciplina(Disciplina disciplina) => _disciplinaRepository.Delete(disciplina.Id);
        public void DeleteCategoria(Categoria categoria) => _categoriaRepository.Delete(categoria.Id);
        public void DeleteGiudice(Giudice giudice) => _giudiceRepository.Delete(giudice.Id);
        public void DeletePartecipante(Guid id) => _partecipantiRepository.Delete(id);
        #endregion

        public void SaveChanges() => _context.SaveChanges();
    }
}
