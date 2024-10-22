﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Table>> GetTablesByRestaurantIdAsync(int restaurantId)
        {
            return await _context.Tables
                .Where(t => t.FK_RestaurantId == restaurantId)
                .ToListAsync();
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

        public async Task<IEnumerable<Table>> GetAvailableTablesAsync(int restaurantId, DateTime startTime, DateTime endTime, int numberOfGuests)
        {
            return await _context.Tables
    .Where(t => t.FK_RestaurantId == restaurantId &&
                t.AmountOfSeats >= numberOfGuests &&
                !t.Reservations.Any(r => r.BookingStart < endTime && r.BookingEnd > startTime))
    .ToListAsync();
        }

        public async Task UpdateTableAsync(int tableId, Table updatedTable)
        {
            var table = await _context.Tables.FindAsync(tableId);

            if(table!=null)
            {
                table.FK_RestaurantId = updatedTable.FK_RestaurantId;
                table.AmountOfSeats = updatedTable.AmountOfSeats;
                table.TableNumber = updatedTable.TableNumber;

                _context.Tables.Update(table);
                await _context.SaveChangesAsync();
            }
        }
    }
}
