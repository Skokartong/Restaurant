using Restaurant.Models;

namespace Restaurant.Data.Repos.IRepos
{
    public interface ITableRepository
    {
        Task AddTableAsync(Table table);
        Task DeleteTableAsync(int tableId);
        Task UpdateTableAsync(int tableId, Table updatedTable);
        Task<IEnumerable<Table>> GetAvailableTablesAsync(int restaurantId, DateTime startTime, DateTime endTime, int numberOfGuests);
    }
}
