using DataModel.Entities;
using Persistence.Repositories;

namespace Persistence
{
    internal class DisciplineRepository(DataModelContext context) : BaseRepository<Disciplina>(context)
    {
    }
}