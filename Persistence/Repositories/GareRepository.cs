using DataModel.Entities;

namespace Persistence.Repositories
{
    internal class GareRepository(DataModelContext context) : BaseRepository<Gara>(context)
    {
    }
}