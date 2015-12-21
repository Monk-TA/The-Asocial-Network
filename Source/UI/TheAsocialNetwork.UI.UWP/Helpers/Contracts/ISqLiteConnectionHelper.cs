namespace TheAsocialNetwork.UI.UWP.Helpers.Contracts
{
    using SQLite.Net.Async;

    public interface ISqLiteConnectionHelper
    {
        SQLiteAsyncConnection GetDbConnectionAsync();
        void InitAsync();
    }
}