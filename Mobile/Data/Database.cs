using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SQLite; // Add SqLite into the file
using Mobile.Tables; //reference to the Tables folder where the tables are
using Mobile.Data;


namespace Mobile.Data
{

    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Note>().Wait();
            _database.CreateTableAsync<Person>().Wait();
        } // create the database refering to the tables that I have connected

        public Task<List<Note>> GetNotesAsync()
        {
            return _database.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return _database.Table<Note>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        // read data from the databse
        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
            //write data to the database
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return _database.DeleteAsync(note);
        }
        //Deleting data from the database
    }
}
// Reference the code: https://docs.microsoft.com/en-us/xamarin/get-started/quickstarts/database?pivots=windows