using System;
using SQLite;
using GroupApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GroupApp.Data
{
    public class PinDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public PinDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Pins>().Wait();
        }

        public Task<List<Pins>> GetNotesAsync(int id)
        {
            return _database.Table<Pins>().Where(i => i.categoryID == id)
                            .ToListAsync();
        }

        public Task<Pins> GetNoteAsync(int id)
        {
            return _database.Table<Pins>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Pins pins)
        {
            if (pins.ID != 0)
            {
                return _database.UpdateAsync(pins);
            }
            else
            {
                return _database.InsertAsync(pins);
            }
        }

        public Task<int> DeleteNoteAsync(Pins pins)
        {
            return _database.DeleteAsync(pins);
        }
    }
}
