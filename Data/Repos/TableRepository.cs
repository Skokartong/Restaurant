using Restaurant.Data.Repos.IRepos;
using Restaurant.Models;

namespace Restaurant.Data.Repos
{
    public class TableRepository:ITableRepository
    {
        private readonly RestaurantContext _context;

        public TableRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task AddTableAsync(Table table)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTableAsync(int tableId)
        {
            throw new NotImplementedException();
        }

        public async Task<Table> UpdateTableAsync(int tableId, Table updatedTable)
        {
            throw new NotImplementedException();
        }
    }
}
