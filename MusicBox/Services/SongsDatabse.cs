using MusicBox.Features.Recommandations;
using SQLite;

namespace MusicBox.Services;

public class SongsDatabse
{
    SQLiteAsyncConnection Database;
    public SongsDatabse()
    {
    }
    async Task Init()
    {
        if (Database is not null)
            return;

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "songsDb.db");

        try
        {
            Database = new SQLiteAsyncConnection(databasePath, Utils.Constants.Flags);
        }
        catch (Exception ex)
        {

        }
        var result = await Database.CreateTableAsync<TrackModel>();
    }

    public async Task<List<TrackModel>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<TrackModel>().ToListAsync();
    }

    public async Task<List<TrackModel>> GetItemsForUser()
    {
        await Init();
        return await Database.Table<TrackModel>().Where(t => t.UserEmail == Utils.Settings.Email).ToListAsync();

        // SQL queries are also possible
        //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
    }

    public async Task<TrackModel> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<TrackModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(TrackModel item)
    {
        await Init();
        return await Database.InsertAsync(item);
    }

    public async Task<int> SaveAllItemAsync(List<TrackModel> items)
    {
        await Init();
        return await Database.InsertAllAsync(items);
    }

    public async Task<int> DeleteItemAsync(TrackModel item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }

    public async Task<int> DeleteAllItemsAsync()
    {
        await Init();
        return await Database.DeleteAllAsync<TrackModel>();
    }

    public async Task DeleteAllItemsForAUserAsync()
    {
        await Init();
        try
        {
            await Database.QueryAsync<TrackModel>($"DELETE FROM [TrackModel] WHERE [UserEmail] = '{Utils.Settings.Email}'");
        }
        catch (Exception ex) { }
    }
}
