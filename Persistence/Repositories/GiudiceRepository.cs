using DataModel.Entities;
using Persistence.Repositories;

namespace Persistence
{
    internal class GiudiceRepository(DataModelContext context) : BaseRepository<Giudice>(context)
    {
    }
}