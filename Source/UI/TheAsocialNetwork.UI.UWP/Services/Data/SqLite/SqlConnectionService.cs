namespace TheAsocialNetwork.UI.UWP.Services.Data.SqLite
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Windows.Storage;
    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;
    using TheAsocialNetwork.UI.UWP.Services.Contracts;

    public class SqlConnectionService : ISqlConnectionService
    {
        public SQLiteAsyncConnection GetDbConnectionAsync()
        {
            var dbFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");

            var connectionFactory =
                new Func<SQLiteConnectionWithLock>(
                    () =>
                    new SQLiteConnectionWithLock(
                        new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(dbFilePath, storeDateTimeAsTicks: false)));

            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        //public async Task InitAsync()
        //{
           
        //}
    }
}
