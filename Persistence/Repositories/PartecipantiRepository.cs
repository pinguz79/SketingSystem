using DataModel.Entities;

namespace Persistence.Repositories
{
    public class PartecipantiRepository : BaseRepository<Partecipante>
    {
        public PartecipantiRepository(DataModelContext context) : base(context)
        {
        }
    }
}