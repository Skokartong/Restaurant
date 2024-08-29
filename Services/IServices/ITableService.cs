using Restaurant.Models.DTOs;

namespace Restaurant.Services.IServices
{
    public interface ITableService
    {
        Task AddTableAsync(TableDTO tableDTO);
        Task UpdateTableAsync(int tableId, TableDTO updatedTableDTO);
        Task DeleteTableAsync(int tableId);
    }
}
