namespace TheAsocialNetwork.UI.UWP.Helpers.SqLite
{
    using System;
    using System.IO;

    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;

    using Windows.Storage;
    using TheAsocialNetwork.UI.UWP.Models.SqLite;

    public class SqLiteConnectionHelper
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

        public async void InitAsync()
        {
            var connection = this.GetDbConnectionAsync();
            await connection.CreateTablesAsync<UserSql, AvatarSql, ImageSql, ImageInfoSql, VideoSql>();
            await connection.CreateTablesAsync<LocationSql, PostSql>();
        }
    }
}