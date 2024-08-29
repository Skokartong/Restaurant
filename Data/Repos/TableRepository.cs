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
            await _context.Tables.AddAsync(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableAsync(int tableId)
        {
            var table = await _context.Tables.FindAsync(tableId);

            if(table!=null)
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTableAsync(int tableId, Table updatedTable)
        {
            var table = await _context.Tables.FindAsync(tableId);

            if(table!=null)
            {
                table.FK_RestaurantId = updatedTable.FK_RestaurantId;
                table.AmountOfSeats = updatedTable.AmountOfSeats;
                table.TableNumber = updatedTable.TableNumber;
                table.IsAvailable = updatedTable.IsAvailable;

                _context.Tables.Update(table);
                await _context.SaveChangesAsync();
            }
        }
    }
}
