namespace TheAsocialNetwork.UI.UWP.Services.Contracts
{
    using SQLite.Net.Async;

    public interface ISqlConnectionService
    {
        SQLiteAsyncConnection GetDbConnectionAsync();
    }
}