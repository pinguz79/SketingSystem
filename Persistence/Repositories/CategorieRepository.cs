using DataModel.Entities;
using Persistence.Repositories;

namespace Persistence
{
    internal class CategorieRepository(DataModelContext context) : BaseRepository<Categoria>(context)
    {
    }
}